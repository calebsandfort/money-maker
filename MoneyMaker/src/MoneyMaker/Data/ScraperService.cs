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

        public ScraperService(MoneyMakerContext context)
        {
            _context = context;
        }

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

        public async Task<Team> ScrapeNflTeam(HtmlNode teamRow)
        {
            HtmlNode teamLinkNode = teamRow.QuerySelector("a");
            Uri teamLink = new Uri(teamLinkNode.Attributes["href"].Value);

            Team team = new Team { CbsId = teamLink.Segments[4].Replace("/", String.Empty) };

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await Methods.DownloadPageStringAsync(team.CbsLink));

            return team;
        }

        #region Dispose
        public void Dispose()
        {

        } 
        #endregion
    }
}
