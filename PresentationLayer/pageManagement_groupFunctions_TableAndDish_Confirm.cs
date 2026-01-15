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
    public partial class pageManagement_groupFunctions_TableAndDish_Confirm : DevExpress.XtraEditors.XtraForm
    {
        public string vTableName = "";
        public decimal vTotalAmount = 0;
        public int vPromotionPercent = 0;
        public decimal vPromotionAmount = 0;
        public decimal vTotal = 0;

        public pageManagement_groupFunctions_TableAndDish_Confirm()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            vTotal = decimal.Parse(txtPaymentedAmount.Text);
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_Confirm_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                lbTableName.Text = vTableName;
                txtTotalAmount.Text = vTotalAmount.ToString("n0");

                if (vPromotionPercent != 0)
                {
                    lbPromotionAmount.Text = lbPromotionAmount.Text + " " + vPromotionPercent + "%";

                    vPromotionAmount = vPromotionPercent * (decimal)(0.01) * vTotalAmount;
                    txtPromotionAmount.Text = vPromotionAmount.ToString("n0");
                }
                else
                {
                    txtPromotionAmount.Text = vPromotionAmount.ToString("n0");
                }

                txtPaymentedAmount.Text = (vTotalAmount - vPromotionAmount).ToString("n0");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}