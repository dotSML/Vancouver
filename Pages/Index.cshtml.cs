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

namespace Vancouver.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VancouverDbContext _context;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        private readonly IFlightsObjectsRepository _flightsRepository;
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

        public List<FlightObjectsList> ObjectList { get; set; }

        public IEnumerable<ItineraryObject> ItineraryList { get; set; }

        public IndexModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config, IFlightsObjectsRepository flightsRepository)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _flightsRepository = flightsRepository;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        


        public async Task<ActionResult> OnPost()
        {
             ItineraryList = await _flightsRepository.GetObjectsList(FlightInput.Origin, FlightInput.Destination,
                    FlightInput.OutboundDate, FlightInput.InboundDate, FlightInput.AmountOfPassengers, FlightInput.TravelClass, FlightInput.Currency);
            return Page();
        }

        public async void OnGet()
        {
        }

        


        public ActionResult OnPostGetTicket()
        {
            if (_signInManager.IsSignedIn(User))
            {
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Body.CopyTo(stream);
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string requestBody = reader.ReadToEnd();
                        if (requestBody.Length > 0)
                        {
                            var obj = JsonConvert.DeserializeObject<Ticket>(requestBody);
                            if (obj != null)
                            {
                                var ticket = new Ticket
                                {
                                    originAirportOutbound = obj.originAirportOutbound,
                                    originAirportInbound = obj.originAirportInbound,
                                    tripDurationOutbound = obj.tripDurationOutbound,
                                    tripDurationInbound = obj.tripDurationInbound,
                                    layoverStopAmountOutbound = obj.layoverStopAmountOutbound,
                                    layoverStopAmountInbound = obj.layoverStopAmountInbound,
                                    layoverCitiesOutbound = obj.layoverCitiesOutbound,
                                    layoverCitiesInbound = obj.layoverCitiesInbound,
                                    arrivalAirportOutbound = obj.arrivalAirportOutbound,
                                    arrivalAirportInbound = obj.arrivalAirportInbound,
                                    arrivalTimeOutbound = obj.arrivalTimeOutbound,
                                    arrivalTimeInbound = obj.arrivalTimeInbound,
                                    farePricePerPassenger = obj.farePricePerPassenger,
                                    fareClass = obj.fareClass,
                                    fareCurrency = obj.fareCurrency,
                                    farePriceTax = obj.farePriceTax,
                                    farePriceTotal = obj.farePriceTotal,
                                    departureTimeOutbound = obj.departureTimeOutbound,
                                    departureTimeInbound = obj.departureTimeInbound,
                                    ApplicationUserId = _userManager.GetUserId(User)

                                };

                                _context.Tickets.Add(ticket);
                                _context.SaveChangesAsync();
                            }
                        }
                    }
                }
                var jsonSuccess = "SUCCESS!";
                return new JsonResult(jsonSuccess);
            }
            else
            {
                return new JsonResult("IDKWHATHAPPENJESD");
            }
        }

        
    }

    
}

