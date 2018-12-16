using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        
    }
}
