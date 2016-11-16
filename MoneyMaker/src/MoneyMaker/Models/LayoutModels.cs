using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMaker.Models
{
    public class LeagueLayout
    {
        public Leagues League { get; set; }

        public List<ConferenceLayout> ConferenceLayouts { get; set; }

        public LeagueLayout()
        {
            this.ConferenceLayouts = new List<ConferenceLayout>();
        }
    }

    public class ConferenceLayout
    {
        public Conferences Conference { get; set; }
        public List<DivisionLayout> DivisionLayouts { get; set; }

        public ConferenceLayout()
        {
            this.DivisionLayouts = new List<DivisionLayout>();
        }
    }

    public class DivisionLayout
    {
        public Divisions Division { get; set; }
        public List<Team> Teams { get; set; }

        public DivisionLayout()
        {
            this.Teams = new List<Team>();
        }
    }
}
