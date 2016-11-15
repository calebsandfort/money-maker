using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Data;
using MoneyMaker.Models;

namespace MoneyMaker.Controllers
{
    public class NflTeamsController : Controller
    {
        private readonly MoneyMakerContext _context;

        public NflTeamsController(MoneyMakerContext context)
        {
            _context = context;    
        }

        // GET: NflTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.Where(x => x.League == Leagues.Nfl).ToListAsync());
        }

        // GET: NflTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.SingleOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: NflTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NflTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CbsId,Conference,DefensePassingRank,DefenseRank,DefenseRushingRank,Division,ExpectedLosses,ExpectedTies,ExpectedWins,League,Losses,Name,OffensePassingRank,OffenseRank,OffenseRushingRank,PowerRanking,Ties,Wins")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: NflTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.SingleOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: NflTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CbsId,Conference,DefensePassingRank,DefenseRank,DefenseRushingRank,Division,ExpectedLosses,ExpectedTies,ExpectedWins,League,Losses,Name,OffensePassingRank,OffenseRank,OffenseRushingRank,PowerRanking,Ties,Wins")] Team team)
        {
            if (id != team.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: NflTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.SingleOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: NflTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.SingleOrDefaultAsync(m => m.ID == id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.ID == id);
        }
    }
}
