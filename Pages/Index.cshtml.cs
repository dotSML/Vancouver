using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Vancouver.Databases;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VancouverDbContext _context;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        private readonly IFlightsObjectsRepository _flightsRepository;
        private readonly ITicketPurchaseService _ticketPurchaseService;
        private IConfiguration _config;
        
        
        public class FlightInputModel
        {
            [Required]
            [MaxLength(3)]
            public string Origin { get; set; }
            [Required]
            [MaxLength(3)]
            public string Destination { get; set; }
            [Required]
            public string OutboundDate { get; set; }
            public string InboundDate { get; set; }
            [Required]
            public string AmountOfPassengers { get; set; }
            [Required]
            public string TravelClass { get; set; }
            [Required]
            public string Currency { get; set; }
            [Required]
            public string FareOption { get; set; }
        }

        [BindProperty]
        public FlightInputModel FlightInput { get; set; }

        public string Error { get; set; }
        public IEnumerable<ItineraryObject> ItineraryList { get; set; }
        


        public IndexModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IConfiguration config, 
            IFlightsObjectsRepository flightsRepository,
            ITicketPurchaseService ticketPurchaseService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _flightsRepository = flightsRepository;
            _ticketPurchaseService = ticketPurchaseService;
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var itineraryResponse = await _flightsRepository.GetObjectsList(FlightInput.Origin,
                    FlightInput.Destination,
                    FlightInput.OutboundDate, FlightInput.InboundDate, FlightInput.AmountOfPassengers,
                    FlightInput.TravelClass, FlightInput.Currency);
                if (itineraryResponse != null)
                {
                    ItineraryList = new List<ItineraryObject>(itineraryResponse);
                    return Page();
                }
                else
                {
                    Error = "No results found, please try again!";
                    return Page();
                }
            }

            return Page();
        }

        public void OnGet()
        {
        }

        public ActionResult OnPostItineraryOrder(ItineraryObject postObject)
        {
             var itinerary = postObject;
             _ticketPurchaseService.SetItineraryTicketData(itinerary);
             return RedirectToPage("OrderProcessing");
            
        }

        
        
    }

    
}

