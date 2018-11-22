using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;

namespace Vancouver.Models
{
    public class Order
    {
        public string Id { get; set; }
        public ItineraryObject OrderItinerary { get; set; }
        public List<Customer> Customer { get; set; }
    }
}
