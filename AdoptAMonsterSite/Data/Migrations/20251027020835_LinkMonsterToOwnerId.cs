using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptAMonsterSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkMonsterToOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Monsters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_ApplicationUserID",
                table: "Monsters",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_ApplicationUserID",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Monsters");
        }
    }
}
