﻿using System;
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
}
