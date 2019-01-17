using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Services
{
    public interface ITimeZoneService
    {
        TimeZoneInfo FindTimeZone(string code);
        void GetTimeZoneList();
        string GetDuration(string originCode, string arrivalCode, string originTime, string arrivalTime);
        string GetLayoverDuration(string arrivalTime, string departingTime);
    }

    public class TimeZoneObject
    {
        public string value { get; set; }
        public string abbr { get; set; }
        public double offset { get; set; }
        public bool isdst { get; set; }
        public string text { get; set; }
        public List<string> utc { get; set; }
    }
}
