using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class PassportRequirementMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Passport",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Passport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
