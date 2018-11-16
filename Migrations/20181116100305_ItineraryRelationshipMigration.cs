using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class ItineraryRelationshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightInbound_Tickets_ItineraryObjectId",
                table: "IndividualFlightInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightOutbound_Tickets_ItineraryObjectId",
                table: "IndividualFlightOutbound");

            migrationBuilder.RenameColumn(
                name: "ItineraryObjectId",
                table: "IndividualFlightOutbound",
                newName: "ItineraryId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualFlightOutbound_ItineraryObjectId",
                table: "IndividualFlightOutbound",
                newName: "IX_IndividualFlightOutbound_ItineraryId");

            migrationBuilder.RenameColumn(
                name: "ItineraryObjectId",
                table: "IndividualFlightInbound",
                newName: "ItineraryId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualFlightInbound_ItineraryObjectId",
                table: "IndividualFlightInbound",
                newName: "IX_IndividualFlightInbound_ItineraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightInbound_Tickets_ItineraryId",
                table: "IndividualFlightInbound",
                column: "ItineraryId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightOutbound_Tickets_ItineraryId",
                table: "IndividualFlightOutbound",
                column: "ItineraryId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightInbound_Tickets_ItineraryId",
                table: "IndividualFlightInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightOutbound_Tickets_ItineraryId",
                table: "IndividualFlightOutbound");

            migrationBuilder.RenameColumn(
                name: "ItineraryId",
                table: "IndividualFlightOutbound",
                newName: "ItineraryObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualFlightOutbound_ItineraryId",
                table: "IndividualFlightOutbound",
                newName: "IX_IndividualFlightOutbound_ItineraryObjectId");

            migrationBuilder.RenameColumn(
                name: "ItineraryId",
                table: "IndividualFlightInbound",
                newName: "ItineraryObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualFlightInbound_ItineraryId",
                table: "IndividualFlightInbound",
                newName: "IX_IndividualFlightInbound_ItineraryObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightInbound_Tickets_ItineraryObjectId",
                table: "IndividualFlightInbound",
                column: "ItineraryObjectId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightOutbound_Tickets_ItineraryObjectId",
                table: "IndividualFlightOutbound",
                column: "ItineraryObjectId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
