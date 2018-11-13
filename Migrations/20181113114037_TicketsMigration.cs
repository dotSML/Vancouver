using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class TicketsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Payment_PaymentID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PaymentID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "IndividualFlightInbound",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    departs_at = table.Column<string>(nullable: true),
                    arrives_at = table.Column<string>(nullable: true),
                    originInd = table.Column<string>(nullable: true),
                    destinationInd = table.Column<string>(nullable: true),
                    marketing_airline = table.Column<string>(nullable: true),
                    operating_airline = table.Column<string>(nullable: true),
                    flight_number = table.Column<string>(nullable: true),
                    aircraft = table.Column<string>(nullable: true),
                    travel_class = table.Column<string>(nullable: true),
                    booking_code = table.Column<string>(nullable: true),
                    seats_remaining = table.Column<int>(nullable: false),
                    ItineraryObjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualFlightInbound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualFlightInbound_Tickets_ItineraryObjectId",
                        column: x => x.ItineraryObjectId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualFlightOutbound",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    departs_at = table.Column<string>(nullable: true),
                    arrives_at = table.Column<string>(nullable: true),
                    originInd = table.Column<string>(nullable: true),
                    destinationInd = table.Column<string>(nullable: true),
                    marketing_airline = table.Column<string>(nullable: true),
                    operating_airline = table.Column<string>(nullable: true),
                    flight_number = table.Column<string>(nullable: true),
                    aircraft = table.Column<string>(nullable: true),
                    travel_class = table.Column<string>(nullable: true),
                    booking_code = table.Column<string>(nullable: true),
                    seats_remaining = table.Column<int>(nullable: false),
                    ItineraryObjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualFlightOutbound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualFlightOutbound_Tickets_ItineraryObjectId",
                        column: x => x.ItineraryObjectId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    departureTimeOutbound = table.Column<string>(nullable: true),
                    departureTimeInbound = table.Column<string>(nullable: true),
                    originAirportOutbound = table.Column<string>(nullable: true),
                    originAirportInbound = table.Column<string>(nullable: true),
                    tripDurationOutbound = table.Column<string>(nullable: true),
                    tripDurationInbound = table.Column<string>(nullable: true),
                    layoverStopAmountOutbound = table.Column<string>(nullable: true),
                    layoverStopAmountInbound = table.Column<string>(nullable: true),
                    layoverCitiesOutbound = table.Column<string>(nullable: true),
                    layoverCitiesInbound = table.Column<string>(nullable: true),
                    arrivalTimeOutbound = table.Column<string>(nullable: true),
                    arrivalTimeInbound = table.Column<string>(nullable: true),
                    arrivalAirportOutbound = table.Column<string>(nullable: true),
                    arrivalAirportInbound = table.Column<string>(nullable: true),
                    farePricePerPassenger = table.Column<string>(nullable: true),
                    fareClass = table.Column<string>(nullable: true),
                    fareCurrency = table.Column<string>(nullable: true),
                    farePriceTax = table.Column<string>(nullable: true),
                    farePriceTotal = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    PaymentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualFlightInbound_ItineraryObjectId",
                table: "IndividualFlightInbound",
                column: "ItineraryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualFlightOutbound_ItineraryObjectId",
                table: "IndividualFlightOutbound",
                column: "ItineraryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PaymentID",
                table: "Ticket",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ApplicationUserId",
                table: "Ticket",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Ticket_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Ticket_TicketId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "IndividualFlightInbound");

            migrationBuilder.DropTable(
                name: "IndividualFlightOutbound");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PaymentID",
                table: "Tickets",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicationUserId",
                table: "Tickets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Payment_PaymentID",
                table: "Tickets",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ApplicationUserId",
                table: "Tickets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
