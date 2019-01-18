using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vancouver.Core;

namespace Vancouver.Models
{
    public class Customer: Archetype
    {
        private string customerId;
        private string firstName;
        private string lastName;
        private string email;

        [Key]
        public string CustomerId {
            get => getString(ref customerId);
            set => customerId = value;
        }

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
        public DateTime DateOfBirth { get; set; }
        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }

        public bool Primary { get; set; }
        
        public Passport Passport{ get; set; }
        
        public string ApplicationUserId { get; set; }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
