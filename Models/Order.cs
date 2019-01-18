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
    public class Order : Archetype
    {
        private string id;
        private string bookingReference;
        
        public string Id
        {
            get => getString(ref id);
            set => id = value;
        }
        public string BookingReference
        {
            get => getString(ref bookingReference);
            set => bookingReference = value;
        }
        public ItineraryObject OrderItinerary { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
