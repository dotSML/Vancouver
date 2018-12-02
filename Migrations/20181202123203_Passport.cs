using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class Passport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passport_Customers_Customers",
                table: "Passport");

            migrationBuilder.DropIndex(
                name: "IX_Passport_Customers",
                table: "Passport");

            migrationBuilder.DropColumn(
                name: "Customers",
                table: "Passport");

            migrationBuilder.AddColumn<string>(
                name: "PassportId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PassportId",
                table: "Customers",
                column: "PassportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Passport_PassportId",
                table: "Customers",
                column: "PassportId",
                principalTable: "Passport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passport_PassportId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PassportId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Customers",
                table: "Passport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passport_Customers",
                table: "Passport",
                column: "Customers",
                unique: true,
                filter: "[Customers] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Passport_Customers_Customers",
                table: "Passport",
                column: "Customers",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
