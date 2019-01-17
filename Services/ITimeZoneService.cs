using System;
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
}
