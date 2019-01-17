using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Vancouver.DbContext;
using Vancouver.Models;

namespace Vancouver.CustomerFolder
{
    public static class CustomersDbTableInitializer
    {
        public static void Initialize(VancouverDbContext c)
        {
            c.Database.EnsureCreated();
            if (!c.Customers.Any())
            {
                c.Customers.Add(new Customer
                {
                    CustomerId = Guid.NewGuid().ToString(),
                    FirstName = "Anna",
                    LastName = "Allik"
                });
                c.Customers.Add(new Customer
                {
                    CustomerId = Guid.NewGuid().ToString(),
                    FirstName = "Mati",
                    LastName = "Mesi"
                });
                c.Customers.Add(new Customer
                {
                    CustomerId = Guid.NewGuid().ToString(),
                    FirstName = "Kati",
                    LastName = "Kaev"
                });
            }


            c.SaveChanges();

        }
    }
}