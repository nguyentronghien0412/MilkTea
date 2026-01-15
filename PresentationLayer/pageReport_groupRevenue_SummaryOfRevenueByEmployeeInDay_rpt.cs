using DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PresentationLayer
{
    public partial class pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_rpt()
        {
            InitializeComponent();
        }

        public void BindData_Information(dtoSummaryOfRevenueByEmployee PrintBill)
        {
            lbDateFrom.Text = PrintBill.DateFrom;
            lbDateTo.Text = PrintBill.DateTo;
            lbDateAction.Text = PrintBill.DateAction;
            lbEmployeeAction.Text = PrintBill.EmployeeAction;

            lbTotalCash.Text = PrintBill.TotalCash;
            lbTotalBank.Text = PrintBill.TotalBank;
            lbTotalGrab.Text = PrintBill.TotalGrab;
            lbTotalShopee.Text = PrintBill.TotalShopee;
            lbTotalAmount.Text = PrintBill.TotalAmount;
        }

        public void BindData()
        {
            colEmployee.DataBindings.Add("Text", DataSource, "PaymentedByName");
            colCash.DataBindings.Add("Text", DataSource, "Cash");
            colBank.DataBindings.Add("Text", DataSource, "Bank");
            colGrab.DataBindings.Add("Text", DataSource, "Grab");
            colShopee.DataBindings.Add("Text", DataSource, "Shopee");
            colTotal.DataBindings.Add("Text", DataSource, "Total");
        }
    }
}
