using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.Databases;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class TicketTestModel : PageModel
    {
        public VancouverDbContext _context;

        public TicketTestModel(VancouverDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public IEnumerable<ItineraryObject> Tickets { get; set; }
        public List<IndividualFlightOutbound> IndFlightsOutbound { get; set; }
        public List<IndividualFlightInbound> IndFlightsInbound { get; set; }

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets
                .Include(i => i.IndFlightOutbound)
                .Include(i => i.IndFlightInbound)
                .AsNoTracking().ToListAsync();
            
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {

            var ticket = _context.Tickets
                .Include(b => b.IndFlightOutbound)
                .Include(b => b.IndFlightInbound)
                .FirstOrDefault(b => b.Id == id);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }



            return RedirectToPage();
        }

        
    }
}