using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.FlightsFolder
{
    public class IndividualFlight
    {
        public string Id { get; set; }
        public int orderPos { get; set; }
        public string departs_at { get; set; }
        public string arrives_at { get; set; }
        public string originInd { get; set; }
        public string destinationInd { get; set; }
        public string marketing_airline { get; set; }
        public string operating_airline { get; set; }
        public string flight_number { get; set; }
        public string aircraft { get; set; }
        public string travel_class { get; set; }
        public string booking_code { get; set; }
        public int seats_remaining { get; set; }
        public string terminalOrg { get; set; }
        public string terminalDes { get; set; }
        public string duration { get; set; }
        public ItineraryObject Itinerary { get; set; }
    }
}
