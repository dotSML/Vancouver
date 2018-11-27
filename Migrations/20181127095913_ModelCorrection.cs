using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class ModelCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Customers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllCustomerTravelHistories",
                table: "AllCustomerTravelHistories");

            migrationBuilder.DropColumn(
                name: "CustomerTravelHistoryId",
                table: "AllCustomerTravelHistories");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AllCustomerTravelHistories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllCustomerTravelHistories",
                table: "AllCustomerTravelHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Customers",
                table: "AspNetUsers",
                column: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Customers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllCustomerTravelHistories",
                table: "AllCustomerTravelHistories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AllCustomerTravelHistories");

            migrationBuilder.AddColumn<int>(
                name: "CustomerTravelHistoryId",
                table: "AllCustomerTravelHistories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllCustomerTravelHistories",
                table: "AllCustomerTravelHistories",
                column: "CustomerTravelHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Customers",
                table: "AspNetUsers",
                column: "Customers",
                unique: true,
                filter: "[Customers] IS NOT NULL");
        }
    }
}
