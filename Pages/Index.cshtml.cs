using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private readonly IFlightsObjectsRepository flightsRepository;
        public FlightInputModel FlightInput { get; set; }
        private IConfiguration _config;
        

        public class FlightInputModel
        {
            public string OutboundAirport { get; set; }
            public string InboundAirport { get; set; }
            public string OutboundDate { get; set; }
            public string InboundDate { get; set; }
            public string AmountOfPassengers { get; set; }
            public string TravelClass { get; set; }
            public string Currency { get; set; }
            public string FareOption { get; set; }
        }

        public IndexModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        [BindProperty]
        public FlightsResponse ResponseFlight { get; set; }
        public FlightsResponse.RootObject rootFlight { get; set; }

        public void OnPost()
        {
            
        }

        public void OnGet()
        {

        }

        public async Task<FlightsResponse.RootObject> GetResponse()
        {
            rootFlight = await JsonToObjectsList("TLL", "SEA", "2018-11-10", "2018-11-25", "1", "ECONOMY", "EUR");
            return rootFlight;
        }

        public async Task<FlightsResponse.RootObject> JsonToObjectsList(
            string origin,
            string destination,
            string outboundDate,
            string inboundDate,
            string amountOfPassengers,
            string travelClass,
            string currency
        )
        {
            var requestUrl = @"https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?apikey=" +
                             _config["FlightSearchAPI:Key"] + "&origin=" + origin + "&destination=" +
                             destination + "&departure_date=" + outboundDate + "&return_date=" + inboundDate +
                             "&adults=" + amountOfPassengers + "&currency=" + currency + "&travel_class=" + travelClass;
            var request =
                WebRequest.Create(requestUrl);
            //@"https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?apikey=" +
            //_config["FlightSearchAPI:Key"] + "&origin=" + origin + "&destination=" +
            //destination + "&departure_date=" + outboundDate + "&return_date=" + inboundDate +
            //"&adults=" + amountOfPassengers + "&currency=" + currency + "&travel_class=" + travelClass);
            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var reader = new StreamReader(response.GetResponseStream());
            var data = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<FlightsResponse.RootObject>(data);
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

