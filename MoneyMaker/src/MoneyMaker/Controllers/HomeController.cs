using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Models;

namespace MoneyMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoneyMakerContext _context;

        public HomeController(MoneyMakerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var nflWeeksQuery = from w in _context.NflWeeks
                                   orderby w.Number
                                   select w;

            DateTime today = DateTime.Today;
            NflWeek selectedNflWeek = _context.NflWeeks
                .Include(x => x.Games).ThenInclude(x => x.HomeTeam)
                .Include(x => x.Games).ThenInclude(x => x.AwayTeam)
                .FirstOrDefault(x => today >= x.Start && today < x.End);

            ViewBag.NflWeekID = new SelectList(nflWeeksQuery.AsNoTracking(), "ID", "Display", selectedNflWeek.ID);
            ViewBag.NflWeekNumber = selectedNflWeek.Number;

            //var conferenceGroupings = from t in _context.Teams
            //                          group t by new { t.Conference } into g
            //                          orderby g.Key.Conference
            //                          select new
            //                          {
            //                              Conference = g.Key.Conference,
            //                              Teams = g.ToList()
            //                          };

            //LeagueLayout leagueLayout = new LeagueLayout();

            //foreach (var conferenceGrouping in conferenceGroupings)
            //{

            var gameDayGroupings = from g in selectedNflWeek.Games
                                   group g by new { g.Date } into gr
                                   orderby gr.Key.Date
                                   select new
                                   {
                                       Day = gr.Key.Date,
                                       Games = gr.ToList()
                                   };

            GameWeekLayout gameWeekLayout = new GameWeekLayout();

            foreach(var gameDayGroup in gameDayGroupings)
            {
                gameWeekLayout.GameDayLayouts.Add(new GameDayLayout()
                {
                    Day = gameDayGroup.Day,
                    Games = gameDayGroup.Games
                });
            }

            return View(gameWeekLayout);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult MatchupModalContent(int id)
        {
            Game game = _context.Games
                .Include(x => x.AwayTeam)
                    .ThenInclude(x => x.AwayGames)
                        .ThenInclude(x => x.AwayTeam)
                    .ThenInclude(x => x.AwayGames)
                        .ThenInclude(x => x.HomeTeam)
                .Include(x => x.HomeTeam)
                    .ThenInclude(x => x.HomeGames)
                        .ThenInclude(x => x.AwayTeam)
                    .ThenInclude(x => x.HomeGames)
                        .ThenInclude(x => x.HomeTeam)
                .SingleOrDefault(x => x.ID == id);
            return PartialView("_MatchupModalContent", game);
        }
    }
}
