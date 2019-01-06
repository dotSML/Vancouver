using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Services
{
    public interface IAircraftInfoService
    {
        List<AircraftObject> JsonToObjectsList();
        string GetAircraftName(string aircraftCode);
        AircraftObject GetAircraftObject(string aircraftCode);
    }

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

    public class AircraftObject
    {
        public string Aircraft { get; set; }
        public string CRV { get; set; }
        public string S210 { get; set; }
    }

}
