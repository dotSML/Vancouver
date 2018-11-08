using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
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
            var splitDepartureTimeOutbound = "";
            var splitDepartureTimeInbound = "";
            itineraries.Clear();
            for(int i = 0;  i <= 10; i++ )
            {
                //Get layover cities for OUTBOUND
                var layoverCitiesOutboundLooped = "";
                for (var a = 0; a < rootObj.results[i].itineraries[0].outbound.flights.Count - 1; a++)
                {
                    layoverCitiesOutboundLooped +=
                        rootObj.results[i].itineraries[0].outbound.flights[a].destination.airport + ", ";
                }

                //Get layover cities for INBOUND
                var layoverCitiesInboundLooped = "";
                for (var b = 0; b < rootObj.results[i].itineraries[0].outbound.flights.Count - 1; b++)
                {
                    layoverCitiesInboundLooped +=
                        rootObj.results[i].itineraries[0].inbound.flights[b].destination.airport + ", ";
                }

                var flightsCountOutbound = rootObj.results[i].itineraries[0].outbound.flights.Count;
                var flightsCountInbound = rootObj.results[i].itineraries[0].inbound.flights.Count;

                itineraries.Add(
                    new ItineraryObject()
                    {
                        originAirportOutbound = rootObj.results[i].itineraries[0].outbound.flights[0].origin.airport,
                        originAirportInbound = rootObj.results[i].itineraries[0].inbound.flights[0].origin.airport,
                        departureTimeOutbound =
                            rootObj.results[i].itineraries[0].outbound.flights[0].departs_at.Split("T")[1],
                        departureTimeInbound =
                            rootObj.results[i].itineraries[0].inbound.flights[0].departs_at.Split("T")[1],
                        arrivalAirportOutbound = rootObj.results[i].itineraries[0].outbound.flights[flightsCountOutbound - 1]
                            .destination.airport,
                        arrivalAirportInbound = rootObj.results[i].itineraries[0].inbound.flights[flightsCountInbound - 1]
                            .destination.airport,
                        arrivalTimeOutbound = rootObj.results[i].itineraries[0].outbound.flights[0].arrives_at.Split("T")[1],
                        arrivalTimeInbound = rootObj.results[i].itineraries[0].inbound.flights[0].arrives_at.Split("T")[1],
                        tripDurationOutbound = rootObj.results[i].itineraries[0].outbound.duration,
                        tripDurationInbound = rootObj.results[i].itineraries[0].inbound.duration,
                        layoverStopAmountOutbound = (rootObj.results[i].itineraries[0].outbound.flights.Count - 1).ToString(),
                        layoverStopAmountInbound = (rootObj.results[i].itineraries[0].inbound.flights.Count - 1).ToString(),
                        layoverCitiesOutbound = layoverCitiesOutboundLooped,
                        layoverCitiesInbound = layoverCitiesInboundLooped,
                        fareClass = rootObj.results[i].itineraries[0].outbound.flights[0].booking_info.travel_class,
                        farePriceTotal = rootObj.results[i].fare.total_price,
                        farePriceTax = rootObj.results[i].fare.price_per_adult.tax,
                        fareCurrency = rootObj.currency,
                        farePricePerPassenger = rootObj.results[i].fare.price_per_adult.total_fare,
                        
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
            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var reader = new StreamReader(response.GetResponseStream());
            var data = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<FlightsResponse.RootObject>(data);
            
        }
    }
}
