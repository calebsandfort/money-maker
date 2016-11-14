using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using System.Text;
using MoneyMaker.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyMaker.Controllers
{
    [Route("api/[controller]")]
    public class GenerationController : Controller
    {
        private readonly MoneyMakerContext _context;
        private readonly ScraperService _scraperService;

        public GenerationController(MoneyMakerContext context, ScraperService scraperService)
        {
            _context = context;
            _scraperService = scraperService;
        }

        // GET: api/values
        [HttpGet]
        [Route("NflWeeks")]
        public String GetNflWeeks()
        {
            StringBuilder generationSB = new StringBuilder();
            DateTime weekStart = new DateTime(2016, 9, 6);

            for (int i = 1; i <= 17; i++)
            {
                _context.NflWeeks.Add(new NflWeek { Start = weekStart, End = weekStart.AddDays(7) });
                weekStart = weekStart.AddDays(7);
            }

            return generationSB.ToString();
        }

        [HttpGet]
        [Route("NflTeams")]
        public async Task<String> GetNflTeams()
        {
            StringBuilder generationSB = new StringBuilder();

            List<Team> teams = await _scraperService.ScrapeNflTeams();

            foreach(Team team in teams)
            {
                _context.Teams.Add(new Team { CbsId = team.CbsId });
                generationSB.AppendLine($"context.Teams.Add(new Team {{ CbsId = \"{team.CbsId}\" }});");
            }

            return generationSB.ToString();
        }
    }
}
