using System;
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
        private static IList<FlightObject> flights { get; } = new List<FlightObject>();

        public async Task<FlightObject> GetObject(string id)
        {
            return flights.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<FlightObject>> GetObjectsList()
        {
            var l = await JsonToObjectsList("TLL", "SEA", "2018-11-10", "2018-11-25", "1", "ECONOMY", "EUR");

            flights.Clear();
            foreach (var i in l)
            {
                flights.Add(i);

            }

            return new FlightObjectsList(l);
        }

        public async Task<IEnumerable<FlightObject>> JsonToObjectsList(
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

            return JsonConvert.DeserializeObject<IEnumerable<FlightObject>>(data);
        }
    }
}
