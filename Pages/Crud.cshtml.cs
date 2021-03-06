﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
using Vancouver.DbContext;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class CrudModel : PageModel
    {
        private readonly ICustomersRepository customers;
        private readonly VancouverDbContext _context;

        [BindProperty(SupportsGet = true)]
        public Customer Customer { get; set; }
        //[BindProperty] public List<Customer> Customers { get; set; }
        public IList<Customer> Customers { get; private set; }

        public CrudModel(VancouverDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            return RedirectToPage("/MyAccount");
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}