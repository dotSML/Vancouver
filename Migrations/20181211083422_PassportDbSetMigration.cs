using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class PassportDbSetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passport_PassportId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passport",
                table: "Passport");

            migrationBuilder.RenameTable(
                name: "Passport",
                newName: "Passports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passports",
                table: "Passports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Passports_PassportId",
                table: "Customers",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passports_PassportId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passports",
                table: "Passports");

            migrationBuilder.RenameTable(
                name: "Passports",
                newName: "Passport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passport",
                table: "Passport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Passport_PassportId",
                table: "Customers",
                column: "PassportId",
                principalTable: "Passport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
