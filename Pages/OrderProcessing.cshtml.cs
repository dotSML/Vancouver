using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class OrderProcessingModel : PageModel
    {
        private readonly ITicketPurchaseService _ticketPurchaseService;

        public OrderProcessingModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }

        public ItineraryObject OrderObject { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }

        public void OnGet()
        {
            var ticket = _ticketPurchaseService.GetTicketData();
            if (ticket != null)
            {
                OrderObject = ticket;
            }
        }



        public void OnPost(Order PostOrder)
        {

        }
    }
}