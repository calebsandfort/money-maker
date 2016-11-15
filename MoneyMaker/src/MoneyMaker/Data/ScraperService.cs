using MoneyMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using MoneyMaker.Framework;

namespace MoneyMaker.Data
{
    public class ScraperService : IDisposable
    {
        private readonly MoneyMakerContext _context;
        private readonly List<NflWeek> _nflWeeks;
        private readonly List<Team> _teams;

        public ScraperService(MoneyMakerContext context)
        {
            _context = context;
            _nflWeeks = _context.NflWeeks.ToList();
            _teams = _context.Teams.ToList();
        }

        #region ScrapeNflTeams
        public async Task<List<Team>> ScrapeNflTeams()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await Methods.DownloadPageStringAsync("http://www.cbssports.com/nfl/standings"));

            List<HtmlNode> divisionTables = doc.DocumentNode.QuerySelectorAll("table.data.stacked").ToList();
            List<HtmlNode> teamRows = new List<HtmlNode>();

            foreach (HtmlNode divisionTable in divisionTables)
            {
                teamRows.AddRange(divisionTable.QuerySelectorAll("tr").Skip(1));
            }

            Task<Team>[] scrapeNflTeamTasks = teamRows.Select(x => this.ScrapeNflTeam(x)).ToArray();
            Team[] teams = await Task.WhenAll(scrapeNflTeamTasks);

            return new List<Team>(teams);
        }
        #endregion

        #region ScrapeNflTeam
        public async Task<Team> ScrapeNflTeam(HtmlNode teamRow)
        {
            HtmlNode teamLinkNode = teamRow.QuerySelector("a");
            Uri teamLink = new Uri(teamLinkNode.Attributes["href"].Value);

            Team team = new Team { CbsId = teamLink.Segments[4].Replace("/", String.Empty) };

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await Methods.DownloadPageStringAsync(team.CbsLink));

            #region Name
            HtmlNode infoDiv = doc.DocumentNode.QuerySelector(".info");
            team.Name = $"{infoDiv.QuerySelector(".superText").InnerText} {infoDiv.QuerySelector(".subText").InnerText}";
            #endregion

            #region Rankings
            List<HtmlNode> statRows = doc.DocumentNode.QuerySelectorAll(".stats tr.row1").ToList();
            team.OffenseRank = statRows[0].QuerySelectorAll("td").ElementAt(1).InnerText.GetNumber();
            team.OffenseRushingRank = statRows[0].QuerySelectorAll("td").ElementAt(2).InnerText.GetNumber();
            team.OffensePassingRank = statRows[0].QuerySelectorAll("td").ElementAt(3).InnerText.GetNumber();

            team.DefenseRank = statRows[1].QuerySelectorAll("td").ElementAt(1).InnerText.GetNumber();
            team.DefenseRushingRank = statRows[1].QuerySelectorAll("td").ElementAt(2).InnerText.GetNumber();
            team.DefensePassingRank = statRows[1].QuerySelectorAll("td").ElementAt(3).InnerText.GetNumber();
            #endregion

            return team;
        }
        #endregion

        #region ScrapeNflGames
        public async Task<List<Game>> ScrapeNflGames()
        {
            Task<List<Game>>[] scrapeNflTeamTasks = _teams.Select(x => this.ScrapeNflGamesForTeam(x)).ToArray();
            List<Game>[] gameLists = await Task.WhenAll(scrapeNflTeamTasks);
            List<Game> masterGames = new List<Game>();

            foreach (List<Game> gameList in gameLists)
            {
                foreach (Game game in gameList)
                {
                    if(!masterGames.Any(x => x.AwayTeamID == game.AwayTeamID && x.HomeTeamID == game.HomeTeamID))
                    {
                        masterGames.Add(game);
                    }
                }
            }

            return masterGames;
        }
        #endregion

        #region ScrapeNflGamesForTeam
        public async Task<List<Game>> ScrapeNflGamesForTeam(Team team)
        {
            DateTime today = DateTime.Now.Date;
            List<Game> games = new List<Game>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await Methods.DownloadPageStringAsync(team.CbsLink));

            foreach(HtmlNode scheduleRow in doc.DocumentNode.QuerySelectorAll(".recentSchedule table.data tr"))
            {
                Game game = new Game();

                #region Teams
                String otherTeamString = scheduleRow.QuerySelector(".gameMatchup").InnerText.Replace("Recap", String.Empty).Replace("Preview", String.Empty);
                bool awayGame = otherTeamString.StartsWith("at ");

                if (awayGame)
                {
                    game.AwayTeamID = team.ID;
                    game.HomeTeamID = _teams.First(x => x.CbsId == otherTeamString.Replace("at ", String.Empty)).ID;
                }
                else
                {
                    game.AwayTeamID = _teams.First(x => x.CbsId == otherTeamString).ID;
                    game.HomeTeamID = team.ID;
                }
                #endregion

                #region Date
                if (scheduleRow.QuerySelector(".gameDate").InnerText == "Today")
                {
                    game.Date = today;
                }
                else
                {
                    game.Date = DateTime.Parse(scheduleRow.QuerySelector(".gameDate").InnerText.StripDay());
                }

                if (game.Date.Month == 1) game.Date = new DateTime(game.Date.Year + 1, game.Date.Month, game.Date.Day);

                game.NflWeekID = _nflWeeks.First(x => game.Date > x.Start && game.Date < x.End).ID;
                #endregion

                #region Score
                if (today > game.Date)
                {
                    game.Played = true;

                    HtmlNode gameDesc = scheduleRow.QuerySelector(".gameDesc");
                    HtmlNode winNode = gameDesc.QuerySelector(".win");
                    HtmlNode lossNode = gameDesc.QuerySelector(".loss");
                    String[] scoreSplit;
                    int winningScore = -1;
                    int losingScore = -1;

                    if (winNode != null)
                    {
                        scoreSplit = winNode.InnerText.Replace("W ", String.Empty).Split((new List<String>() { " - " }).ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        winningScore = Int32.Parse(scoreSplit[0]);
                        losingScore = Int32.Parse(scoreSplit[1]);

                        if (awayGame)
                        {
                            game.AwayScore = winningScore;
                            game.HomeScore = losingScore;
                        }
                        else
                        {
                            game.AwayScore = losingScore;
                            game.HomeScore = winningScore;
                        }
                    }
                    else if (lossNode != null)
                    {
                        scoreSplit = lossNode.InnerText.Replace("L ", String.Empty).Split((new List<String>() { " - " }).ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        winningScore = Int32.Parse(scoreSplit[0]);
                        losingScore = Int32.Parse(scoreSplit[1]);

                        if (awayGame)
                        {
                            game.AwayScore = losingScore;
                            game.HomeScore = winningScore;
                        }
                        else
                        {
                            game.AwayScore = winningScore;
                            game.HomeScore = losingScore;
                        }
                    }
                    else
                    {
                        scoreSplit = gameDesc.InnerText.Split((new List<String>() { " - " }).ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        winningScore = Int32.Parse(scoreSplit[0]);
                        losingScore = Int32.Parse(scoreSplit[1]);

                        game.AwayScore = losingScore;
                        game.HomeScore = winningScore;
                    }  
                }
                #endregion

                games.Add(game);
            }

            return games;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {

        } 
        #endregion
    }
}
