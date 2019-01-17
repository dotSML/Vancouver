using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Vancouver.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        public List<TimeZoneObject> TimeZones;
        public TimeZoneObject TimeZoneObj;
        public TimeZoneInfo ZoneInfo;
        private IAirportInfoService _airportInfoService;

        public TimeZoneService(IAirportInfoService airportInfoService)
        {
            _airportInfoService = airportInfoService;
        }

        public void GetTimeZoneList()
        {
            using (StreamReader sr = new StreamReader("wwwroot/timezones.json"))
            {
                string json = sr.ReadToEnd();
                TimeZones = JsonConvert.DeserializeObject<List<TimeZoneObject>>(json);
            }
            
        }

        public string GetDuration(string codeOrigin,string codeArrival , string originTime, string arrivalTime)
        {
            var originDatetime = Convert.ToDateTime(originTime);
            var arrivalDatetime = Convert.ToDateTime(arrivalTime);
            var utcTime = DateTime.UtcNow;
            var timeZoneOrigin = FindTimeZone(codeOrigin);
            var timeZoneArrival = FindTimeZone(codeArrival);
            var originUtc = TimeZoneInfo.ConvertTimeToUtc(originDatetime, timeZoneOrigin);
            var arrivalUtc = TimeZoneInfo.ConvertTimeToUtc(arrivalDatetime, timeZoneArrival);

            TimeSpan timeSpan = arrivalUtc - originUtc;
            timeSpan = timeSpan.Duration();
            var resultDuration = timeSpan.Hours + "h " + timeSpan.Minutes + "m";
            return resultDuration;
        }

        public string GetLayoverDuration(string arrivalTime, string departingTime)
        {
            var arrival = Convert.ToDateTime(arrivalTime);
            var departing = Convert.ToDateTime(departingTime);
            TimeSpan timeSpan = departing - arrival;
            timeSpan = timeSpan.Duration();
            var resultDuration = timeSpan.Hours + "h " + timeSpan.Minutes + "m";
            return resultDuration;
        }

        public TimeZoneInfo FindTimeZone(string code)
        {
            var airportTz = _airportInfoService.GetAirportTimeZone(code);
            var tzList = TimeZones;
            var allTimeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach(var tz in tzList)
            {
                if(tz.utc.Contains(airportTz))
                {
                    TimeZoneObj = tz;
                }
            }

            try
            {
                ZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneObj.value);
            }
            catch (TimeZoneNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

            return ZoneInfo;
        }

    }
}