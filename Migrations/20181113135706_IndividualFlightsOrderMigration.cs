using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class IndividualFlightsOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderPos",
                table: "IndividualFlightOutbound",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderPos",
                table: "IndividualFlightInbound",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderPos",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropColumn(
                name: "orderPos",
                table: "IndividualFlightInbound");
        }
    }
}
