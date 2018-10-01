using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Ticket Ticket { get; set; }
        public BankLink BankLink { get; set; }
        public string TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public string Payee { get; set; }
    }
}
