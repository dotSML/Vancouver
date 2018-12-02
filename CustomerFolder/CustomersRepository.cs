using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Vancouver.Databases;

namespace Vancouver.CustomerFolder
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DbSet<Customer> dbSet;
        private readonly VancouverDbContext _context;

        public CustomersRepository(VancouverDbContext context)
        {
            _context = context;
            dbSet = context?.Customers;
        }
        public async Task<Customer> GetObject(string id)
        {
            var c = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            return new Customer();
        }
        public List<Customer> GetObjectsList()
        {
            List<Customer> listOfCustomers = new List<Customer>();
            foreach (var customer in dbSet)
            {
                listOfCustomers.Add(customer);
            }

            return listOfCustomers;
        }
        public async Task AddObject(Customer o)
        {
            dbSet.Add(o);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateObject(Customer o)
        {
            dbSet.Update(o);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteObject(Customer o)
        {
            dbSet.Remove(o);
            await _context.SaveChangesAsync();
        }

    }
}