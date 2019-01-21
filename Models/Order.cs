using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vancouver.Core;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string BookingReference { get; set; }
        public ItineraryObject OrderItinerary { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}
