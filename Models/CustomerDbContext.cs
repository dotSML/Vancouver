using Microsoft.EntityFrameworkCore;


namespace Vancouver.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> o) : base(o)
        {
          
        }
        public DbSet<Customer> Customers { get; set; }
    }
}