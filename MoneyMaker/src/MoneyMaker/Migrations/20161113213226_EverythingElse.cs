using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoneyMaker.Migrations
{
    public partial class EverythingElse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetLedgers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false),
                    InPlay = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PotentialWinnings = table.Column<decimal>(nullable: false),
                    StartAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetLedgers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CbsId = table.Column<string>(maxLength: 3, nullable: true),
                    Conference = table.Column<int>(nullable: false),
                    DefensePassingRank = table.Column<int>(nullable: false),
                    DefenseRank = table.Column<int>(nullable: false),
                    DefenseRushingRank = table.Column<int>(nullable: false),
                    Division = table.Column<int>(nullable: false),
                    League = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    OffensePassingRank = table.Column<int>(nullable: false),
                    OffenseRank = table.Column<int>(nullable: false),
                    OffenseRushingRank = table.Column<int>(nullable: false),
                    PowerRanking = table.Column<int>(nullable: false),
                    Ties = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BetLedgerID = table.Column<int>(nullable: false),
                    BetType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Outcome = table.Column<int>(nullable: false),
                    Reward = table.Column<decimal>(nullable: false),
                    Risk = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bets_BetLedgers_BetLedgerID",
                        column: x => x.BetLedgerID,
                        principalTable: "BetLedgers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayScore = table.Column<int>(nullable: false),
                    AwayTeamID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    HomeTeamID = table.Column<int>(nullable: false),
                    NflWeekID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamID",
                        column: x => x.AwayTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_NflWeeks_NflWeekID",
                        column: x => x.NflWeekID,
                        principalTable: "NflWeeks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetTeams",
                columns: table => new
                {
                    BetID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetTeams", x => new { x.BetID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_BetTeams_Bets_BetID",
                        column: x => x.BetID,
                        principalTable: "Bets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetTeams_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BetLedgerID",
                table: "Bets",
                column: "BetLedgerID");

            migrationBuilder.CreateIndex(
                name: "IX_BetTeams_BetID",
                table: "BetTeams",
                column: "BetID");

            migrationBuilder.CreateIndex(
                name: "IX_BetTeams_TeamID",
                table: "BetTeams",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamID",
                table: "Games",
                column: "AwayTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamID",
                table: "Games",
                column: "HomeTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_NflWeekID",
                table: "Games",
                column: "NflWeekID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetTeams");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "BetLedgers");
        }
    }
}
