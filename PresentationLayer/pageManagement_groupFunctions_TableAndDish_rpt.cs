using DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public pageManagement_groupFunctions_TableAndDish_rpt()
        {
            InitializeComponent();

            GroupField gfMenuGroupName = new GroupField("MenuGroupName");
            gfMenuGroupName.SortOrder = XRColumnSortOrder.None;
            GroupHeader1.GroupFields.Add(gfMenuGroupName);
        }

        public void BindData_Information(dtoPrintBill PrintBill)
        {
            lbCompanyName.Text = PrintBill.CompanyName;
            lbCompanyAddress.Text = PrintBill.CompanyAddress;
            lbCompanyPhone.Text = PrintBill.CompanyPhone;
            lbCompanyFacebook.Text = PrintBill.CompanyFacebook;
            
            lbDinnerTableName.Text = PrintBill.DinnerTableName;
            lbBillNo.Text = PrintBill.BillNo;
            lbOrderDate.Text = PrintBill.OrderDate;
            lbPaymentedDate.Text = PrintBill.PaymentedDate;
            lbTotalAmount.Text = PrintBill.TotalAmount;

            lbPrintDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        public void BindData()
        {
            grMenuGroupName.DataBindings.Add("Text", DataSource, "MenuGroupName");
            //colRankIndex.DataBindings.Add("Text", DataSource, "RankIndex");
            colMenuName.DataBindings.Add("Text", DataSource, "MenuName");
            colQuantity.DataBindings.Add("Text", DataSource, "Quantity");
            colPrice.DataBindings.Add("Text", DataSource, "Price");
            colTotal.DataBindings.Add("Text", DataSource, "Total");
        }
    }
}
