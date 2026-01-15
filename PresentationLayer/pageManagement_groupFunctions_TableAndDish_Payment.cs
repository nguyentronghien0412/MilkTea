using DevExpress.Pdf.Native.BouncyCastle.Asn1.Cms;
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
    public partial class pageManagement_groupFunctions_TableAndDish_Payment : DevExpress.XtraEditors.XtraForm
    {
        public string vTableName = "";
        public string vPaymentType = "";
        public object vCollectBy = 0;

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
                BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
                string result = bGeneral.GetAll(callFrom, ref dtTemp, TableName, "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> " + TableName);
                    this.Close();
                }

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        public pageManagement_groupFunctions_TableAndDish_Payment()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            vPaymentType = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GetData(string type)
        {
            if (slkEmployeeCollect.EditValue == null || slkEmployeeCollect.EditValue.ToString() == "")
            {
                Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập nhân viên thu tiền.");
                return;
            }

            vCollectBy = slkEmployeeCollect.EditValue;
            vPaymentType = type;
        }

        private void pageManagement_groupFunctions_TableAndDish_Payment_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                lbTableName.Text = vTableName;

                DataTable dtEmployees = new DataTable();
                BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ", new string[] { "StatusID" }, new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString() }, "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }

                slkEmployeeCollect.Properties.ValueMember = "ID";
                slkEmployeeCollect.Properties.DisplayMember = "FullName";
                slkEmployeeCollect.Properties.DataSource = dtEmployees;
                slkEmployeeCollect.EditValue = vCollectBy;

                Populate_LookUpEdit(slkEmployeeCollect_slk_colGenderID_rlk, "Gender");
                Populate_LookUpEdit(slkEmployeeCollect_slk_colPositionID_rlk, "Position");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void slkEmployeeCollect_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            GetData("CASH");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            GetData("BANK");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            GetData("GRAB");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnShopeeFood_Click(object sender, EventArgs e)
        {
            GetData("SHOPEE");
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}