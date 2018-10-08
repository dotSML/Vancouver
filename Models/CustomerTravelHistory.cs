using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class CustomerTravelHistory
    {
        public Customer Customer { get; set; }
        public string AirportFrom { get; set; } // peaks Airport class olema
        public string AirportTo { get; set; } // peaks Airport class olema
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

    }
}
