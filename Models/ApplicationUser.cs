using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vancouver.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public DateTime DateOfBirth { get; set; }
    }
}
