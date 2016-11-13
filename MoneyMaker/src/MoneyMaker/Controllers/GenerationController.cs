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

        public GenerationController(MoneyMakerContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        [Route("NflWeeks")]
        public String GetNflWeeks()
        {
            StringBuilder generationSB = new StringBuilder();
            DateTime weekStart = new DateTime(2016, 9, 6);

            for(int i = 1; i <= 17; i++)
            {
                _context.NflWeeks.Add(new NflWeek { Start = weekStart, End = weekStart.AddDays(7) });
                weekStart = weekStart.AddDays(7);
            }
            
            return generationSB.ToString();
        }
    }
}
