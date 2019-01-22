using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vancouver.Core;
using Vancouver.CustomerFolder;

namespace Vancouver.Models
{
    public class Passport : Archetype
    {
        private string passportId;
        private string firstName;
        private string lastName;
        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;
        private string passportNumber;

        public string PassportId { get; set; }
        public string FirstName
        {
            get => getString(ref firstName);
            set => firstName = value;
        }

        public string LastName
        {
            get => getString(ref lastName);
            set => lastName = value;
        }
        public DateTime ValidFrom
        {
            get => getMinValue(ref validFrom, ref validTo);
            set => setValue(ref validFrom, value);
        }
        public DateTime ValidTo
        {
            get => getMaxValue(ref validTo, ref validFrom);
            set => setValue(ref validTo, value);
        }
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber
        {
            get => getString(ref passportNumber);
            set => passportNumber = value;
        }
        
    }
}
