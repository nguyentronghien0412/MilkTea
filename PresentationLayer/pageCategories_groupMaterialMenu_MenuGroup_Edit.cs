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
    public partial class pageCategories_groupMaterialMenu_MenuGroup_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vMenuGroupID = "";
        public DataTable vdtMenuGroup = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageCategories_groupMaterialMenu_MenuGroup_Edit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
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

        private void pageCategories_groupMaterialMenu_MenuGroup_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vMenuGroupID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã nhóm thực đơn.");
                    return;
                }

                Populate_LookUpEdit(MenuGroup_StatusID, "Status");

                vdtMenuGroup = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtMenuGroup, "MenuGroup", new string[] { "ID" }, new string[] { vMenuGroupID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                if (int.Parse(vMenuGroupID) == 0)
                {
                    this.Text = "Nhóm thực đơn - Tạo mới";

                    DataRow _drMenuGroup = vdtMenuGroup.NewRow();
                    _drMenuGroup["StatusID"] = (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;
                    vdtMenuGroup.Rows.Add(_drMenuGroup);
                }
                else
                {
                    this.Text = "Nhóm thực đơn - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(vdtMenuGroup.Rows[0], this, callFrom);
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
                if (int.Parse(vMenuGroupID) == 0)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "MenuGroup", new string[] { "Name" }, new string[] { "'" + MenuGroup_Name.Text.Trim() + "'" }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên nhóm đã có trong danh mục.";
                }
                else
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "MenuGroup", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + MenuGroup_Name.Text.Trim() + "'", vMenuGroupID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên nhóm đã có trong danh mục.";
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

                Utilities.Multi.AssignData_FormToRow(vdtMenuGroup.Rows[0], this, callFrom);

                string result = "";
                if (int.Parse(vMenuGroupID) == 0)
                    result = bGeneral.Insert(callFrom, ref vdtMenuGroup, true);
                else
                    result = bGeneral.UpdateByID(callFrom, vdtMenuGroup);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vMenuGroupID) == 0)
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
                    vMenuGroupID = vdtMenuGroup.Rows[0]["ID"].ToString();
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