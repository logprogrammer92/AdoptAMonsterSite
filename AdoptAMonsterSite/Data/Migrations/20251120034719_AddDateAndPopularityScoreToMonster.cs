using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptAMonsterSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDateAndPopularityScoreToMonster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Monsters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PopularityScore",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "PopularityScore",
                table: "Monsters");
        }
    }
}
