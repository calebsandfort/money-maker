using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMaker.Models
{
    #region EntityBase
    public class EntityBase
    {
        public int ID { get; set; }
    }
    #endregion

    #region NflWeek
    public class NflWeek : EntityBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        public int Number { get; set; }

        public ICollection<Game> Games { get; set; }
    }
    #endregion

    #region Team
    public class Team : EntityBase
    {
        [StringLength(50)]
        public String Name { get; set; }

        [StringLength(3)]
        public String CbsId { get; set; }

        public Leagues League { get; set; }
        public Conferences Conference { get; set; }
        public Divisions Division { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public int OffenseRank { get; set; }
        public int OffensePassingRank { get; set; }
        public int OffenseRushingRank { get; set; }

        public int DefenseRank { get; set; }
        public int DefensePassingRank { get; set; }
        public int DefenseRushingRank { get; set; }

        public int PowerRanking { get; set; }

        public ICollection<Game> AwayGames { get; set; }
        public ICollection<Game> HomeGames { get; set; }

        [NotMapped]
        private List<Game> _games;
        [NotMapped]
        public List<Game> Games
        {
            get { return _games; }
            set { _games = value; }
        }

        [NotMapped]
        public String CbsLink
        {
            get
            {
                return $"http://www.cbssports.com/nfl/teams/page/{this.CbsId}";
            }
        }
    }
    #endregion

    #region Game
    public class Game : EntityBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int AwayScore { get; set; }
        public int HomeScore { get; set; }

        public int AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }

        public int NflWeekID { get; set; }
        public NflWeek NflWeek { get; set; }

        [NotMapped]
        public GameOutcomes Outcome { get; set; }
    }
    #endregion

    #region BetLedger
    public class BetLedger : EntityBase
    {
        [StringLength(50)]
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal StartAmount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal Balance { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal InPlay { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal PotentialWinnings { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
    #endregion

    #region Bet
    public class Bet : EntityBase
    {
        [StringLength(100)]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal Risk { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Decimal Reward { get; set; }

        public BetTypes BetType { get; set; }

        public BetOutcomes Outcome { get; set; }

        public int BetLedgerID { get; set; }
        public BetLedger BetLedger { get; set; }

        public ICollection<BetTeam> Teams { get; set; }
    }
    #endregion

    #region BetTeam
    public class BetTeam
    {
        public int BetID { get; set; }
        public int TeamID { get; set; }
        public Bet Bet { get; set; }
        public Team Team { get; set; }
    } 
    #endregion
}
