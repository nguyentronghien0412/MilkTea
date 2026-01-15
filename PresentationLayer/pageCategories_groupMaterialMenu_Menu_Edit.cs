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
    public partial class pageCategories_groupMaterialMenu_Menu_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vMenuID = "";
        public DataTable vdtMenu = null;
        public DataTable vdtMenu_Size = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageCategories_groupMaterialMenu_Menu_Edit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Utilities.Functions.MessageBoxYesNo("Bạn muốn đóng giao diện này?") != DialogResult.Yes)
                return;

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

        private void pageCategories_groupMaterialMenu_Menu_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vMenuID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã thực đơn.");
                    return;
                }

                #region Menu_MenuGroupID

                DataTable dtMenuGroup = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtMenuGroup, "MenuGroup",
                                                        new string[] { "StatusID"},
                                                        new string[] { "<>" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Tạm_ngưng).ToString() }, "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuGroup:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuGroup");
                    this.Close();
                }

                Utilities.Multi.Populate_LookUpEdit(Menu_MenuGroupID, dtMenuGroup, "ID", "Name");

                #endregion

                Populate_LookUpEdit(Menu_StatusID, "Status");
                Populate_LookUpEdit(Menu_UnitID, "Unit");
                Populate_LookUpEdit(gvListOfSizes_colSizeID_lk, "Size");

                DataTable dtTasteQTy = new DataTable();
                dtTasteQTy.Columns.Add("ID", typeof(int));
                dtTasteQTy.Columns.Add("Name", typeof(string));
                dtTasteQTy.Rows.Add(1, "1");
                dtTasteQTy.Rows.Add(2, "2");
                Utilities.Multi.Populate_LookUpEdit(Menu_TasteQTy, dtTasteQTy, "ID", "Name");

                vdtMenu = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtMenu, "Menu", new string[] { "ID" }, new string[] { vMenuID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Menu:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Menu");
                }

                vdtMenu_Size = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref vdtMenu_Size, "Menu_Size", new string[] { "MenuID" }, new string[] { vMenuID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Menu_Size:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Menu_Size");
                }

                if (int.Parse(vMenuID) == 0)
                {
                    this.Text = "Thực đơn - Tạo mới";

                    DataRow _drMenu = vdtMenu.NewRow();
                    _drMenu["StatusID"] = (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;
                    vdtMenu.Rows.Add(_drMenu);
                }
                else
                {
                    this.Text = "Thực đơn - Cập nhật";
                }

                Menu_MenuGroupID_EditValueChanged(null, null);

                Utilities.Multi.AssignData_RowToForm(vdtMenu.Rows[0], this, callFrom);
                gcListOfSizes.DataSource = vdtMenu_Size;

                if (vdtMenu.Rows[0]["TasteQTy"].ToString() != "")
                    Menu_TasteQTy.EditValue = int.Parse(vdtMenu.Rows[0]["TasteQTy"].ToString());

                if (Utilities.Multi.CheckRight_PermissionByCode("pageCategories_groupMaterialMenu_Unit", Utilities.Parameters.Permission_NEW))
                    btnUnitAdd.Enabled = true;
                else
                    btnUnitAdd.Enabled = false;
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

                if (int.Parse(Menu_MenuGroupID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                    if (Menu_TasteQTy.EditValue == null)
                        return "Vui lòng nhập Số lượng vị của Lẩu.";

                if (gvListOfSizes.RowCount == 0)
                    return "Vui lòng nhập kích cỡ.";

                DataTable dtCheck = new DataTable();
                if (int.Parse(vMenuID) == 0)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Menu", new string[] { "Code", "MenuGroupID" }, new string[] { "'" + Menu_Code.Text.Trim() + "'", Menu_MenuGroupID.EditValue.ToString() }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Mã thực đơn đã có trong danh mục.";

                    result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Menu", new string[] { "Name" }, new string[] { "'" + Menu_Name.Text.Trim() + "'" }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên thực đơn đã có trong danh mục.";
                }
                else
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Menu", 
                                                            new string[] { "Code", "ID", "MenuGroupID" }, 
                                                            new string[] { "=", "<>", "=" }, 
                                                            new string[] { "'" + Menu_Code.Text.Trim() + "'", vMenuID, Menu_MenuGroupID.EditValue.ToString() }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Mã thực đơn đã có trong danh mục.";

                    result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Menu", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + Menu_Name.Text.Trim() + "'", vMenuID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên thực đơn đã có trong danh mục.";
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
                vdtMenu_Size.AcceptChanges();
                gvListOfSizes.PostEditor();

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

                Utilities.Multi.AssignData_FormToRow(vdtMenu.Rows[0], this, callFrom);
                
                string result = "";
                if (int.Parse(vMenuID) == 0)
                    result = bGeneral.Insert(callFrom, ref vdtMenu, ref vdtMenu_Size, true, true, "MenuID");
                else
                {
                    foreach (DataRow dr in vdtMenu_Size.Rows)
                        dr["MenuID"] = vdtMenu.Rows[0]["ID"];

                    BusinessLogicLayer.busMenu bMenu = new BusinessLogicLayer.busMenu();
                    result = bMenu.Update(callFrom, vdtMenu, vdtMenu_Size);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vMenuID) == 0)
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
                    vMenuID = vdtMenu.Rows[0]["ID"].ToString();
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

        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageCategories_groupMaterialMenu_Unit_Edit frmEdit = new pageCategories_groupMaterialMenu_Unit_Edit();
                frmEdit.vUnitID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    DataTable dtUnit = new DataTable();
                    string result = bGeneral.GetAll(callFrom, ref dtUnit, "Unit", "Name asc");
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll");
                    }
                    Utilities.Multi.Populate_LookUpEdit(Menu_UnitID, dtUnit, "ID", "Name");

                    Menu_UnitID.EditValue = int.Parse(frmEdit.vUnitID);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Menu_MenuGroupID_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Menu_TasteQTy.EditValue = null;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                if (Menu_MenuGroupID.EditValue == null || Menu_MenuGroupID.EditValue.ToString() == "")
                    return;

                if (int.Parse(Menu_MenuGroupID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                    layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                else
                    layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvListOfSizes_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvListOfSizes.FocusedRowHandle < 0)
                    return;

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa dòng kích cỡ?") != DialogResult.Yes)
                    return;

                gvListOfSizes.DeleteRow(gvListOfSizes.FocusedRowHandle);
                vdtMenu_Size.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}