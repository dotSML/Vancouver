using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.FlightsFolder
{
    public interface IFlightsObjectsRepository
    {
        Task<FlightObject> GetObject(string id);
        Task<IEnumerable<FlightObject>> GetObjectsList();
    }
}
