using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class IndDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "IndividualFlightOutbound",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "IndividualFlightInbound",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "IndividualFlightInbound");
        }
    }
}
