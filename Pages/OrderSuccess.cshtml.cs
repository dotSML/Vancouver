using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class OrderSuccessModel : PageModel
    {
        public Order CompletedOrder { get; set; }
        public ITicketPurchaseService _ticketPurchaseService;

        public OrderSuccessModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }
        public string Reference { get; set; }

        

        public void OnGet()
        {
            CompletedOrder = _ticketPurchaseService.GetOrderData();
            _ticketPurchaseService.ClearOrderData();


        }
    }
}