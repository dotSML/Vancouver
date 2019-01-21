using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.FlightsFolder
{
    public interface IFlightsObjectsRepository
    {
        Task<IEnumerable<ItineraryObject>> GetObjectsList(string origin,
            string destination,
            string outboundDate,
            string inboundDate,
            string amountOfPassengers,
            string travelClass,
            string currency);
        Task<FlightsResponse.RootObject> GetData(string origin,
            string destination,
            string outboundDate,
            string inboundDate,
            string amountOfPassengers,
            string travelClass,
            string currency);
    }
}
