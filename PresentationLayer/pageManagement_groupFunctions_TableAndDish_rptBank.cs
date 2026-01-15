using DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_rptBank : DevExpress.XtraReports.UI.XtraReport
    {
        public pageManagement_groupFunctions_TableAndDish_rptBank()
        {
            InitializeComponent();
        }

        public void BindData_Information(dtoBank Bank)
        {
            lbCompanyName.Text = Bank.CompanyName;
            lbCompanyAddress.Text = Bank.CompanyAddress;
            lbCompanyPhone.Text = Bank.CompanyPhone;

            lbBankName.Text = Bank.BankName;
            lbBankID.Text = Bank.BankID;
            lbBankAccount.Text = Bank.BankAccount;
            xrPictureBox1.Image = Bank.BankQRCode;
        }
    }
}
