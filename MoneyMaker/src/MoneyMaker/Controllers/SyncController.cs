using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;

namespace MoneyMaker.Controllers
{
    [Route("api/Sync")]
    public class SyncController : Controller
    {
        private readonly MoneyMakerContext _context;
        private readonly SyncService _syncService;

        public SyncController(MoneyMakerContext context, SyncService syncService)
        {
            _context = context;
            _syncService = syncService;
        }

        [HttpGet]
        [Route("NflRecords")]
        public async Task GetNflRecords()
        {
            await _syncService.SyncNflRecords();
        }
    }
}