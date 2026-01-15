using DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_rptCheck : DevExpress.XtraReports.UI.XtraReport
    {
        public pageManagement_groupFunctions_TableAndDish_rptCheck()
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
            lbOrderDate.Text = PrintBill.OrderDate;
        }

        public void BindData()
        {
            grMenuGroupName.DataBindings.Add("Text", DataSource, "MenuGroupName");
            colRankIndex.DataBindings.Add("Text", DataSource, "RankIndex");
            colMenuName.DataBindings.Add("Text", DataSource, "MenuName");
            colQuantity.DataBindings.Add("Text", DataSource, "Quantity");
        }
    }
}
