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
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Seat { get; set; }
        public string TicketType { get; set; }
        public string Gate { get; set; }
        public string Airline { get; set; }
        public int AirlineID { get; set; }
        public int FlightID { get; set; }
    }
}
