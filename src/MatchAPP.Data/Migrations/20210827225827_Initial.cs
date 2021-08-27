using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchAPP.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MatchDate = table.Column<string>(nullable: false),
                    MatchTime = table.Column<string>(nullable: false),
                    TeamA = table.Column<string>(maxLength: 10, nullable: false),
                    TeamB = table.Column<string>(maxLength: 10, nullable: false),
                    Sport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchOdds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    Specifier = table.Column<string>(maxLength: 3, nullable: true),
                    Odd = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchOdds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchOdds_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDate_TeamA",
                table: "Matches",
                columns: new[] { "MatchDate", "TeamA" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDate_TeamB",
                table: "Matches",
                columns: new[] { "MatchDate", "TeamB" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDate_TeamA_TeamB",
                table: "Matches",
                columns: new[] { "MatchDate", "TeamA", "TeamB" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchOdds_MatchId",
                table: "MatchOdds",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchOdds");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
