using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class CustomerTravelHistory
    {
        public int CustomerTravelHistoryId { get; set; }
        public Customer Customer { get; set; }
        public string AirportFrom { get; set; } // peaks Airport class olema
        public string AirportTo { get; set; } // peaks Airport class olema
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

    }
}
