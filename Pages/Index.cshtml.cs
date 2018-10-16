using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TestDbContext _context;

        public IndexModel(TestDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public ActionResult OnPostGetTicket()
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
                                departureTimeInbound = obj.departureTimeInbound

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

        public void OnGet()
        {
            
        }
    }
}

