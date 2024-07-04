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
    class customersBLL
    {
        public int id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public int Mobile { get; set; }
    }
}
