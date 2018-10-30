﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vancouver.Databases;

namespace Vancouver.Migrations
{
    [DbContext(typeof(VancouverDbContext))]
    [Migration("20181030170827_TicketTestContext")]
    partial class TicketTestContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vancouver.CustomerFolder.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Vancouver.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Vancouver.Models.BankLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("BankLink");
                });

            modelBuilder.Entity("Vancouver.Models.CustomerTravelHistory", b =>
                {
                    b.Property<int>("CustomerTravelHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportFrom");

                    b.Property<string>("AirportTo");

                    b.Property<DateTime>("ArrivalDateTime");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("DepartureDateTime");

                    b.HasKey("CustomerTravelHistoryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AllCustomerTravelHistories");
                });

            modelBuilder.Entity("Vancouver.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankLinkId");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Payee");

                    b.Property<int?>("PaymentMethodId");

                    b.Property<string>("TicketId");

                    b.Property<string>("TotalPrice");

                    b.HasKey("PaymentID");

                    b.HasIndex("BankLinkId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("TicketId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Vancouver.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankLinkId");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("BankLinkId");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("Vancouver.Models.Ticket", b =>
                {
                    b.Property<string>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("arrivalAirportInbound");

                    b.Property<string>("arrivalAirportOutbound");

                    b.Property<string>("arrivalTimeInbound");

                    b.Property<string>("arrivalTimeOutbound");

                    b.Property<string>("departureTimeInbound");

                    b.Property<string>("departureTimeOutbound");

                    b.Property<string>("fareClass");

                    b.Property<string>("fareCurrency");

                    b.Property<string>("farePricePerPassenger");

                    b.Property<string>("farePriceTax");

                    b.Property<string>("farePriceTotal");

                    b.Property<string>("layoverCitiesInbound");

                    b.Property<string>("layoverCitiesOutbound");

                    b.Property<string>("layoverStopAmountInbound");

                    b.Property<string>("layoverStopAmountOutbound");

                    b.Property<string>("originAirportInbound");

                    b.Property<string>("originAirportOutbound");

                    b.Property<string>("tripDurationInbound");

                    b.Property<string>("tripDurationOutbound");

                    b.HasKey("TicketId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Tickets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ticket");
                });

            modelBuilder.Entity("Vancouver.Models.Invoice", b =>
                {
                    b.HasBaseType("Vancouver.Models.Ticket");

                    b.Property<int>("InvoiceID");

                    b.Property<int?>("PaymentID");

                    b.HasIndex("PaymentID");

                    b.ToTable("Invoice");

                    b.HasDiscriminator().HasValue("Invoice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Vancouver.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Vancouver.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vancouver.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Vancouver.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vancouver.Models.CustomerTravelHistory", b =>
                {
                    b.HasOne("Vancouver.CustomerFolder.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Vancouver.Models.Payment", b =>
                {
                    b.HasOne("Vancouver.Models.BankLink", "BankLink")
                        .WithMany()
                        .HasForeignKey("BankLinkId");

                    b.HasOne("Vancouver.CustomerFolder.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Vancouver.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId");

                    b.HasOne("Vancouver.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("Vancouver.Models.PaymentMethod", b =>
                {
                    b.HasOne("Vancouver.Models.BankLink", "BankLink")
                        .WithMany()
                        .HasForeignKey("BankLinkId");
                });

            modelBuilder.Entity("Vancouver.Models.Ticket", b =>
                {
                    b.HasOne("Vancouver.Models.ApplicationUser", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Vancouver.Models.Invoice", b =>
                {
                    b.HasOne("Vancouver.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentID");
                });
#pragma warning restore 612, 618
        }
    }
}
