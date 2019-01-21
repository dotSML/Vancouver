using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Internal;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Vancouver.Services;

namespace Vancouver.FlightsFolder
{
    public class FlightsObjectsRepository : IFlightsObjectsRepository
    {
        private IConfiguration _config;
        private ITimeZoneService _tzService;

        public FlightsObjectsRepository(IConfiguration config, ITimeZoneService tzService)
        {
            _config = config;
            _tzService = tzService;
        }
        private static IList<ItineraryObject> itineraries { get; } = new List<ItineraryObject>();
        private FlightsResponse.RootObject FlightsResponse { get; set; }

        public ItineraryObject GetObject(string id)
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

        public string GetIata(string airport)
        {
            var output = airport.Split("(")[1];
            output = output.Split(")")[0];
            return output;
        }


        public string GetLayoverCitiesInbound(FlightsResponse.RootObject obj, int i)
        {
            var layoverCitiesInboundLooped = "";

            if (obj.results[i].itineraries[0].inbound.flights.Count > 1)
            {
                for (var b = 0; b < obj.results[i].itineraries[0].inbound.flights.Count - 1; b++)
                {
                    layoverCitiesInboundLooped +=
                        obj.results[i].itineraries[0].inbound.flights[b].destination.airport + ", ";
                }

                layoverCitiesInboundLooped = layoverCitiesInboundLooped.Remove(layoverCitiesInboundLooped.Length - 2);
                return layoverCitiesInboundLooped;
            }
            else
            {
                layoverCitiesInboundLooped = "DIRECT";
                return layoverCitiesInboundLooped;
            }
        }

        public string GetLayoverCitiesOutbound(FlightsResponse.RootObject obj, int i)
        {
            var layoverCitiesOutboundLooped = "";
            if (obj.results[i].itineraries[0].outbound.flights.Count > 1)
            {
                for (var a = 0; a < obj.results[i].itineraries[0].outbound.flights.Count - 1; a++)
                {
                    layoverCitiesOutboundLooped +=
                        obj.results[i].itineraries[0].outbound.flights[a].destination.airport + ", ";
                }

                layoverCitiesOutboundLooped =
                    layoverCitiesOutboundLooped.Remove(layoverCitiesOutboundLooped.Length - 2);
                return layoverCitiesOutboundLooped;
            }
            else
            {
                layoverCitiesOutboundLooped = "DIRECT";
                return layoverCitiesOutboundLooped;
            }
        }

        


