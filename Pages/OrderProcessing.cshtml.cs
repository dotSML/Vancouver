using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vancouver.CustomerFolder;
using Vancouver.Databases;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class OrderProcessingModel : PageModel
    {
        private readonly ITicketPurchaseService _ticketPurchaseService;
        private VancouverDbContext _context;

        public OrderProcessingModel(ITicketPurchaseService ticketPurchaseService, VancouverDbContext context)
        {
            _ticketPurchaseService = ticketPurchaseService;
            _context = context;
        }

        


        [BindProperty]
        public ItineraryObject OrderObject { get; set; }
        public List<Customer> Customers { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        public string RandomReference { get; set; }

        public void OnGet()
        {
            var ticket = _ticketPurchaseService.GetItineraryTicketData();
            if (ticket != null)
            {
                OrderObject = ticket;
            }
        }
        


        public ActionResult OnPost(List<Customer> customers)
        {
            if (customers != null)
            {
                Order.Customer = new List<Customer>(customers);
                RandomReference = _ticketPurchaseService.GetRandomBookingRef(6);
                while (_context.Orders.FirstOrDefault(x => x.BookingReference == RandomReference) != null)
                {
                    RandomReference = _ticketPurchaseService.GetRandomBookingRef(6);
                }
                Order.OrderItinerary = _ticketPurchaseService.GetItineraryTicketData();
                Order.BookingReference = RandomReference;
                _ticketPurchaseService.SetOrderData(Order);
                _context.Orders.Add(Order);
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