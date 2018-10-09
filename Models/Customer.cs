using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
