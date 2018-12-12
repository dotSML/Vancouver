using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class OrderAssignment
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
