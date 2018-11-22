using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public class ItinerarySearchModel
        {
            public string ItineraryId { get; set; }
            public string LastName { get; set; }
        }

        [BindProperty]
        public ItinerarySearchModel ItinerarySearch { get; set; }
        public IEnumerable<ItineraryObject> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public List<IndividualFlightOutbound> IndFlightsOutbound { get; set; }
        public List<IndividualFlightInbound> IndFlightsInbound { get; set; }
        public Order CustomerOrder { get; set; }

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets
                .Include(i => i.IndFlightOutbound)
                .Include(i => i.IndFlightInbound)
                .AsNoTracking().ToListAsync();

            Orders = await _context.Orders
                .Include(x => x.OrderItinerary)
                .Include(x => x.Customer)
                .AsNoTracking().ToListAsync();




        }

        public ActionResult OnPost(ItinerarySearchModel ItinerarySearch)
        {
            var order = _context.Orders.Include(x => x.OrderItinerary).Include(x => x.Customer);
            CustomerOrder = order.Single(x => x.OrderItinerary.Id == ItinerarySearch.ItineraryId);


            return Page();
        }


    }
}