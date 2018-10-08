using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public Customer Customer { get; set; }
        public string AirportFrom { get; set; } // peaks Airport class olema
        public string AirportTo { get; set; } // peaks Airport class olema
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string Seat { get; set; }
        public TicketType TicketType { get; set; }
        public string Gate { get; set; }
        public string Airline { get; set; }
        public int AirlineID { get; set; }
        public int FlightID { get; set; }
    }
}
