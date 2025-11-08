using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptAMonsterSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingImageFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Monsters");
        }
    }
}
