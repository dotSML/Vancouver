using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;

        public TicketTestModel(VancouverDbContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class ItinerarySearchModel
        {
            public string ItineraryId { get; set; }
            public string LastName { get; set; }
        }

        [BindProperty]
        public ItinerarySearchModel ItinerarySearch { get; set; }
        public IEnumerable<ItineraryObject> Itineraries { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Order> UserOrders { get; set; }
        public List<IndividualFlightOutbound> IndFlightsOutbound { get; set; }
        public List<IndividualFlightInbound> IndFlightsInbound { get; set; }
        public List<Order> CustomerOrders { get; set; }

        public async Task OnGetAsync()
        {
            Itineraries = await _context.Itineraries
                .Include(i => i.IndFlightOutbound)
                .Include(i => i.IndFlightInbound)
                .AsNoTracking().ToListAsync();

            Orders = await _context.Orders
                .Include(x => x.OrderItinerary)
                //.Include(x => x.Customer)
                .AsNoTracking().ToListAsync();

            if (_signInManager.IsSignedIn(User))
            {
                UserOrders = await _context.Orders
                    .Include(x => x.OrderItinerary)
                    .Include(x => x.Tickets).ThenInclude(x => x.Customer).Where(x => x.OrderItinerary.ApplicationUserId == _userManager.GetUserId(User))
                    .AsNoTracking().ToListAsync();

                var userTickets = await _context.Tickets
                    .Include(x => x.Customer).ToListAsync();
            }
            



        }

        public ActionResult OnPost(ItinerarySearchModel ItinerarySearch)
        {
            var order = _context.Orders.Include(x => x.Tickets).ThenInclude(x => x.Customer).Include(x => x.OrderItinerary);
            CustomerOrders = order.Where(x => x.BookingReference == ItinerarySearch.ItineraryId).ToList();


            return Page();
        }


    }
}