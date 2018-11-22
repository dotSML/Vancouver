using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public string CustomerId { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName
        {
            get => getString(ref firstName);
            set => firstName = value;
        }
        [DisplayName("Last Name")]
        [Required]
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
        

        public Passport Passport { get; set; }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
