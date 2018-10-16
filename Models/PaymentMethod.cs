using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public BankLink BankLink { get; set; }
    }
}
