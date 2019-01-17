using System;
using System.Collections.Generic;
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
}
