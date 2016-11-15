using MoneyMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMaker.Data
{
    public class DbInitializer
    {
        public static void Initialize(MoneyMakerContext context)
        {
            context.Database.EnsureCreated();

            #region NflWeeks
            if (!context.NflWeeks.Any())
            {
                DateTime weekStart = new DateTime(2016, 9, 6);

                for (int i = 1; i <= 17; i++)
                {
                    context.NflWeeks.Add(new NflWeek { Start = weekStart, End = weekStart.AddDays(7), Number = i });
                    weekStart = weekStart.AddDays(7);
                }

                context.SaveChanges();
            }
            #endregion

            #region NflTeams
            if (!context.Teams.Any(x => x.League == Leagues.Nfl))
            {
                context.Teams.Add(new Team
                {
                    Name = "New England Patriots",
                    CbsId = "NE",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.East,
                    OffenseRank = 9,
                    OffenseRushingRank = 13,
                    OffensePassingRank = 10,
                    DefenseRank = 16,
                    DefenseRushingRank = 14,
                    DefensePassingRank = 18
                });
                context.Teams.Add(new Team
                {
                    Name = "Miami Dolphins",
                    CbsId = "MIA",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.East,
                    OffenseRank = 22,
                    OffenseRushingRank = 6,
                    OffensePassingRank = 28,
                    DefenseRank = 19,
                    DefenseRushingRank = 30,
                    DefensePassingRank = 9
                });
                context.Teams.Add(new Team
                {
                    Name = "Buffalo Bills",
                    CbsId = "BUF",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.East,
                    OffenseRank = 18,
                    OffenseRushingRank = 2,
                    OffensePassingRank = 31,
                    DefenseRank = 14,
                    DefenseRushingRank = 20,
                    DefensePassingRank = 11
                });
                context.Teams.Add(new Team
                {
                    Name = "New York Jets",
                    CbsId = "NYJ",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.East,
                    OffenseRank = 24,
                    OffenseRushingRank = 10,
                    OffensePassingRank = 29,
                    DefenseRank = 13,
                    DefenseRushingRank = 5,
                    DefensePassingRank = 19
                });
                context.Teams.Add(new Team
                {
                    Name = "Baltimore Ravens",
                    CbsId = "BAL",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.North,
                    OffenseRank = 25,
                    OffenseRushingRank = 28,
                    OffensePassingRank = 20,
                    DefenseRank = 1,
                    DefenseRushingRank = 1,
                    DefensePassingRank = 5
                });
                context.Teams.Add(new Team
                {
                    Name = "Pittsburgh Steelers",
                    CbsId = "PIT",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.North,
                    OffenseRank = 11,
                    OffenseRushingRank = 25,
                    OffensePassingRank = 4,
                    DefenseRank = 25,
                    DefenseRushingRank = 15,
                    DefensePassingRank = 28
                });
                context.Teams.Add(new Team
                {
                    Name = "Cincinnati Bengals",
                    CbsId = "CIN",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.North,
                    OffenseRank = 6,
                    OffenseRushingRank = 7,
                    OffensePassingRank = 5,
                    DefenseRank = 24,
                    DefenseRushingRank = 24,
                    DefensePassingRank = 20
                });
                context.Teams.Add(new Team
                {
                    Name = "Cleveland Browns",
                    CbsId = "CLE",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.North,
                    OffenseRank = 28,
                    OffenseRushingRank = 22,
                    OffensePassingRank = 27,
                    DefenseRank = 31,
                    DefenseRushingRank = 31,
                    DefensePassingRank = 26
                });
                context.Teams.Add(new Team
                {
                    Name = "Houston Texans",
                    CbsId = "HOU",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.South,
                    OffenseRank = 30,
                    OffenseRushingRank = 5,
                    OffensePassingRank = 32,
                    DefenseRank = 4,
                    DefenseRushingRank = 26,
                    DefensePassingRank = 3
                });
                context.Teams.Add(new Team
                {
                    Name = "Tennessee Titans",
                    CbsId = "TEN",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.South,
                    OffenseRank = 7,
                    OffenseRushingRank = 3,
                    OffensePassingRank = 21,
                    DefenseRank = 16,
                    DefenseRushingRank = 7,
                    DefensePassingRank = 22
                });
                context.Teams.Add(new Team
                {
                    Name = "Indianapolis Colts",
                    CbsId = "IND",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.South,
                    OffenseRank = 13,
                    OffenseRushingRank = 23,
                    OffensePassingRank = 12,
                    DefenseRank = 30,
                    DefenseRushingRank = 22,
                    DefensePassingRank = 31
                });
                context.Teams.Add(new Team
                {
                    Name = "Jacksonville Jaguars",
                    CbsId = "JAC",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.South,
                    OffenseRank = 19,
                    OffenseRushingRank = 26,
                    OffensePassingRank = 13,
                    DefenseRank = 8,
                    DefenseRushingRank = 29,
                    DefensePassingRank = 4
                });
                context.Teams.Add(new Team
                {
                    Name = "Kansas City Chiefs",
                    CbsId = "KC",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.West,
                    OffenseRank = 26,
                    OffenseRushingRank = 20,
                    OffensePassingRank = 22,
                    DefenseRank = 21,
                    DefenseRushingRank = 27,
                    DefensePassingRank = 13
                });
                context.Teams.Add(new Team
                {
                    Name = "Oakland Raiders",
                    CbsId = "OAK",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.West,
                    OffenseRank = 5,
                    OffenseRushingRank = 4,
                    OffensePassingRank = 7,
                    DefenseRank = 28,
                    DefenseRushingRank = 21,
                    DefensePassingRank = 30
                });
                context.Teams.Add(new Team
                {
                    Name = "Denver Broncos",
                    CbsId = "DEN",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.West,
                    OffenseRank = 27,
                    OffenseRushingRank = 24,
                    OffensePassingRank = 24,
                    DefenseRank = 5,
                    DefenseRushingRank = 28,
                    DefensePassingRank = 1
                });
                context.Teams.Add(new Team
                {
                    Name = "San Diego Chargers",
                    CbsId = "SD",
                    League = Leagues.Nfl,
                    Conference = Conferences.American,
                    Division = Divisions.West,
                    OffenseRank = 10,
                    OffenseRushingRank = 18,
                    OffensePassingRank = 5,
                    DefenseRank = 18,
                    DefenseRushingRank = 6,
                    DefensePassingRank = 25
                });
                context.Teams.Add(new Team
                {
                    Name = "Dallas Cowboys",
                    CbsId = "DAL",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.East,
                    OffenseRank = 3,
                    OffenseRushingRank = 1,
                    OffensePassingRank = 17,
                    DefenseRank = 12,
                    DefenseRushingRank = 3,
                    DefensePassingRank = 21
                });
                context.Teams.Add(new Team
                {
                    Name = "New York Giants",
                    CbsId = "NYG",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.East,
                    OffenseRank = 21,
                    OffenseRushingRank = 32,
                    OffensePassingRank = 9,
                    DefenseRank = 23,
                    DefenseRushingRank = 8,
                    DefensePassingRank = 27
                });
                context.Teams.Add(new Team
                {
                    Name = "Washington Redskins",
                    CbsId = "WAS",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.East,
                    OffenseRank = 4,
                    OffenseRushingRank = 12,
                    OffensePassingRank = 3,
                    DefenseRank = 20,
                    DefenseRushingRank = 23,
                    DefensePassingRank = 15
                });
                context.Teams.Add(new Team
                {
                    Name = "Philadelphia Eagles",
                    CbsId = "PHI",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.East,
                    OffenseRank = 17,
                    OffenseRushingRank = 9,
                    OffensePassingRank = 26,
                    DefenseRank = 6,
                    DefenseRushingRank = 13,
                    DefensePassingRank = 7
                });
                context.Teams.Add(new Team
                {
                    Name = "Detroit Lions",
                    CbsId = "DET",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.North,
                    OffenseRank = 23,
                    OffenseRushingRank = 27,
                    OffensePassingRank = 18,
                    DefenseRank = 22,
                    DefenseRushingRank = 18,
                    DefensePassingRank = 17
                });
                context.Teams.Add(new Team
                {
                    Name = "Minnesota Vikings",
                    CbsId = "MIN",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.North,
                    OffenseRank = 32,
                    OffenseRushingRank = 31,
                    OffensePassingRank = 23,
                    DefenseRank = 3,
                    DefenseRushingRank = 10,
                    DefensePassingRank = 6
                });
                context.Teams.Add(new Team
                {
                    Name = "Green Bay Packers",
                    CbsId = "GB",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.North,
                    OffenseRank = 15,
                    OffenseRushingRank = 19,
                    OffensePassingRank = 14,
                    DefenseRank = 10,
                    DefenseRushingRank = 4,
                    DefensePassingRank = 16
                });
                context.Teams.Add(new Team
                {
                    Name = "Chicago Bears",
                    CbsId = "CHI",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.North,
                    OffenseRank = 16,
                    OffenseRushingRank = 21,
                    OffensePassingRank = 19,
                    DefenseRank = 11,
                    DefenseRushingRank = 11,
                    DefensePassingRank = 12
                });
                context.Teams.Add(new Team
                {
                    Name = "Atlanta Falcons",
                    CbsId = "ATL",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.South,
                    OffenseRank = 2,
                    OffenseRushingRank = 15,
                    OffensePassingRank = 2,
                    DefenseRank = 26,
                    DefenseRushingRank = 16,
                    DefensePassingRank = 29
                });
                context.Teams.Add(new Team
                {
                    Name = "Tampa Bay Buccaneers",
                    CbsId = "TB",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.South,
                    OffenseRank = 14,
                    OffenseRushingRank = 17,
                    OffensePassingRank = 16,
                    DefenseRank = 27,
                    DefenseRushingRank = 25,
                    DefensePassingRank = 22
                });
                context.Teams.Add(new Team
                {
                    Name = "New Orleans Saints",
                    CbsId = "NO",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.South,
                    OffenseRank = 1,
                    OffenseRushingRank = 16,
                    OffensePassingRank = 1,
                    DefenseRank = 29,
                    DefenseRushingRank = 19,
                    DefensePassingRank = 32
                });
                context.Teams.Add(new Team
                {
                    Name = "Carolina Panthers",
                    CbsId = "CAR",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.South,
                    OffenseRank = 12,
                    OffenseRushingRank = 11,
                    OffensePassingRank = 15,
                    DefenseRank = 15,
                    DefenseRushingRank = 2,
                    DefensePassingRank = 24
                });
                context.Teams.Add(new Team
                {
                    Name = "Seattle Seahawks",
                    CbsId = "SEA",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.West,
                    OffenseRank = 20,
                    OffenseRushingRank = 30,
                    OffensePassingRank = 11,
                    DefenseRank = 9,
                    DefenseRushingRank = 9,
                    DefensePassingRank = 10
                });
                context.Teams.Add(new Team
                {
                    Name = "Arizona Cardinals",
                    CbsId = "ARI",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.West,
                    OffenseRank = 8,
                    OffenseRushingRank = 14,
                    OffensePassingRank = 8,
                    DefenseRank = 2,
                    DefenseRushingRank = 12,
                    DefensePassingRank = 2
                });
                context.Teams.Add(new Team
                {
                    Name = "Los Angeles Rams",
                    CbsId = "LAR",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.West,
                    OffenseRank = 31,
                    OffenseRushingRank = 29,
                    OffensePassingRank = 25,
                    DefenseRank = 7,
                    DefenseRushingRank = 17,
                    DefensePassingRank = 8
                });
                context.Teams.Add(new Team
                {
                    Name = "San Francisco 49ers",
                    CbsId = "SF",
                    League = Leagues.Nfl,
                    Conference = Conferences.National,
                    Division = Divisions.West,
                    OffenseRank = 29,
                    OffenseRushingRank = 8,
                    OffensePassingRank = 30,
                    DefenseRank = 32,
                    DefenseRushingRank = 32,
                    DefensePassingRank = 14
                });

                context.SaveChanges();
            }
            #endregion

            #region NflGames
            if (!context.Games.Any(x => x.AwayTeam.League == Leagues.Nfl))
            {
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 34, NflWeekID = 35, AwayScore = 23, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 33, NflWeekID = 49, AwayScore = 24, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/22/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 33, NflWeekID = 48, AwayScore = 0, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 33, NflWeekID = 47, AwayScore = 16, HomeScore = 0, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 56, NflWeekID = 46, AwayScore = 33, HomeScore = 13, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 33, NflWeekID = 45, AwayScore = 17, HomeScore = 35, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 58, NflWeekID = 44, AwayScore = 27, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 61, NflWeekID = 50, AwayScore = 41, HomeScore = 25, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 33, NflWeekID = 41, AwayScore = 31, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 64, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 60, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 33, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/12/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 33, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 49, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 33, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 33, HomeTeamID = 62, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 34, NflWeekID = 49, AwayScore = 7, HomeScore = 40, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 61, NflWeekID = 48, AwayScore = 18, HomeScore = 33, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 34, NflWeekID = 47, AwayScore = 17, HomeScore = 13, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/6/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 64, NflWeekID = 46, AwayScore = 33, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/17/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 34, NflWeekID = 45, AwayScore = 3, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 34, NflWeekID = 44, AwayScore = 6, HomeScore = 6, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 36, NflWeekID = 50, AwayScore = 20, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 34, NflWeekID = 41, AwayScore = 20, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 42, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 39, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 34, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 62, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 34, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 35, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 34, HomeTeamID = 63, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 35, NflWeekID = 35, AwayScore = 10, HomeScore = 12, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 63, NflWeekID = 49, AwayScore = 3, HomeScore = 9, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 35, NflWeekID = 48, AwayScore = 18, HomeScore = 37, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 60, NflWeekID = 47, AwayScore = 27, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 35, NflWeekID = 45, AwayScore = 24, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 37, NflWeekID = 50, AwayScore = 20, HomeScore = 25, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/7/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 35, NflWeekID = 43, AwayScore = 25, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 35, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 38, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 35, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 41, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/15/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 35, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 35, HomeTeamID = 64, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/8/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 49, NflWeekID = 35, AwayScore = 20, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 36, NflWeekID = 49, AwayScore = 27, HomeScore = 46, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 36, NflWeekID = 48, AwayScore = 22, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 39, NflWeekID = 47, AwayScore = 33, HomeScore = 48, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/10/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 36, NflWeekID = 46, AwayScore = 17, HomeScore = 14, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 37, NflWeekID = 45, AwayScore = 38, HomeScore = 41, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 63, NflWeekID = 43, AwayScore = 13, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 36, NflWeekID = 41, AwayScore = 20, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/17/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 36, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 50, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 36, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/19/16 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 45, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 36, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 36, HomeTeamID = 38, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 37, NflWeekID = 35, AwayScore = 35, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 46, NflWeekID = 49, AwayScore = 13, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/26/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 37, NflWeekID = 48, AwayScore = 45, HomeScore = 32, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 48, NflWeekID = 47, AwayScore = 35, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 51, NflWeekID = 44, AwayScore = 21, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 64, NflWeekID = 43, AwayScore = 41, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 37, NflWeekID = 41, AwayScore = 25, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 37, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 37, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 38, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 37, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 37, HomeTeamID = 39, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 39, NflWeekID = 35, AwayScore = 31, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 38, NflWeekID = 48, AwayScore = 37, HomeScore = 32, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 38, NflWeekID = 47, AwayScore = 27, HomeScore = 7, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 64, NflWeekID = 44, AwayScore = 34, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 38, NflWeekID = 50, AwayScore = 30, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/3/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 38, NflWeekID = 43, AwayScore = 43, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 38, NflWeekID = 41, AwayScore = 10, HomeScore = 36, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 51, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 48, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 38, HomeTeamID = 47, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 50, NflWeekID = 49, AwayScore = 35, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 49, NflWeekID = 46, AwayScore = 23, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 39, NflWeekID = 44, AwayScore = 33, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 39, NflWeekID = 50, AwayScore = 32, HomeScore = 33, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 44, NflWeekID = 41, AwayScore = 15, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 39, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 39, HomeTeamID = 63, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 39, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 55, NflWeekID = 35, AwayScore = 14, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/19/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 40, NflWeekID = 49, AwayScore = 29, HomeScore = 14, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 47, NflWeekID = 48, AwayScore = 17, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 40, NflWeekID = 47, AwayScore = 14, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 53, NflWeekID = 46, AwayScore = 23, HomeScore = 29, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 40, NflWeekID = 45, AwayScore = 17, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/20/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 41, NflWeekID = 44, AwayScore = 10, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/31/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 40, NflWeekID = 50, AwayScore = 10, HomeScore = 20, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 46, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 40, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 40, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 43, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 40, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 40, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 40, HomeTeamID = 42, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 52, NflWeekID = 35, AwayScore = 27, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 42, NflWeekID = 49, AwayScore = 14, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 41, NflWeekID = 48, AwayScore = 27, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 41, NflWeekID = 46, AwayScore = 16, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 41, NflWeekID = 45, AwayScore = 30, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 41, NflWeekID = 43, AwayScore = 31, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 54, NflWeekID = 41, AwayScore = 25, HomeScore = 47, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 45, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/28/16 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 44, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 41, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 41, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 41, HomeTeamID = 43, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 54, NflWeekID = 35, AwayScore = 25, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/3/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 42, NflWeekID = 47, AwayScore = 10, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 42, NflWeekID = 46, AwayScore = 13, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 44, NflWeekID = 44, AwayScore = 10, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 42, NflWeekID = 43, AwayScore = 22, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 45, NflWeekID = 41, AwayScore = 20, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/24/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 43, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/1/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 42, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 42, HomeTeamID = 52, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 42, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 53, NflWeekID = 35, AwayScore = 39, HomeScore = 35, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 43, NflWeekID = 49, AwayScore = 16, HomeScore = 15, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 43, NflWeekID = 46, AwayScore = 23, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 43, NflWeekID = 45, AwayScore = 28, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 43, NflWeekID = 44, AwayScore = 17, HomeScore = 20, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 55, NflWeekID = 50, AwayScore = 13, HomeScore = 20, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 43, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 46, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/26/16 12:00:00 AM"), AwayTeamID = 43, HomeTeamID = 47, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 44, NflWeekID = 35, AwayScore = 10, HomeScore = 29, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 44, NflWeekID = 48, AwayScore = 3, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 45, NflWeekID = 45, AwayScore = 20, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 47, NflWeekID = 50, AwayScore = 23, HomeScore = 29, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 46, NflWeekID = 43, AwayScore = 23, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 57, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 44, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 44, HomeTeamID = 59, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/22/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 44, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 44, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/12/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 45, NflWeekID = 35, AwayScore = 38, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 45, NflWeekID = 49, AwayScore = 27, HomeScore = 23, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 46, NflWeekID = 48, AwayScore = 29, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 45, NflWeekID = 47, AwayScore = 20, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 59, NflWeekID = 46, AwayScore = 16, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 57, NflWeekID = 50, AwayScore = 27, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/24/16 12:00:00 AM"), AwayTeamID = 45, HomeTeamID = 47, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 45, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 47, NflWeekID = 35, AwayScore = 20, HomeScore = 19, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 46, NflWeekID = 45, AwayScore = 23, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 63, NflWeekID = 44, AwayScore = 17, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/14/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 46, NflWeekID = 41, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 56, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 46, HomeTeamID = 58, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 46, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 64, NflWeekID = 47, AwayScore = 24, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 47, NflWeekID = 46, AwayScore = 14, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 56, NflWeekID = 43, AwayScore = 35, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 47, HomeTeamID = 58, NflWeekID = 41, AwayScore = 35, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 47, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 51, NflWeekID = 35, AwayScore = 27, HomeScore = 33, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 48, NflWeekID = 49, AwayScore = 14, HomeScore = 38, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 53, NflWeekID = 48, AwayScore = 22, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 50, NflWeekID = 46, AwayScore = 31, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/13/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 48, NflWeekID = 45, AwayScore = 13, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 49, NflWeekID = 50, AwayScore = 19, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 48, NflWeekID = 43, AwayScore = 35, HomeScore = 43, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 48, NflWeekID = 41, AwayScore = 31, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 55, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 48, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 48, HomeTeamID = 56, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 48, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 49, NflWeekID = 49, AwayScore = 20, HomeScore = 34, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 57, NflWeekID = 48, AwayScore = 29, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/24/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 49, NflWeekID = 44, AwayScore = 9, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 50, NflWeekID = 43, AwayScore = 20, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 49, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 52, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 54, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/25/16 12:00:00 AM"), AwayTeamID = 49, HomeTeamID = 51, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 49, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 54, NflWeekID = 48, AwayScore = 17, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 59, NflWeekID = 47, AwayScore = 28, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 50, NflWeekID = 45, AwayScore = 26, HomeScore = 10, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 52, NflWeekID = 44, AwayScore = 33, HomeScore = 16, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/21/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 50, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 50, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/8/16 12:00:00 AM"), AwayTeamID = 50, HomeTeamID = 51, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 50, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 55, NflWeekID = 49, AwayScore = 12, HomeScore = 19, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 51, NflWeekID = 48, AwayScore = 3, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 58, NflWeekID = 47, AwayScore = 14, HomeScore = 43, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 51, HomeTeamID = 53, NflWeekID = 50, AwayScore = 30, HomeScore = 14, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 51, NflWeekID = 43, AwayScore = 14, HomeScore = 19, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 51, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 52, NflWeekID = 48, AwayScore = 19, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 52, NflWeekID = 47, AwayScore = 27, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/27/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 54, NflWeekID = 50, AwayScore = 22, HomeScore = 36, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 52, NflWeekID = 41, AwayScore = 24, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 61, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 55, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 52, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 52, HomeTeamID = 53, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 55, NflWeekID = 45, AwayScore = 23, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 54, NflWeekID = 44, AwayScore = 34, HomeScore = 26, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 53, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/24/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 53, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/5/16 12:00:00 AM"), AwayTeamID = 53, HomeTeamID = 60, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 53, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("10/2/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 55, NflWeekID = 47, AwayScore = 20, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 54, HomeTeamID = 62, NflWeekID = 46, AwayScore = 30, HomeScore = 17, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 54, NflWeekID = 45, AwayScore = 26, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 55, HomeTeamID = 54, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 55, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 56, NflWeekID = 49, AwayScore = 25, HomeScore = 20, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/25/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 62, NflWeekID = 48, AwayScore = 24, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 57, NflWeekID = 44, AwayScore = 17, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/30/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 56, NflWeekID = 50, AwayScore = 31, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/10/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 59, NflWeekID = 41, AwayScore = 7, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 56, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 56, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 61, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 56, HomeTeamID = 58, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 60, NflWeekID = 35, AwayScore = 23, HomeScore = 22, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/18/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 58, NflWeekID = 49, AwayScore = 16, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("9/29/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 57, NflWeekID = 47, AwayScore = 7, HomeScore = 22, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 57, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 57, HomeTeamID = 59, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/18/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 57, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 57, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 58, NflWeekID = 46, AwayScore = 13, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 62, NflWeekID = 45, AwayScore = 15, HomeScore = 30, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 59, NflWeekID = 43, AwayScore = 14, HomeScore = 21, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 58, HomeTeamID = 61, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/25/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 58, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/11/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 59, NflWeekID = 35, AwayScore = 7, HomeScore = 13, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 59, HomeTeamID = 60, NflWeekID = 44, AwayScore = 16, HomeScore = 24, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/4/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 59, NflWeekID = 38, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/15/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 61, NflWeekID = 49, AwayScore = 37, HomeScore = 31, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/6/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 62, NflWeekID = 43, AwayScore = 23, HomeScore = 27, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("11/13/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 60, NflWeekID = 41, AwayScore = 9, HomeScore = 6, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/11/16 12:00:00 AM"), AwayTeamID = 60, HomeTeamID = 64, NflWeekID = 37, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("12/17/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 60, NflWeekID = 36, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("1/1/17 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 60, NflWeekID = 51, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("10/9/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 63, NflWeekID = 46, AwayScore = 30, HomeScore = 19, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/16/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 61, NflWeekID = 45, AwayScore = 16, HomeScore = 45, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("10/23/16 12:00:00 AM"), AwayTeamID = 61, HomeTeamID = 62, NflWeekID = 44, AwayScore = 25, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 61, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/20/16 12:00:00 AM"), AwayTeamID = 62, HomeTeamID = 63, NflWeekID = 40, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("11/27/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 62, NflWeekID = 39, AwayScore = 0, HomeScore = 0, Played = false });
                context.Games.Add(new Game { Date = DateTime.Parse("9/12/16 12:00:00 AM"), AwayTeamID = 63, HomeTeamID = 64, NflWeekID = 35, AwayScore = 0, HomeScore = 28, Played = true });
                context.Games.Add(new Game { Date = DateTime.Parse("12/24/16 12:00:00 AM"), AwayTeamID = 64, HomeTeamID = 63, NflWeekID = 42, AwayScore = 0, HomeScore = 0, Played = false });

                context.SaveChanges();
            } 
            #endregion
        }
    }
}
