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
        }
    }
}
