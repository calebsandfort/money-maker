using Microsoft.EntityFrameworkCore;
using MoneyMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMaker.Data
{
    public class MoneyMakerContext : DbContext
    {
        public MoneyMakerContext(DbContextOptions<MoneyMakerContext> options) : base(options)
        {
        }

        public DbSet<NflWeek> NflWeeks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<BetLedger> BetLedgers { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetTeam> BetTeams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetTeam>()
                .HasKey(c => new { c.BetID, c.TeamID });

            modelBuilder.Entity<Game>()
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamID)
                    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                        .HasOne(g => g.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(g => g.AwayTeamID)
                        .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }
    }
}
