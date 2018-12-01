using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class Passport
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        [ForeignKey("Customers")]
        public Customer Customer { get; set; }
    }
}
