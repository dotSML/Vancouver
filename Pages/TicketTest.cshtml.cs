using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class TicketTestModel : PageModel
    {
        public VancouverDbContext _context { get; set; }

        public TicketTestModel(VancouverDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Ticket Ticket { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets.AsNoTracking().ToListAsync();
        }

        public async Task OnDeleteDeleteTicket()
        {

        }
    }
}