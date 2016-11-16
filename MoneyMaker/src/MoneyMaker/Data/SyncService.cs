using MoneyMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoneyMaker.Data
{
    public class SyncService : IDisposable
    {
        private readonly MoneyMakerContext _context;

        public SyncService(MoneyMakerContext context)
        {
            _context = context;
        }

        public async Task SyncNflRecords()
        {
            foreach(Team team in await _context.Teams.Include(x => x.AwayGames).Include(x => x.HomeGames).Where(x => x.League == Leagues.Nfl).ToListAsync())
            {
                team.SyncRecord();
            }

            await _context.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            
        } 
        #endregion
    }
}
