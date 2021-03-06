﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class UserTravelHistory
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public string AirportFrom { get; set; }
        public string AirportTo { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

    }
}
