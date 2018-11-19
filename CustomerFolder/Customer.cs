using System;
using System.ComponentModel;
using Vancouver.Models;

namespace Vancouver.CustomerFolder
{
    public class Customer
    {
        public string CustomerId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
