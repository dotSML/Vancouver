using System;
using System.Collections.Generic;
using Vancouver.Databases;

namespace Vancouver.CustomerFolder
{
    public static class CustomersDbTableInitializer
    {
        public static void Initialize(VancouverDbContext c)
        {
            c.Database.EnsureCreated();
            c.Customers.Add(new Customer
            {
                CustomerId = "001",
                FirstName = "Anna",
                LastName = "Allik"
            });
            c.Customers.Add(new Customer
            {
                CustomerId = "002",
                FirstName = "Mati",
                LastName = "Mesi"
            });
            c.Customers.Add(new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                FirstName = "Kati",
                LastName = "Kaev"
            });

            //    foreach (var customer in c.Customers)
            //    {
            //        var x = new Customer
            //        {
            //            CustomerId = customer.CustomerId,
            //            FirstName = customer.FirstName,
            //            LastName = customer.LastName
            //        };
            //        c.Customers.Add(x);
            //    }

            c.SaveChanges();

        }
    }
}