using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        
        public DateTime DateOfBirth { get; set; }

        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }

        public bool Primary { get; set; }
        
        public Passport Passport{ get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        
        public string ApplicationUserId { get; set; }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public IEnumerable<FavoriteDestination> ThreeFavoriteDestinations { get; set; }
    }
}
