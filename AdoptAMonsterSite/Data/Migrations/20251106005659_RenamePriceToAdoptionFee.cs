using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptAMonsterSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePriceToAdoptionFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Monsters",
                newName: "AdoptionFee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdoptionFee",
                table: "Monsters",
                newName: "Price");
        }
    }
}
