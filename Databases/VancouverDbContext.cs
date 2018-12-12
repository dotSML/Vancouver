﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Databases
{
    public class VancouverDbContext : IdentityDbContext<ApplicationUser>
    {
        public VancouverDbContext(DbContextOptions<VancouverDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> AllSoldTickets { get; set; }
        public DbSet<UserTravelHistory> AllCustomerTravelHistories { get; set; }
        public DbSet<ItineraryObject> Tickets { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAssignment> OrderAssignments { get; set; }
        public DbSet<Passport> Passports { get; set; }

        
    }
}
