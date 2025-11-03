using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptAMonsterSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class MonsterApplicationUserNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Monsters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Monsters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_AspNetUsers_ApplicationUserID",
                table: "Monsters",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
