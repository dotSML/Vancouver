using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Vancouver.FlightsFolder
{
    public class FlightsObjectsRepository : IFlightsObjectsRepository
    {
        private IConfiguration _config;
        public FlightsObjectsRepository(IConfiguration config)
        {
            _config = config;
        }
        private static IList<ItineraryObject> itineraries { get; } = new List<ItineraryObject>();
        private FlightsResponse.RootObject FlightsResponse { get; set; }

        public async Task<ItineraryObject> GetObject(string id)
        {
            return itineraries.FirstOrDefault(x => x.Id == id);
        }

        public class FlightSearchInput
        {
            public string Origin { get; set; }
            public string Destination { get; set; }
            public string OutboundDate { get; set; }
            public string InboundDate { get; set; }
            public string AmountOfPassengers { get; set; }
            public string TravelClass { get; set; }
            public string Currency { get; set; }
        }

        public async Task<IEnumerable<ItineraryObject>> GetFlightsList()
        {
            return null;
        }

        public async Task<IEnumerable<ItineraryObject>> GetObjectsList(string origin,
            string destination,
            string outboundDate,
            string inboundDate,
            string amountOfPassengers,
            string travelClass,
            string currency)
        {
            var rootObj = await GetData(origin, destination, outboundDate, inboundDate, amountOfPassengers, travelClass, currency);

            itineraries.Clear();
            for(int i = 0;  i <= 10; i++ )
            {
                //flights.Add(new FlightObject());
                itineraries.Add(
                    new ItineraryObject()
                    {
                        originAirportOutbound = rootObj.results[i].itineraries[0].outbound.flights[0].origin.airport,
                        originAirportInbound = rootObj.results[i].itineraries[0].inbound.flights[0].origin.airport,
                        departureTimeOutbound =
                            rootObj.results[i].itineraries[0].outbound.flights[0].departs_at.ToString(),
                        departureTimeInbound =
                            rootObj.results[i].itineraries[0].inbound.flights[0].departs_at.ToString(),
                        arrivalAirportOutbound = rootObj.results[i].itineraries[0].outbound.flights[0]
                            .destination.ToString(),
                        arrivalAirportInbound = rootObj.results[i].itineraries[0].inbound.flights[0]
                            .destination.ToString(),
                        arrivalTimeOutbound = rootObj.results[i].itineraries[0].outbound.flights[0].arrives_at,
                        arrivalTimeInbound = rootObj.results[i].itineraries[0].inbound.flights[0].arrives_at,
                        fareClass = rootObj.results[i].itineraries[0].outbound.flights[0].booking_info.travel_class,
                        farePriceTotal = rootObj.results[i].fare.total_price,
                        farePriceTax = rootObj.results[i].fare.price_per_adult.tax,
                        fareCurrency = rootObj.currency,
                        farePricePerPassenger = rootObj.results[0].fare.price_per_adult.ToString(),
                    });

            }

            return new FlightObjectsList(itineraries);
            
        }

        public async Task<FlightsResponse.RootObject> GetData(
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
    }
}
