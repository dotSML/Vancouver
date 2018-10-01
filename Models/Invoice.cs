using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Payment Payment { get; set; }
    }
}
