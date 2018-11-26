using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;

namespace Vancouver.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string BookingReference { get; set; }
        public ItineraryObject OrderItinerary { get; set; }
        public List<Customer> Customer { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
