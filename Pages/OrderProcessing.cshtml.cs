using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vancouver.FlightsFolder;
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

        public void OnGet()
        {
            var ticket = _ticketPurchaseService.GetTicketData();
            OrderObject = ticket;

        }
    }
}