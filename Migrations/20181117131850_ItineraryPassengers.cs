using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class ItineraryPassengers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Ticket_TicketId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Payment_PaymentID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_ApplicationUserId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ApplicationUserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "arrivalAirportInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "arrivalAirportOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "arrivalTimeInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "arrivalTimeOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "departureTimeInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "departureTimeOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "fareClass",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "fareCurrency",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "farePricePerPassenger",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "farePriceTax",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "farePriceTotal",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "layoverCitiesInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "layoverCitiesOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "layoverStopAmountInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "layoverStopAmountOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "originAirportInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "originAirportOutbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "tripDurationInbound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "tripDurationOutbound",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "AllSoldTickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_PaymentID",
                table: "AllSoldTickets",
                newName: "IX_AllSoldTickets_PaymentID");

            migrationBuilder.AddColumn<int>(
                name: "AmountOfPassengers",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "AllSoldTickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllSoldTickets",
                table: "AllSoldTickets",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllSoldTickets_Payment_PaymentID",
                table: "AllSoldTickets",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllSoldTickets_Payment_PaymentID",
                table: "AllSoldTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllSoldTickets",
                table: "AllSoldTickets");

            migrationBuilder.DropColumn(
                name: "AmountOfPassengers",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "AllSoldTickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_AllSoldTickets_PaymentID",
                table: "Ticket",
                newName: "IX_Ticket_PaymentID");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "TicketId",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arrivalAirportInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalAirportOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalTimeInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrivalTimeOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departureTimeInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departureTimeOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fareClass",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fareCurrency",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePricePerPassenger",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePriceTax",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "farePriceTotal",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverCitiesInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverCitiesOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverStopAmountInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "layoverStopAmountOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "originAirportInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "originAirportOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tripDurationInbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tripDurationOutbound",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Payment_PaymentID",
                table: "Ticket",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_ApplicationUserId",
                table: "Ticket",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
