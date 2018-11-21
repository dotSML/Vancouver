using System;
using System.ComponentModel;
using Vancouver.Core;
using Vancouver.Models;

namespace Vancouver.CustomerFolder
{
    public class Customer: Archetype
    {
        private string customerId;
        private string firstName;
        private string lastName;
        private string email;
        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;


        public string CustomerId {
            get => getString(ref customerId);
            set => customerId = value;
        }
        [DisplayName("First Name")]
        public string FirstName
        {
            get => getString(ref firstName);
            set => firstName = value;
        }
        [DisplayName("Last Name")]
        public string LastName
        {
            get => getString(ref lastName);
            set => lastName = value;
        }
        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }
        public DateTime DateOfBirth
        {
            get => getMinValue(ref validFrom, ref validTo);
            set => setValue(ref validFrom, value);
        }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
