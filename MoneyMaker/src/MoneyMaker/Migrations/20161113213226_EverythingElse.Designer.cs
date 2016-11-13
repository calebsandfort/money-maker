using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MoneyMaker.Data;

namespace MoneyMaker.Migrations
{
    [DbContext(typeof(MoneyMakerContext))]
    [Migration("20161113213226_EverythingElse")]
    partial class EverythingElse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyMaker.Models.Bet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BetLedgerID");

                    b.Property<int>("BetType");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Outcome");

                    b.Property<decimal>("Reward");

                    b.Property<decimal>("Risk");

                    b.HasKey("ID");

                    b.HasIndex("BetLedgerID");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("MoneyMaker.Models.BetLedger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<decimal>("InPlay");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("PotentialWinnings");

                    b.Property<decimal>("StartAmount");

                    b.HasKey("ID");

                    b.ToTable("BetLedgers");
                });

            modelBuilder.Entity("MoneyMaker.Models.BetTeam", b =>
                {
                    b.Property<int>("BetID");

                    b.Property<int>("TeamID");

                    b.HasKey("BetID", "TeamID");

                    b.HasIndex("BetID");

                    b.HasIndex("TeamID");

                    b.ToTable("BetTeams");
                });

            modelBuilder.Entity("MoneyMaker.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwayScore");

                    b.Property<int>("AwayTeamID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HomeScore");

                    b.Property<int>("HomeTeamID");

                    b.Property<int>("NflWeekID");

                    b.HasKey("ID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("HomeTeamID");

                    b.HasIndex("NflWeekID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MoneyMaker.Models.NflWeek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<int>("Number");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.ToTable("NflWeeks");
                });

            modelBuilder.Entity("MoneyMaker.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CbsId")
                        .HasAnnotation("MaxLength", 3);

                    b.Property<int>("Conference");

                    b.Property<int>("DefensePassingRank");

                    b.Property<int>("DefenseRank");

                    b.Property<int>("DefenseRushingRank");

                    b.Property<int>("Division");

                    b.Property<int>("League");

                    b.Property<int>("Losses");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("OffensePassingRank");

                    b.Property<int>("OffenseRank");

                    b.Property<int>("OffenseRushingRank");

                    b.Property<int>("PowerRanking");

                    b.Property<int>("Ties");

                    b.Property<int>("Wins");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MoneyMaker.Models.Bet", b =>
                {
                    b.HasOne("MoneyMaker.Models.BetLedger", "BetLedger")
                        .WithMany("Bets")
                        .HasForeignKey("BetLedgerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyMaker.Models.BetTeam", b =>
                {
                    b.HasOne("MoneyMaker.Models.Bet", "Bet")
                        .WithMany("Teams")
                        .HasForeignKey("BetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoneyMaker.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyMaker.Models.Game", b =>
                {
                    b.HasOne("MoneyMaker.Models.Team", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamID");

                    b.HasOne("MoneyMaker.Models.Team", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamID");

                    b.HasOne("MoneyMaker.Models.NflWeek", "NflWeek")
                        .WithMany("Games")
                        .HasForeignKey("NflWeekID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
