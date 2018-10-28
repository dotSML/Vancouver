using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vancouver.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankLinkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_BankLink_BankLinkId",
                        column: x => x.BankLinkId,
                        principalTable: "BankLink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllCustomerTravelHistories",
                columns: table => new
                {
                    CustomerTravelHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(nullable: true),
                    AirportFrom = table.Column<string>(nullable: true),
                    AirportTo = table.Column<string>(nullable: true),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllCustomerTravelHistories", x => x.CustomerTravelHistoryId);
                    table.ForeignKey(
                        name: "FK_AllCustomerTravelHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    TicketId = table.Column<string>(nullable: true),
                    BankLinkId = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    Payee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_BankLink_BankLinkId",
                        column: x => x.BankLinkId,
                        principalTable: "BankLink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
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
                    Discriminator = table.Column<string>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    PaymentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllCustomerTravelHistories_CustomerId",
                table: "AllCustomerTravelHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BankLinkId",
                table: "Payment",
                column: "BankLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodId",
                table: "Payment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TicketId",
                table: "Payment",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_BankLinkId",
                table: "PaymentMethod",
                column: "BankLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PaymentID",
                table: "Tickets",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customers_CustomerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BankLink_BankLinkId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_BankLink_BankLinkId",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentMethod_PaymentMethodId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Tickets_TicketId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "AllCustomerTravelHistories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "BankLink");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
