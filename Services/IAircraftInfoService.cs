using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vancouver.Services
{
    public interface IAircraftInfoService
    {
        List<AircraftObject> JsonToObjectsList();
        string GetAircraftName(string aircraftCode);
        AircraftObject GetAircraftObject(string aircraftCode);
    }
}
