using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Vancouver.Services
{
    public class AircraftInfoService : IAircraftInfoService
    {
        public List<AircraftObject> JsonToObjectsList()
        {
            var aircrafts = new List<AircraftObject>();
            using(StreamReader sr = new StreamReader("wwwroot/planes.json"))
            {
                string json = sr.ReadToEnd();
                aircrafts = JsonConvert.DeserializeObject<List<AircraftObject>>(json);
            }
            return aircrafts;
        }

        public string GetAircraftName(string aircraftCode)
        {
            var aircraft = GetAircraftObject(aircraftCode);
            if(aircraft == null)
            {
                var aircraftName = aircraftCode;
                return aircraftName;
            }
            else
            {
                var aircraftName = aircraft.Aircraft;
                return aircraftName;
            }
        }

        public AircraftObject GetAircraftObject(string aircraftCode)
        {
            var aircraftList = JsonToObjectsList();
            var aircraft = aircraftList.FirstOrDefault(x => x.CRV == aircraftCode);
            return aircraft;
        }

    }
}