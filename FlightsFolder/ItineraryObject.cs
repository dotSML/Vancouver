using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vancouver.FlightsFolder
{
    public class ItineraryObject
    {
        public string Id { get; set; }
        public int AmountOfPassengers { get; set; }
        public string departureTimeOutbound { get; set; }
        public string departureTimeInbound { get; set; }
        public string originAirportOutbound { get; set; }
        public string originAirportInbound { get; set; }
        public string tripDurationOutbound { get; set; }
        public string tripDurationInbound { get; set; }
        public string layoverStopAmountOutbound { get; set; }
        public string layoverStopAmountInbound { get; set; }
        public string layoverCitiesOutbound { get; set; }
        public string layoverCitiesInbound { get; set; }
        public string arrivalTimeOutbound { get; set; }
        public string arrivalTimeInbound { get; set; }
        public string arrivalAirportOutbound { get; set; }
        public string arrivalAirportInbound { get; set; }
        public string farePricePerPassenger { get; set; }
        public string fareClass { get; set; }
        public string fareCurrency { get; set; }
        public string farePriceTax { get; set; }
        public string farePriceTotal { get; set; }
        public string ApplicationUserId { get; set; }
        public List<IndividualFlightOutbound> IndFlightOutbound { get; set; }
        public List<IndividualFlightInbound> IndFlightInbound { get; set; }
    }

    public class IndividualFlightOutbound
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

    public class IndividualFlightInbound
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
