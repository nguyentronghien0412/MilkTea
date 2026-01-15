using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoBank
    {
        public dtoBank()
        {
        }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string BankName { get; set; }
        public string BankID { get; set; }
        public string BankAccount { get; set; }
        public Image BankQRCode { get; set; }
    }
}
