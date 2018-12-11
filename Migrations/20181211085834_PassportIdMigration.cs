using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class PassportIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Passports",
                newName: "PassportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassportId",
                table: "Passports",
                newName: "Id");
        }
    }
}
