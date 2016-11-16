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
        #region Properties
        [StringLength(50)]
        public String Name { get; set; }

        [StringLength(3)]
        public String CbsId { get; set; }

        public Leagues League { get; set; }

        [Display(Name = "Conf")]
        public Conferences Conference { get; set; }

        [Display(Name = "Div")]
        public Divisions Division { get; set; }

        [Range(1, 16)]
        public int Wins { get; set; }

        [Range(1, 16)]
        public int Losses { get; set; }

        [Range(1, 16)]
        public int Ties { get; set; }

        [Range(1, 16)]
        [Display(Name = "Exp Wins")]
        public int ExpectedWins { get; set; }

        [Range(1, 16)]
        [Display(Name = "Exp Losses")]
        public int ExpectedLosses { get; set; }

        [Range(1, 16)]
        [Display(Name = "Exp Ties")]
        public int ExpectedTies { get; set; }

        [Display(Name = "O")]
        public int OffenseRank { get; set; }

        [Display(Name = "O-Pass")]
        public int OffensePassingRank { get; set; }

        [Display(Name = "O-Rush")]
        public int OffenseRushingRank { get; set; }

        [Display(Name = "D")]
        public int DefenseRank { get; set; }

        [Display(Name = "D-Pass")]
        public int DefensePassingRank { get; set; }

        [Display(Name = "D-Rush")]
        public int DefenseRushingRank { get; set; }

        public int PowerRanking { get; set; }

        public ICollection<Game> AwayGames { get; set; }
        public ICollection<Game> HomeGames { get; set; }

        [NotMapped]
        private List<Game> _games;
        [NotMapped]
        public List<Game> Games
        {
            get
            {
                if (this._games == null)
                {
                    _games = new List<Game>(this.AwayGames);
                    _games.AddRange(this.HomeGames);
                }
                return _games;
            }
        }

        [NotMapped]
        public String CbsLink
        {
            get
            {
                return $"http://www.cbssports.com/nfl/teams/page/{this.CbsId}";
            }
        }

        [NotMapped]
        public String CbsLogo
        {
            get
            {
                return $"http://sports.cbsimg.net/images/nfl/logos/30x30/{this.CbsId}.png";
            }
        }

        [NotMapped]
        public String Record
        {
            get
            {
                return $"{this.Wins} - {this.Losses} - {this.Ties}";
            }
        }

        [NotMapped]
        [Display(Name = "Exp Rec")]
        public String ExpectedRecord
        {
            get
            {
                return $"{this.ExpectedWins} - {this.ExpectedLosses} - {this.ExpectedTies}";
            }
        }
        #endregion

        #region Methods
        public void SyncRecord()
        {
            this.Wins = 0;
            this.Losses = 0;
            this.Ties = 0;

            foreach(Game game in this.Games.Where(x => x.Played))
            {
                if((game.AwayTeamID == this.ID && game.AwayScore > game.HomeScore)
                    || (game.HomeTeamID == this.ID && game.HomeScore > game.AwayScore))
                {
                    this.Wins += 1;
                }
                else if ((game.AwayTeamID == this.ID && game.AwayScore < game.HomeScore)
                    || (game.HomeTeamID == this.ID && game.HomeScore < game.AwayScore))
                {
                    this.Losses += 1;
                }
                else if (game.AwayScore == game.HomeScore)
                {
                    this.Ties += 1;
                }
            }
        }
        #endregion
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
        public bool Played { get; set; }

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
