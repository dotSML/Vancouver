using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.FlightsFolder
{
    public class FlightObjectsList : List<ItineraryObject>
    {
        public FlightObjectsList(IEnumerable<ItineraryObject> items)
        {
            if (items is null) return;
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