        public async Task<IEnumerable<ItineraryObject>> GetObjectsList(string origin,
            string destination,
            string outboundDate,
            string inboundDate,
            string amountOfPassengers,
            string travelClass,
            string currency)
        {
            origin = GetIata(origin);
            destination = GetIata(destination);
            var rootObj = await GetData(origin, destination, outboundDate, inboundDate, amountOfPassengers, travelClass, currency);
            if (rootObj == null)
            {
                return null;
            }
            var rootObjCount = rootObj.results.Count;
            var outboundLegs = new List<IndividualFlightOutbound>();
            var inboundLegs = new List<IndividualFlightInbound>();

            itineraries.Clear();
            for(int i = 0;  i < rootObjCount; i++ )
            {
                outboundLegs.Clear();
                inboundLegs.Clear();
                var flightsCountOutbound = rootObj.results[i].itineraries[0].outbound.flights.Count;
                var getFlightsOutbound = rootObj.results[i].itineraries[0].outbound.flights;

                for (int u = 0; getFlightsOutbound.Count > u; u++)
                {
                    var indOutbound = getFlightsOutbound[u];

                    outboundLegs.Add(
                        new IndividualFlightOutbound()
                        {
                            originInd = indOutbound.origin.airport,
                            destinationInd = indOutbound.destination.airport,
                            travel_class = indOutbound.booking_info.travel_class,
                            flight_number = indOutbound.flight_number,
                            booking_code = indOutbound.booking_info.booking_code,
                            aircraft = indOutbound.aircraft,
                            arrives_at = indOutbound.arrives_at,
                            departs_at = indOutbound.departs_at,
                            seats_remaining = indOutbound.booking_info.seats_remaining,
                            marketing_airline = indOutbound.marketing_airline,
                            operating_airline = indOutbound.operating_airline,
                            orderPos = u,
                            terminalOrg = indOutbound.origin.terminal,
                            terminalDes = indOutbound.destination.terminal,
                            duration = _tzService.GetDuration(indOutbound.origin.airport, indOutbound.destination.airport,
                            indOutbound.departs_at.Split("T")[0] + " " + indOutbound.departs_at.Split("T")[1], indOutbound.arrives_at.Split("T")[0] + " " + indOutbound.arrives_at.Split("T")[1])
                        });
                }


                if (inboundDate != null)
                {
                    var flightsCountInbound = rootObj.results[i].itineraries[0].inbound.flights.Count;
                    var getFlightsInbound = rootObj.results[i].itineraries[0].inbound.flights;


                    for (var c = 0; getFlightsInbound.Count > c; c++)
                    {
                        var indInbound = getFlightsInbound[c];

                        inboundLegs.Add(
                            new IndividualFlightInbound()
                            {
                                originInd = indInbound.origin.airport,
                                destinationInd = indInbound.destination.airport,
                                travel_class = indInbound.booking_info.travel_class,
                                flight_number = indInbound.flight_number,
                                booking_code = indInbound.booking_info.booking_code,
                                aircraft = indInbound.aircraft,
                                arrives_at = indInbound.arrives_at,
                                departs_at = indInbound.departs_at,
                                seats_remaining = indInbound.booking_info.seats_remaining,
                                marketing_airline = indInbound.marketing_airline,
                                operating_airline = indInbound.operating_airline,
                                orderPos = c,
                                terminalOrg = indInbound.origin.terminal,
                                terminalDes = indInbound.destination.terminal,
                                duration = _tzService.GetDuration(indInbound.origin.airport, indInbound.destination.airport,
                                indInbound.departs_at.Split("T")[0] + " " + indInbound.departs_at.Split("T")[1], indInbound.arrives_at.Split("T")[0] + " " + indInbound.arrives_at.Split("T")[1])
                            });
                    }





                    itineraries.Add(
                        new ItineraryObject()
                        {
                            Id = Guid.NewGuid().ToString(),
                            AmountOfPassengers = Int32.Parse(amountOfPassengers),
                            originAirportOutbound = getFlightsOutbound[0].origin.airport,
                            originAirportInbound = getFlightsInbound[0].origin.airport,
                            departureTimeOutbound = getFlightsOutbound[0].departs_at,
                            departureTimeInbound = getFlightsInbound[0].departs_at,
                            arrivalAirportOutbound = getFlightsOutbound[flightsCountOutbound - 1].destination.airport,
                            arrivalAirportInbound = getFlightsInbound[flightsCountInbound - 1].destination.airport,
                            arrivalTimeOutbound = getFlightsOutbound[getFlightsOutbound.Count - 1].arrives_at,
                            arrivalTimeInbound = getFlightsInbound[getFlightsInbound.Count - 1].arrives_at,
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
                            IndFlightOutbound = new List<IndividualFlightOutbound>(outboundLegs)
                                .OrderBy(o => o.orderPos).ToList(),
                            IndFlightInbound = new List<IndividualFlightInbound>(inboundLegs).OrderBy(o => o.orderPos)
                                .ToList()
                        });

                }
                else
                {
                    itineraries.Add(
                        new ItineraryObject()
                        {
                            Id = Guid.NewGuid().ToString(),
                            AmountOfPassengers = Int32.Parse(amountOfPassengers),
                            originAirportOutbound = getFlightsOutbound[0].origin.airport,
                            departureTimeOutbound = getFlightsOutbound[0].departs_at,
                            arrivalAirportOutbound = getFlightsOutbound[flightsCountOutbound - 1].destination.airport,
                            arrivalTimeOutbound = getFlightsOutbound[getFlightsOutbound.Count - 1].arrives_at,
                            tripDurationOutbound = rootObj.results[i].itineraries[0].outbound.duration,
                            layoverStopAmountOutbound = (flightsCountOutbound - 1).ToString(),
                            layoverCitiesOutbound = GetLayoverCitiesOutbound(rootObj, i),
                            fareClass = getFlightsOutbound[0].booking_info.travel_class,
                            farePriceTotal = rootObj.results[i].fare.total_price,
                            farePriceTax = rootObj.results[i].fare.price_per_adult.tax,
                            fareCurrency = rootObj.currency,
                            farePricePerPassenger = rootObj.results[i].fare.price_per_adult.total_fare,
                            IndFlightOutbound = new List<IndividualFlightOutbound>(outboundLegs)
                                .OrderBy(o => o.orderPos).ToList()
                        });
                }
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
                             "&adults=" + amountOfPassengers + "&currency=" + currency + "&travel_class=" + travelClass + "&number_of_results=15";
            var request =
                WebRequest.Create(requestUrl);

            try
            {
                var response = await request.GetResponseAsync().ConfigureAwait(false);

                var reader = new StreamReader(response.GetResponseStream());
                var data = await reader.ReadToEndAsync();

                return JsonConvert.DeserializeObject<FlightsResponse.RootObject>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("Flight search exception: {0}", e);
                return null;
            }

            
            
        }

    }
}
