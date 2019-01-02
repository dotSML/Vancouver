using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Services
{
    public interface IAirportInfoService
    {
        List<AirportDataObject> JsonToObjectList();
        AirportDataObject GetAirport(string airportCode);
        string GetAirportName(string airportCode);
        string GetAirportTimeZone(string airportCode);
    }

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

    public class AirportDataObject
    {
        public string code { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string woeid { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public string runway_length { get; set; }
        public string elev { get; set; }
        public string icao { get; set; }
        public string direct_flights { get; set; }
        public string carriers { get; set; }
    }
}
