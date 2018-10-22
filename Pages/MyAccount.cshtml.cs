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
        
        [BindProperty] public Customer Customer { get; set; }
        [BindProperty] public string FirstName { get; set; }
        [BindProperty] public string LastName { get; set; }
        public MyAccountModel(ICustomersRepository c)
        {
            customers = c;
        }
        public async Task OnGet() //string id
        {//sisse logimisel peab kuskilt tulema siia õige customeri ID mille järgi saaks uuendama jms hakata.
            if (ModelState.IsValid)
            await customers.GetObjectsList();
            var c = await customers.GetObject("001");
            c.FirstName = FirstName;
            c.LastName = LastName;
            await customers.UpdateObject(c);

        }

        public async Task OnPost()
        {
        }
    }
}