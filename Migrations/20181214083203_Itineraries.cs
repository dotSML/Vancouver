using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class Itineraries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightInbound_Tickets_ItineraryId",
                table: "IndividualFlightInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightOutbound_Tickets_ItineraryId",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tickets_OrderItineraryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropColumn(
                name: "AmountOfPassengers",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "arrivalAirportInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "arrivalAirportOutbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "arrivalTimeInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "arrivalTimeOutbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "departureTimeInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "departureTimeOutbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "fareClass",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "fareCurrency",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "farePricePerPassenger",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "farePriceTax",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "farePriceTotal",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "layoverCitiesInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "layoverCitiesOutbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "layoverStopAmountInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "layoverStopAmountOutbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "originAirportInbound",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "originAirportOutbound",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "tripDurationOutbound",
                table: "Tickets",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "tripDurationInbound",
                table: "Tickets",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AmountOfPassengers = table.Column<int>(nullable: false),
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
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightInbound_Itineraries_ItineraryId",
                table: "IndividualFlightInbound",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualFlightOutbound_Itineraries_ItineraryId",
                table: "IndividualFlightOutbound",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Itineraries_OrderItineraryId",
                table: "Orders",
                column: "OrderItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Itineraries_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightInbound_Itineraries_ItineraryId",
                table: "IndividualFlightInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualFlightOutbound_Itineraries_ItineraryId",
                table: "IndividualFlightOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Itineraries_OrderItineraryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Itineraries_TicketId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Tickets",
                newName: "tripDurationOutbound");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Tickets",
                newName: "tripDurationInbound");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "tripDurationOutbound",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tripDurationInbound",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfPassengers",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalAirportInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalAirportOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalTimeInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalTimeOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departureTimeInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departureTimeOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fareClass",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fareCurrency",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePricePerPassenger",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePriceTax",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePriceTotal",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverCitiesInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverCitiesOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverStopAmountInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverStopAmountOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "originAirportInbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "originAirportOutbound",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderId",
                table: "Ticket",
                column: "OrderId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tickets_OrderItineraryId",
                table: "Orders",
                column: "OrderItineraryId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
