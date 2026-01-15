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
    public partial class pageCategories_groupSystem_Position_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string typeAction = "";
        public string positionID = "";
        public DataTable dtPosition = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageCategories_groupSystem_Position_Edit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageCategories_groupSystem_Position_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (positionID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã chức vụ.");
                    return;
                }

                dtPosition = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtPosition, "Position",new string[] { "ID" }, new string[] { positionID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                }

                if (typeAction == Utilities.Parameters.Permission_NEW)
                {
                    this.Text = "Chức vụ - Tạo mới";

                    DataRow drPosition = dtPosition.NewRow();
                    dtPosition.Rows.Add(drPosition);
                }
                else if (typeAction == Utilities.Parameters.Permission_EDIT)
                {
                    this.Text = "Chức vụ - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(dtPosition.Rows[0], this, callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (Position_Name.Text.Trim() == "")
                return "Vui lòng nhập Chức vụ.";

            DataTable dtCheck = new DataTable();
            if (typeAction == Utilities.Parameters.Permission_NEW)
            {
                string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Position", new string[] { "Name" }, new string[] { "'" + Position_Name.Text.Trim() + "'" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    return result + "\n" + callFrom + " -> GetByCondition";
                }

                if (dtCheck != null && dtCheck.Rows.Count > 0)
                    return "Chức vụ này đã có trong danh mục.";
            }
            else
            {
                string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Position", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + Position_Name.Text.Trim() + "'", positionID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> CheckToUpdate:\n" + result);
                    return result + "\n" + callFrom + " -> CheckToUpdate";
                }

                if (dtCheck != null && dtCheck.Rows.Count > 0)
                    return "Chức vụ này đã có trong danh mục.";
            }

            return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(dtPosition.Rows[0], this, callFrom);

                string result = "";
                if (typeAction == Utilities.Parameters.Permission_NEW)
                    result = bGeneral.Insert(callFrom, ref dtPosition, true);
                else if (typeAction == Utilities.Parameters.Permission_EDIT)
                    result = bGeneral.UpdateByID(callFrom, dtPosition);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (typeAction == Utilities.Parameters.Permission_NEW)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Update");
                    }

                    return;
                }
                else
                {
                    positionID = dtPosition.Rows[0]["ID"].ToString();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}