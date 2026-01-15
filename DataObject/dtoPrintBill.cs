using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoPrintBill
    {
        public dtoPrintBill()
        {
        }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFacebook { get; set; }
        public string DinnerTableName { get; set; }
        public string BillNo { get; set; }
        public string OrderDate { get; set; }
        public string PaymentedDate { get; set; }
        public string TotalAmount { get; set; }
        public string PromotionPercent { get; set; }
        public string PromotionAmount { get; set; }
        public string PaymentedAmount { get; set; }
        public DataTable dtDetail { get; set; }
    }
}
