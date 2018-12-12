using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
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
        public IEnumerable<ItineraryObject> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Order> UserOrders { get; set; }
        public List<IndividualFlightOutbound> IndFlightsOutbound { get; set; }
        public List<IndividualFlightInbound> IndFlightsInbound { get; set; }
        public Order CustomerOrder { get; set; }
        public List<Customer> Travelers { get; set; }

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets
                .Include(i => i.IndFlightOutbound)
                .Include(i => i.IndFlightInbound)
                .AsNoTracking().ToListAsync();

            Orders = await _context.Orders
                .Include(x => x.OrderItinerary)
                .AsNoTracking().ToListAsync();

            if (_signInManager.IsSignedIn(User))
            {
                UserOrders = await _context.Orders
                    .Include(x => x.OrderItinerary)
                     .Where(x => x.OrderItinerary.ApplicationUserId == _userManager.GetUserId(User))
                    .AsNoTracking().ToListAsync();
            }
            



        }

        public ActionResult OnPost(ItinerarySearchModel ItinerarySearch)
        {
            var order = _context.Orders.Include(x => x.OrderItinerary);
            CustomerOrder = order.Single(x => x.BookingReference == ItinerarySearch.ItineraryId);


            return Page();
        }


    }
}