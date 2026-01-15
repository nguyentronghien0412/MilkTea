using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoSummaryOfRevenueByEmployee
    {
        public dtoSummaryOfRevenueByEmployee()
        {
        }

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string DateAction { get; set; }
        public string EmployeeAction { get; set; }
        public string TotalCash { get; set; }
        public string TotalBank { get; set; }
        public string TotalGrab { get; set; }
        public string TotalShopee { get; set; }
        public string TotalAmount { get; set; }
        public DataTable dtDetail { get; set; }
    }
}
