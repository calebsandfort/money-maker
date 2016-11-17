using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using MoneyMaker.Models;

namespace MoneyMaker.Controllers
{
    [Route("api/Sync")]
    public class SyncController : Controller
    {
        private readonly MoneyMakerContext _context;
        private readonly SyncService _syncService;
        private readonly ScraperService _scraperService;

        public SyncController(MoneyMakerContext context, SyncService syncService, ScraperService scraperService)
        {
            _context = context;
            _syncService = syncService;
            _scraperService = scraperService;
        }

        [HttpGet]
        [Route("NflRecords")]
        public async Task GetNflRecords()
        {
            await _syncService.SyncNflRecords();
        }

        [HttpGet]
        [Route("NflTeamStats")]
        public async Task GetNflTeamStats()
        {
            await _syncService.SyncNflStats(await _scraperService.ScrapeNflTeams());
        }
    }
}