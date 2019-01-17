using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Vancouver.Services
{
    public class AirportInfoService : IAirportInfoService
    {
        public List<AirportDataObject> AirportObjects { get; set; }

        public List<AirportDataObject> JsonToObjectList()
        {
            using (StreamReader sr = new StreamReader("wwwroot/airportsData.json"))
            {
                string json = sr.ReadToEnd();
                AirportObjects = JsonConvert.DeserializeObject<List<AirportDataObject>>(json);
            }
            return AirportObjects;
        }

        public AirportDataObject GetAirport(string airportCode)
        {
            var airports = JsonToObjectList();
            var airportObject = airports.Find(x => x.code == airportCode);
            return airportObject;
        }

        public string GetAirportName(string airportCode)
        {
            var airport = GetAirport(airportCode);
            var airportName = airport.name;
            return airportName;
        }

        public string GetAirportTimeZone(string airportCode)
        {
            var airport = GetAirport(airportCode);
            var airportTz = airport.tz;
            return airportTz;
        }

    }
}