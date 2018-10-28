using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
using Vancouver.Models;

namespace Vancouver.Databases
{
    public class VancouverDbContext : DbContext
    {
        public VancouverDbContext(DbContextOptions<VancouverDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> AllSoldTickets { get; set; }
        public DbSet<CustomerTravelHistory> AllCustomerTravelHistories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
