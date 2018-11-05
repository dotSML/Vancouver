using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vancouver.FlightsFolder
{
    public class FlightsObjectsRepository : IFlightsObjectsRepository
    {

        private static IList<FlightObject> flights { get; } = new List<FlightObject>();

        public async Task<FlightObject> GetObject(string id)
        {
            return flights.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<FlightObject>> GetObjectsList()
        {
            var l = await jsonToObjectsList();

            flights.Clear();
            foreach (var i in l)
            {
                flights.Add(i);
            }

            return new FlightObjectsList(l);
        }

        private async Task<IEnumerable<FlightObject>> jsonToObjectsList()
        {
            var request =
                WebRequest.Create(
                    @"https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?apikey=yE3GQEKE2YTzCFws0fdETDCc303eHVST");
            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var reader = new StreamReader(response.GetResponseStream());
            var data = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<IEnumerable<FlightObject>>(data);
        }
    }
}
