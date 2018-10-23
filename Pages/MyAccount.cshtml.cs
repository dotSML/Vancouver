using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class MyAccountModel : PageModel
    {
        private readonly ICustomersRepository customers;
        private readonly TestDbContext db;
        
        [BindProperty(SupportsGet = true)] public Customer Customer { get; set; }
        //[BindProperty] public List<Customer> Customers { get; set; }
        public IList<Customer> Customers { get; private set; }

        public MyAccountModel(TestDbContext dataBase)
        {
            db = dataBase;
        }
        //public void OnGet() //string id
        //{
          
        //}

        //public void OnPost(List<Customer> customersFromPage)
        //{
        //    Customers = customersFromPage;
        //}
        public async Task OnGetAsync()
        {
            Customers = await db.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Customers.Add(Customer);
            await db.SaveChangesAsync();
            return RedirectToPage("/MyAccount");
        }
        //public async Task<IActionResult> OnPostDeleteAsync(int id)
        //{
        //    var contact = await db.Customers.FindAsync(id);

        //    if (contact != null)
        //    {
        //        db.Customers.Remove(contact);
        //        await db.SaveChangesAsync();
        //    }

        //    return RedirectToPage();
        //}
    }
}