using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoiceWPF2.UI;
using invoiceWPF2.DAL;
using invoiceWPF2;

namespace invoiceWPF2.BLL
{
    class invoiceBLL
    {
        public int invoiceNum { get; set; }
        public string invoiceItems { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int total { get; set; }
        public string customerName { get; set; }
        public int customerMobile { get; set; }
    }
}
