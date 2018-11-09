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
        List<IndividualFlightOutbound> IndOutbounds = new List<IndividualFlightOutbound>();
        List<IndividualFlightInbound> IndInbounds = new List<IndividualFlightInbound>();

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

        public string GetLayoverCitiesInbound(FlightsResponse.RootObject obj, int i)
        {
            var layoverCitiesInboundLooped = "";
            for (var b = 0; b < obj.results[i].itineraries[0].outbound.flights.Count - 1; b++)
            {
                layoverCitiesInboundLooped +=
                    obj.results[i].itineraries[0].inbound.flights[b].destination.airport + ", ";
            }

            return layoverCitiesInboundLooped;
        }

        public string GetLayoverCitiesOutbound(FlightsResponse.RootObject obj, int i)
        {
            var layoverCitiesOutboundLooped = "";
            for (var a = 0; a < obj.results[i].itineraries[0].outbound.flights.Count - 1; a++)
            {
                layoverCitiesOutboundLooped +=
                    obj.results[i].itineraries[0].outbound.flights[a].destination.airport + ", ";
            }

            return layoverCitiesOutboundLooped;
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
            var outboundLegs = new List<IndividualFlightOutbound>();
            var inboundLegs = new List<IndividualFlightInbound>();

            itineraries.Clear();
            for(int i = 0;  i < 25; i++ )
            {
                outboundLegs.Clear();
                inboundLegs.Clear();
                var flightsCountOutbound = rootObj.results[i].itineraries[0].outbound.flights.Count;
                var flightsCountInbound = rootObj.results[i].itineraries[0].inbound.flights.Count;

                var getFlightsOutbound = rootObj.results[i].itineraries[0].outbound.flights;
                var getFlightsInbound = rootObj.results[i].itineraries[0].inbound.flights;

                foreach (var flight in rootObj.results[i].itineraries[0].outbound.flights)
                {
                    outboundLegs.Add(
                        new IndividualFlightOutbound()
                        {
                            originInd = flight.origin.airport,
                            destinationInd = flight.destination.airport,
                            travel_class = flight.booking_info.travel_class,
                            flight_number = flight.flight_number,
                            booking_code = flight.booking_info.booking_code,
                            aircraft = flight.aircraft,
                            arrives_at = flight.arrives_at.Split("T")[1],
                            departs_at = flight.departs_at.Split("T")[1],
                            seats_remaining = flight.booking_info.seats_remaining,
                            marketing_airline = flight.marketing_airline,
                            operating_airline = flight.operating_airline
                        });
                }

                foreach (var flight in getFlightsInbound)
                {
                    inboundLegs.Add(
                        new IndividualFlightInbound()
                        {
                            originInd = flight.origin.airport,
                            destinationInd = flight.destination.airport,
                            travel_class = flight.booking_info.travel_class,
                            flight_number = flight.flight_number,
                            booking_code = flight.booking_info.booking_code,
                            aircraft = flight.aircraft,
                            arrives_at = flight.arrives_at.Split("T")[1],
                            departs_at = flight.departs_at.Split("T")[1],
                            seats_remaining = flight.booking_info.seats_remaining,
                            marketing_airline = flight.marketing_airline,
                            operating_airline = flight.operating_airline,
                        });
                }


                itineraries.Add(
                    new ItineraryObject()
                    {
                        Id = Guid.NewGuid().ToString(),
                        originAirportOutbound = getFlightsOutbound[0].origin.airport,
                        originAirportInbound = getFlightsInbound[0].origin.airport,
                        departureTimeOutbound = getFlightsOutbound[0].departs_at.Split("T")[1],
                        departureTimeInbound = getFlightsInbound[0].departs_at.Split("T")[1],
                        arrivalAirportOutbound = getFlightsOutbound[flightsCountOutbound - 1].destination.airport,
                        arrivalAirportInbound = getFlightsInbound[flightsCountInbound - 1].destination.airport,
                        arrivalTimeOutbound = getFlightsOutbound[getFlightsOutbound.Count - 1].arrives_at.Split("T")[1],
                        arrivalTimeInbound = getFlightsInbound[getFlightsInbound.Count - 1].arrives_at.Split("T")[1],
                        tripDurationOutbound = rootObj.results[i].itineraries[0].outbound.duration,
                        tripDurationInbound = rootObj.results[i].itineraries[0].inbound.duration,
                        layoverStopAmountOutbound = (flightsCountOutbound - 1).ToString(),
                        layoverStopAmountInbound = (flightsCountInbound - 1).ToString(),
                        layoverCitiesOutbound = GetLayoverCitiesOutbound(rootObj, i),
                        layoverCitiesInbound = GetLayoverCitiesInbound(rootObj, i),
                        fareClass = getFlightsOutbound[0].booking_info.travel_class,
                        farePriceTotal = rootObj.results[i].fare.total_price,
                        farePriceTax = rootObj.results[i].fare.price_per_adult.tax,
                        fareCurrency = rootObj.currency,
                        farePricePerPassenger = rootObj.results[i].fare.price_per_adult.total_fare,
                        IndFlightOutbound = new List<IndividualFlightOutbound>(outboundLegs),
                        IndFlightInbound = new List<IndividualFlightInbound>(inboundLegs)
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
            if (inboundDate != null)
            {
                inboundDate = "&return_date=" + inboundDate;
            }

            var requestUrl = @"https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?apikey=" +
                             _config["FlightSearchAPI:Key"] + "&origin=" + origin + "&destination=" +
                             destination + "&departure_date=" + outboundDate + inboundDate +
                             "&adults=" + amountOfPassengers + "&currency=" + currency + "&travel_class=" + travelClass + "&number_of_results = 25";
            var request =
                WebRequest.Create(requestUrl);
            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var reader = new StreamReader(response.GetResponseStream());
            var data = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<FlightsResponse.RootObject>(data);
            
        }
    }
}
