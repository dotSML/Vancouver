using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Vancouver.DbContext;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class MyTicketsModel : PageModel
    {
        public VancouverDbContext _context;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        private readonly IAirportInfoService _airportInfoService; 

        public MyTicketsModel(VancouverDbContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAirportInfoService airportInfoService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _airportInfoService = airportInfoService;
        }

        public class ItinerarySearchModel
        {
            public string ItineraryId { get; set; }
            public string LastName { get; set; }
        }

        [BindProperty]
        public ItinerarySearchModel ItinerarySearch { get; set; }
        public Order OrderToAdd { get; set; }
        public IEnumerable<Order> UserOrders { get; set; }
        public List<Order> CustomerOrders { get; set; }

        public async Task OnGetAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                UserOrders = await _context.Orders
                    .Include(x => x.OrderItinerary)
                    .Include(x => x.Tickets).ThenInclude(x => x.Customer)
                    .Include(x => x.OrderItinerary)
                    .ThenInclude(x => x.IndFlightOutbound)
                    .Include(x => x.OrderItinerary)
                    .ThenInclude(x => x.IndFlightInbound)
                    .Where(x => x.OrderItinerary.ApplicationUserId == _userManager.GetUserId(User))
                    .AsNoTracking().OrderBy(x => x.OrderItinerary.departureTimeOutbound).ToListAsync();
            }
        }

        public ActionResult OnPost(ItinerarySearchModel ItinerarySearch)
        {
            var order = _context.Orders.Include(x => x.Tickets).ThenInclude(x => x.Customer).Include(x => x.OrderItinerary);
            CustomerOrders = order.Include(x => x.Tickets).ThenInclude(x => x.Customer)
                .Include(x => x.OrderItinerary).ThenInclude(x => x.IndFlightOutbound)
                .Include(x => x.OrderItinerary).ThenInclude(x => x.IndFlightInbound)
                .Where(x => x.BookingReference == ItinerarySearch.ItineraryId).ToList();
            return Page();
        }

        public ActionResult OnPostTripToAccount(ItinerarySearchModel ItinerarySearch)
        {
            var orders = _context.Orders.Include(x => x.Tickets).ThenInclude(x => x.Customer).Include(x => x.OrderItinerary);
            var userId = _userManager.GetUserId(User);
            OrderToAdd = orders.FirstOrDefault(x => x.BookingReference == ItinerarySearch.ItineraryId);

            if (OrderToAdd != null && !_context.Orders.Any(o => o.BookingReference == OrderToAdd.BookingReference))
            {
                OrderToAdd.OrderItinerary.ApplicationUserId = userId;
                _context.Orders.Update(OrderToAdd);
                _context.SaveChanges();
            }

            return RedirectToPage("/tickettest");
        }


    }
}