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
    public partial class pageManagement_groupFunctions_TableAndDish_TableMerge : DevExpress.XtraEditors.XtraForm
    {
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();

        public string vOrderID = "";
        public string vOrderID_Merge = "";

        public pageManagement_groupFunctions_TableAndDish_TableMerge()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (slkOrderMerge.EditValue == null || slkOrderMerge.EditValue.ToString() == "")
            {
                Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn muốn gộp.");
                return;
            }

            if (Utilities.Functions.MessageBoxYesNo("Bạn muốn GỘP '" + slkOrderMerge.Text + "' với '" + slkOrder.Text + "' ?") != DialogResult.Yes)
                return;

            vOrderID_Merge = slkOrderMerge.EditValue.ToString();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_TableMerge_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (vOrderID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Order.");
                    this.Close();
                    return;
                }

                #region slkOrder

                DataTable _dtDinnerTable = new DataTable();
                string _Result = bGeneral.GetAll(callFrom, ref _dtDinnerTable, "DinnerTable", null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> DinnerTable_GetAll:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> DinnerTable_GetAll");
                    this.Close();
                    return;
                }

                Utilities.Multi.Populate_LookUpEdit(slkOrder, _dtDinnerTable, "ID", "Name");

                DataTable dtOrder = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { vOrderID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                    this.Close();
                    return;
                }

                slkOrder.EditValue = dtOrder.Rows[0]["DinnerTableID"];

                #endregion

                #region slkOrderMerge

                DataTable dtOrder_NoPayment = new DataTable();
                string result = bOrder.GetNoPayment(callFrom, ref dtOrder_NoPayment);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetNoPayment:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetNoPayment");
                    return;
                }

                for (int i = 0; i < dtOrder_NoPayment.Rows.Count; i++)
                {
                    if (dtOrder_NoPayment.Rows[i]["OrderID"].ToString() == vOrderID)
                    {
                        dtOrder_NoPayment.Rows.RemoveAt(i);
                        break;
                    }
                }

                Utilities.Multi.Populate_LookUpEdit(slkOrderMerge, dtOrder_NoPayment, "OrderID", "DinnerTableName");

                #endregion

                slkOrderMerge.Focus();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}