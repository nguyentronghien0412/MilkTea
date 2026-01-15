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
    public partial class pageCategories_groupMaterialMenu_Unit_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vUnitID = "";
        public DataTable vdtUnit = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageCategories_groupMaterialMenu_Unit_Edit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageCategories_groupMaterialMenu_Unit_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vUnitID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Đơn vị tính.");
                    return;
                }

                vdtUnit = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtUnit, "Unit", new string[] { "ID" }, new string[] { vUnitID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                if (int.Parse(vUnitID) == 0)
                {
                    this.Text = "Đơn vị tính - Tạo mới";

                    DataRow _drUnit = vdtUnit.NewRow();
                    vdtUnit.Rows.Add(_drUnit);
                }
                else
                {
                    this.Text = "Đơn vị tính - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(vdtUnit.Rows[0], this, callFrom);
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
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                DataTable dtCheck = new DataTable();
                if (int.Parse(vUnitID) == 0)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Unit", new string[] { "Name" }, new string[] { "'" + Unit_Name.Text.Trim() + "'" }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Đơn vị tính đã có trong danh mục.";
                }
                else
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Unit", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + Unit_Name.Text.Trim() + "'", vUnitID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Đơn vị tính đã có trong danh mục.";
                }

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
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

                Utilities.Multi.AssignData_FormToRow(vdtUnit.Rows[0], this, callFrom);

                string result = "";
                if (int.Parse(vUnitID) == 0)
                    result = bGeneral.Insert(callFrom, ref vdtUnit, true);
                else
                    result = bGeneral.UpdateByID(callFrom, vdtUnit);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vUnitID) == 0)
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
                    vUnitID = vdtUnit.Rows[0]["ID"].ToString();
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