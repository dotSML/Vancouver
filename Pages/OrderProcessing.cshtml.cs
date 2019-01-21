using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vancouver.CustomerFolder;
using Vancouver.DbContext;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class OrderProcessingModel : PageModel
    {
        public SignInManager<ApplicationUser> _signInManager;
        public UserManager<ApplicationUser> _userManager;
        private readonly ITicketPurchaseService _ticketPurchaseService;
        private VancouverDbContext _context;

        public OrderProcessingModel(ITicketPurchaseService ticketPurchaseService, 
            VancouverDbContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _ticketPurchaseService = ticketPurchaseService;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public ItineraryObject OrderObject { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Customer> SavedTravelers { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        public string RandomReference { get; set; }
        public Customer SelectedCustomer { get; set; }
        [BindProperty]
        public List<string> SavedTravelersIds { get; set; }

        public void OnGet()
        {
            var ticket = _ticketPurchaseService.GetItineraryTicketData();
            if (ticket != null)
            {
                OrderObject = ticket;
            }

            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                var savedUsers = _context.Customers.Include(x => x.Passport).Where(x => x.ApplicationUserId == userId).ToList();
                SavedTravelers = savedUsers;
            }

        }

        public ActionResult OnPost(List<Customer> customers)
        {
            var userId = "";
            if (_signInManager.IsSignedIn(User))
            {
                userId = _userManager.GetUserId(User);
                foreach (var savedTraveler in SavedTravelersIds)
                {
                    var traveler = _context.Customers.FirstOrDefault(x => x.CustomerId == savedTraveler);
                    if (traveler != null)
                    {
                        customers.Add(traveler);
                    }
                }
            }

            if (customers != null & customers?.Count > 0)
            {
                 customers = new List<Customer>(_ticketPurchaseService.CustomerCleanup(customers));
                 RandomReference = _ticketPurchaseService.GetRandomBookingRef(6);
                 while (_context.Orders.FirstOrDefault(x => x.BookingReference == RandomReference) != null)
                 {
                     RandomReference = _ticketPurchaseService.GetRandomBookingRef(6);
                 }
                 Order.OrderItinerary = _ticketPurchaseService.GetItineraryTicketData();
                 Order.BookingReference = RandomReference;
                 _ticketPurchaseService.SetOrderData(Order);
                Order.OrderItinerary.ApplicationUserId = userId;
                 _context.Orders.Add(Order);
                Order.Tickets = _ticketPurchaseService.GenerateTickets(customers, Order);
                _context.SaveChanges();
                 return RedirectToPage("OrderSuccess", Order.Id);
            }
            else
            {
               return RedirectToPage("Index");
            }
        }
    }
}