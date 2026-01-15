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
    public partial class pageManagement_groupFunctions_TableAndDish_TableChange : DevExpress.XtraEditors.XtraForm
    {
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();

        public string vOrderID = "";
        public string vDinnerTableID = "";

        public pageManagement_groupFunctions_TableAndDish_TableChange()
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
            if (slkTo.EditValue == null || slkTo.EditValue.ToString() == "")
            {
                Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn được chuyển đến.");
                return;
            }

            if (Utilities.Functions.MessageBoxYesNo("Bạn muốn CHUYỂN '" + slkFrom.Text + "' sang '" + slkTo.Text + "' ?") != DialogResult.Yes)
                return;

            vDinnerTableID = slkTo.EditValue.ToString();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_TableChange_Load(object sender, EventArgs e)
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

                #region slkFrom

                DataTable _dtFrom = new DataTable();
                string _Result = bOrder.GetDinnerTable(callFrom, ref _dtFrom, false);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> DinnerTable_GetIsEmpty:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> DinnerTable_GetIsEmpty");
                    this.Close();
                    return;
                }

                Utilities.Multi.Populate_LookUpEdit(slkFrom, _dtFrom, "ID", "Name");

                DataTable dtOrder = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { vOrderID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                    this.Close();
                    return;
                }

                slkFrom.EditValue = dtOrder.Rows[0]["DinnerTableID"];

                #endregion

                #region slkTo

                DataTable _dtTo = new DataTable();
                _Result = bOrder.GetDinnerTable(callFrom, ref _dtTo, true);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> DinnerTable_GetIsEmpty:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> DinnerTable_GetIsEmpty");
                    this.Close();
                    return;
                }
                Utilities.Multi.Populate_LookUpEdit(slkTo, _dtTo, "ID", "Name");

                #endregion

                slkTo.Focus();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}