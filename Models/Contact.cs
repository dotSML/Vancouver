using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string AreaCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
