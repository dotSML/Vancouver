using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class TerminalsIndFlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "terminalDes",
                table: "IndividualFlightOutbound",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "terminalOrg",
                table: "IndividualFlightOutbound",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "terminalDes",
                table: "IndividualFlightInbound",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "terminalOrg",
                table: "IndividualFlightInbound",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "terminalDes",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropColumn(
                name: "terminalOrg",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropColumn(
                name: "terminalDes",
                table: "IndividualFlightInbound");

            migrationBuilder.DropColumn(
                name: "terminalOrg",
                table: "IndividualFlightInbound");
        }
    }
}
