using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_CashOrBank : DevExpress.XtraEditors.XtraForm
    {
        public string vTableName = "";
        public string vType = "";

        public pageManagement_groupFunctions_TableAndDish_CashOrBank()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            vType = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            vType = "BANK";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            vType = "CASH";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_CashOrBank_Load(object sender, EventArgs e)
        {
            lbTableName.Text = vTableName;
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            vType = "GRAB";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnShopeeFood_Click(object sender, EventArgs e)
        {
            vType = "SHOPEE";
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}