using DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
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
    public partial class pageSystem_groupUser_UserAdministrator : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        int selectedID = 0;

        string strPermissionGroupType = "PermissionGroupType";
        string strPermissionGroup = "PermissionGroup";
        string strPermission = "Permission";
        string strPermissionDetail = "PermissionDetail";

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busUsers bUsers = new BusinessLogicLayer.busUsers();
        BusinessLogicLayer.busUserAdministrator bUserAdministrator = new BusinessLogicLayer.busUserAdministrator();
        BusinessLogicLayer.busEmployees bEmployee = new BusinessLogicLayer.busEmployees();

        DataTable dtData_User = new DataTable();
        DataTable dtData_Employee = new DataTable();
        DataTable dtData_UserAndRole = new DataTable();
        DataTable dtData_UserAndPermissionDetail = new DataTable();

        #region Functions

        private bool CheckUserIsActive(string CallBy, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtUsers = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtUsers, "Users", new string[] { "ID" }, new string[] { UserID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return false;
                }

                if (dtUsers == null || dtUsers.Rows.Count == 0)
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Không tìm thấy thông tin người dùng.", 5000);
                    return false;
                }

                if (int.Parse(dtUsers.Rows[0]["StatusID"].ToString()) != (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động)
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Chỉ thao tác tài khoản đang hoạt động.", 5000);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return false;
            }
        }

        private void TreeList_GetLevelNodeMax(string CallBy, TreeListNode node, ref int LevelMax)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (node.Level > LevelMax)
                    LevelMax = node.Level;

                foreach (TreeListNode item in node.Nodes)
                    TreeList_GetLevelNodeMax(callFrom, item, ref LevelMax);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TreeList_GetNodeToDelete(string CallBy, TreeListNode node, ref List<TreeListNode> lstNodeDelete, TreeListColumn col, object ValueCompare)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!node.HasChildren && node.GetValue(col).ToString() != ValueCompare.ToString())
                    lstNodeDelete.Add(node);

                foreach (TreeListNode item in node.Nodes)
                    TreeList_GetNodeToDelete(callFrom, item, ref lstNodeDelete, col, ValueCompare);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TreeList_LoadImageIndex_UserAndPermissionDetail(string CallBy, TreeListNode node)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermissionGroup)
                    node.ImageIndex = 0;
                else if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermission)
                    node.ImageIndex = 1;
                else if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermissionDetail)
                    node.ImageIndex = 2;
                else if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermissionGroupType)
                    node.ImageIndex = 4;

                foreach (TreeListNode item in node.Nodes)
                    TreeList_LoadImageIndex_UserAndPermissionDetail(callFrom, item);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private DataTable CreateColumn_UserAndPermissionDetail(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {

                DataTable dtReturn = new DataTable();
                dtReturn.TableName = "UserAndPermissionDetail";

                string result = bUsers.GetPermissionDetails(callFrom, ref dtReturn, "0");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_GetPermissionDetails:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_GetPermissionDetails");
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return null;
            }
        }

        private DataTable CreateColumn_UserAndRole(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtReturn = new DataTable();
                dtReturn.TableName = "UserAndRole";

                string result = bGeneral.GetByCondition(callFrom, ref dtReturn, "UserAndRole", new string[] { "UserID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAndRole -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAndRole -> GetByCondition");
                    return null;
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return null;
            }
        }

        private DataTable CreateColumn_User(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtReturn = new DataTable();
                dtReturn.TableName = "Users";

                string result = bGeneral.GetByCondition(callFrom, ref dtReturn, "Users", new string[] { "ID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return null;
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return null;
            }
        }

        private DataTable CreateColumn_Employees(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtReturn = new DataTable();
                dtReturn.TableName = "Employees";

                string result = bGeneral.GetByCondition(callFrom, ref dtReturn, "Employees", new string[] { "ID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    return null;
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return null;
            }
        }

        private void AssignData_SameColumn(string CallBy, DataTable dtSource, ref DataTable dtDestination)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtDestination.Rows.Count > 0)
                    dtDestination.Rows.Clear();

                foreach (DataRow dr in dtSource.Rows)
                {
                    DataRow drAdd = dtDestination.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                        drAdd[col.ColumnName] = dr[col.ColumnName];

                    dtDestination.Rows.Add(drAdd);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void LoadEmployee(string CallBy, string EmployeeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region Users

                dtData_User = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtData_User, "Users", new string[] { "EmployeesID" }, new string[] { EmployeeID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_General_GetByCondition");
                }
                else
                {
                    if (dtData_User.Rows.Count > 0)
                    {
                        Utilities.Multi.AssignData_RowToForm(dtData_User.Rows[0], this, callFrom);

                        if (Users_Password.Text != string.Empty)
                            Users_Password.Text = Utilities.Functions.DecryptByRC2(Users_Password.Text, Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);

                        #region Role

                        DataTable dtSource = new DataTable();
                        result = bGeneral.GetByCondition(callFrom, ref dtSource, "UserAndRole", new string[] { "UserID" }, new string[] { dtData_User.Rows[0]["ID"].ToString() }, null);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAndRole -> General_GetByCondition:\n" + result);
                            Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAndRole -> General_GetByCondition");
                        }
                        else
                        {
                            AssignData_SameColumn(callFrom, dtSource, ref dtData_UserAndRole);
                            gcRole.DataSource = dtData_UserAndRole;
                        }

                        #endregion

                        #region PermissionDetails

                        dtSource = new DataTable();
                        result = bUsers.GetPermissionDetails(callFrom, ref dtSource, dtData_User.Rows[0]["ID"].ToString());
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_GetPermissionDetails:\n" + result);
                            Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_GetPermissionDetails");
                        }
                        else
                        {
                            AssignData_SameColumn(callFrom, dtSource, ref dtData_UserAndPermissionDetail);

                            tlUserAndPermissionDetail.DataSource = dtData_UserAndPermissionDetail;
                            for (int i = 0; i < tlUserAndPermissionDetail.Nodes.Count; i++)
                                TreeList_LoadImageIndex_UserAndPermissionDetail(callFrom, tlUserAndPermissionDetail.Nodes[i]);

                            tlUserAndPermissionDetail.ExpandAll();
                        }

                        #endregion
                    }
                    else
                    {
                        DataRow drUser = dtData_User.NewRow();
                        dtData_User.Rows.Add(drUser);
                    }
                }

                #endregion

                #region Employees

                dtData_Employee = new DataTable();
                result = bGeneral.GetByCondition(callFrom, ref dtData_Employee, "Employees", new string[] { "ID" }, new string[] { EmployeeID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees_General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees_General_GetByCondition");
                }
                else
                {
                    Utilities.Multi.AssignData_RowToForm(dtData_Employee.Rows[0], this, callFrom);
                }

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ClearData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Employees_Code.Text = string.Empty;
                Employees_FullName.Text = string.Empty;
                Employees_GenderID.EditValue = DBNull.Value;
                Employees_IdentityCode.Text = string.Empty;
                Employees_BirthDay.Text = string.Empty;
                Employees_Email.Text = string.Empty;
                Employees_Address.Text = string.Empty;
                Employees_CellPhone.Text = string.Empty;
                Employees_StartWorkingDate.Text = string.Empty;
                Employees_EndWorkingDate.Text = string.Empty;
                Employees_PositionID.EditValue = DBNull.Value;
                
                Employees_SalaryByHour.Text = "";
                Employees_CalcSalaryByMinutes.Text = "";
                Employees_TimekeepingOther.Checked = false;
                Employees_ShiftFrom.Text = string.Empty;
                Employees_ShiftTo.Text = string.Empty;
                Employees_IsBreakTime.Checked = false;
                Employees_BreakTimeFrom.Text = string.Empty;
                Employees_BreakTimeTo.Text = string.Empty;

                Users_UserName.Text = string.Empty;
                Users_Password.Text = string.Empty;
                Users_StatusID.EditValue = DBNull.Value;

                Employees_BankName.Text = string.Empty;
                Employees_Bank_AccountName.Text = string.Empty;
                Employees_Bank_AccountNumber.Text = string.Empty;
                Employees_Bank_QRCode.Image = null;

                if (dtData_UserAndPermissionDetail != null && dtData_UserAndPermissionDetail.Rows.Count > 0)
                    dtData_UserAndPermissionDetail.Rows.Clear();
                tlUserAndPermissionDetail.DataSource = dtData_UserAndPermissionDetail;

                if (dtData_UserAndRole != null && dtData_UserAndRole.Rows.Count > 0)
                    dtData_UserAndRole.Rows.Clear();
                gcRole.DataSource = dtData_UserAndRole;

                if (dtData_Employee != null && dtData_Employee.Rows.Count > 0)
                    dtData_Employee.Rows.Clear();

                if (dtData_User != null && dtData_User.Rows.Count > 0)
                    dtData_User.Rows.Clear();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }            
        }

        private void EnableControl(string CallBy, bool IsEnable)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Employees_Code.ReadOnly = !IsEnable;
                Employees_FullName.ReadOnly = !IsEnable;
                Employees_GenderID.ReadOnly = !IsEnable;
                Employees_IdentityCode.ReadOnly = !IsEnable;
                Employees_BirthDay.ReadOnly = !IsEnable;
                Employees_Email.ReadOnly = !IsEnable;
                Employees_Address.ReadOnly = !IsEnable;
                Employees_CellPhone.ReadOnly = !IsEnable;
                Employees_StartWorkingDate.ReadOnly = !IsEnable;
                Employees_EndWorkingDate.ReadOnly = !IsEnable;
                Employees_PositionID.ReadOnly = !IsEnable;
                Employees_StatusID.ReadOnly = !IsEnable;

                Employees_SalaryByHour.ReadOnly = !IsEnable;
                Employees_CalcSalaryByMinutes.ReadOnly = !IsEnable;
                Employees_TimekeepingOther.ReadOnly = !IsEnable;
                Employees_ShiftFrom.ReadOnly = !IsEnable;
                Employees_ShiftTo.ReadOnly = !IsEnable;
                Employees_IsBreakTime.ReadOnly = !IsEnable;
                Employees_BreakTimeFrom.ReadOnly = false;
                Employees_BreakTimeTo.ReadOnly = false;

                btnPositionAdd.Enabled = IsEnable;
                if (IsEnable)
                    if (!Utilities.Multi.CheckRight_PermissionByCode("pageCategories_groupSystem_Position", Utilities.Parameters.Permission_NEW))
                        btnPositionAdd.Enabled = false;

                Users_UserName.ReadOnly = !IsEnable;
                Users_StatusID.ReadOnly = !IsEnable;

                btnAddPermission.Enabled = IsEnable;
                tlUserAndPermissionDetail_FocusedNodeChanged(null, null);

                btnAddRole.Enabled = IsEnable;
                gvRole_FocusedRowChanged(null, null);

                gcList.Enabled = !IsEnable;
                lkStatus.ReadOnly = IsEnable;

                Employees_BankName.ReadOnly = !IsEnable;
                Employees_Bank_AccountName.ReadOnly = !IsEnable;
                Employees_Bank_AccountNumber.ReadOnly = !IsEnable;
                Employees_Bank_QRCode.ReadOnly = !IsEnable;

                if (IsEnable)
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
                else
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Employees_Address.BackColor);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }            
        }

        public void New(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                this.Tag = Utilities.Parameters.Permission_NEW;

                ClearData(callFrom);
                EnableControl(callFrom, true);

                gcList.Enabled = false;

                Users_Password.Text = Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD;
                Employees_StatusID.EditValue = (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;

                if (dtData_Employee.Rows.Count > 0)
                    dtData_Employee.Rows.Clear();
                DataRow drEmployee = dtData_Employee.NewRow();
                dtData_Employee.Rows.Add(drEmployee);

                if (dtData_User.Rows.Count > 0)
                    dtData_User.Rows.Clear();
                DataRow drUser = dtData_User.NewRow();
                dtData_User.Rows.Add(drUser);

                Employees_FullName.Focus();

                frmMain.EnableAction(false, true, false, false, true, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Edit(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                this.Tag = Utilities.Parameters.Permission_EDIT;

                EnableControl(callFrom, true);
                Employees_FullName.SelectAll();
                Employees_FullName.Focus();

                gcList.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionDetail(Utilities.Parameters.Permission_UPDATE_ACCOUNT))
                {
                    Users_UserName.ReadOnly = false;
                    Users_StatusID.ReadOnly = false;
                }
                else
                {
                    Users_UserName.ReadOnly = true;
                    Users_StatusID.ReadOnly = true;
                }

                if (dtData_User.Rows[0]["ID"].ToString() == string.Empty)
                    Users_Password.Text = Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD;

                if (Employees_IsBreakTime.Checked)
                {
                    Employees_BreakTimeFrom.ReadOnly = false;
                    Employees_BreakTimeTo.ReadOnly = false;
                }
                else
                {
                    Employees_BreakTimeFrom.ReadOnly = true;
                    Employees_BreakTimeTo.ReadOnly = true;
                }

                frmMain.EnableAction(false, true, false, false, true, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private bool CheckUsernameToAdd(string CallBy, string UserName)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtUs = new DataTable();
                string result = bUsers.GetByUsername(callFrom, ref dtUs, UserName);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_GetByUsername:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_GetByUsername");
                    return true;
                }

                if (dtUs != null && dtUs.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return true;
            }
        }

        private bool CheckUsernameToEdit(string CallBy, string UserName, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtUs = new DataTable();
                string result = bUsers.GetToEdit(callFrom, ref dtUs, UserName, UserID);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_GetToEdit:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_GetToEdit");
                    return true;
                }

                if (dtUs != null && dtUs.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return true;
            }
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW ||
                    (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT && dtData_User.Rows[0]["ID"].ToString() == string.Empty))
                {
                    if (CheckUsernameToAdd(callFrom, Users_UserName.Text))
                        return "Tên đăng nhập (" + Users_UserName.Text + ") đã sử dụng.";
                }
                else if (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    if (CheckUsernameToEdit(callFrom, Users_UserName.Text, dtData_User.Rows[0]["ID"].ToString()))
                        return "Tên đăng nhập (" + Users_UserName.Text + ") đã sử dụng.";
                }

                if (Employees_Email.Text.Trim() != "" && !Utilities.Functions.IsValidEmail(Employees_Email.Text))
                    return "Email không hợp lệ.";

                if (Employees_CalcSalaryByMinutes.Text != "" && int.Parse(Employees_CalcSalaryByMinutes.Text) > 60)
                    return "Tính lương theo phút phải <= 60 phút";

                if (Employees_IsBreakTime.Checked)
                    if (Employees_BreakTimeFrom.Text == "" || Employees_BreakTimeTo.Text == "")
                        return "Vui lòng nhập Giờ nghỉ giữa ca";

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        public void Save(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                msg = "Bạn muốn lưu dữ liệu?";
                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                {
                    string fullName = Employees_FullName.Text.Trim();
                    string gender = Employees_GenderID.EditValue.ToString();
                    string birthday = Employees_BirthDay.Text.Trim();
                    DataTable dtTemp = new DataTable();
                    string rs = bEmployee.CheckToAdd(callFrom, ref dtTemp, fullName, gender, birthday);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                        msg = "Đã có nhân viên trùng Họ tên, Giới tính và Ngày sinh." + "\n" + "Bạn muốn lưu dữ liệu?";
                }

                if (Utilities.Functions.MessageBoxYesNo(msg) != DialogResult.Yes)
                    return;

                #region Prepare data

                tlUserAndPermissionDetail.CloseEditor();
                dtData_UserAndPermissionDetail.AcceptChanges();

                gvRole.CloseEditor();
                dtData_UserAndRole.AcceptChanges();

                Utilities.Multi.AssignData_FormToRow(dtData_User.Rows[0], this, callFrom);
                dtData_User.AcceptChanges();

                Utilities.Multi.AssignData_FormToRow(dtData_Employee.Rows[0], this, callFrom);
                dtData_Employee.AcceptChanges();

                #endregion

                string result = "";
                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                {
                    result = bUsers.Insert(callFrom, ref dtData_Employee, ref dtData_User, ref dtData_UserAndRole,
                                                                    ref dtData_UserAndPermissionDetail, int.Parse(Utilities.Parameters.UserLogin.UserID));
                }
                else if (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    result = bUsers.Update(callFrom, dtData_Employee, dtData_User, dtData_UserAndRole,
                                                                    dtData_UserAndPermissionDetail, int.Parse(Utilities.Parameters.UserLogin.UserID));
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_Update");
                    }
                    return;
                }
                else
                {
                    this.Tag = Utilities.Parameters.Permission_SAVE;

                    string employeeID = dtData_Employee.Rows[0]["ID"].ToString();

                    lkStatus_EditValueChanged(null, null);
                    EnableControl(callFrom, false);

                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        if (gvList.GetRowCellValue(i, colID) != null && gvList.GetRowCellValue(i, colID).ToString() == employeeID)
                        {
                            gvList.SelectRow(i);
                            gvList.FocusedRowHandle = i;
                            break;
                        }
                    }

                    gvList_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Cancel(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn bỏ qua thao tác này?") != DialogResult.Yes)
                    return;

                this.Tag = Utilities.Parameters.Permission_CANCEL;

                EnableControl(callFrom, false);
                gvList_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                lkStatus_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageSystem_groupUser_UserAdministrator()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Quản trị người dùng.");
                this.Close();
            }
        }

        private void pageSystem_groupUser_UserAdministrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageSystem_groupUser_UserAdministrator_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageSystem_groupUser_UserAdministrator_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //labelControl23.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;
            //labelControl23.ForeColor = Utilities.Parameters.Definition.COLOR_REQUIRED;
            try
            {
                if (Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD == null || Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD == "")
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Vui lòng cài đặt MẬT KHẨU MẶC ĐỊNH.");

                #region Init data

                this.Tag = Utilities.Parameters.Permission_LOAD;
                Employees_Code.Focus();
                EnableControl(callFrom, false);

                dtData_UserAndPermissionDetail = CreateColumn_UserAndPermissionDetail(callFrom);
                tlUserAndPermissionDetail.DataSource = dtData_UserAndPermissionDetail;

                dtData_UserAndRole = CreateColumn_UserAndRole(callFrom);
                gcRole.DataSource = dtData_UserAndRole;

                dtData_User = CreateColumn_User(callFrom);
                dtData_Employee = CreateColumn_Employees(callFrom);

                #region Gender

                DataTable dtGender = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtGender, "Gender", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Gender -> General_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Gender -> General_GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(Employees_GenderID, dtGender, "ID", "Name");

                #endregion

                #region Position

                DataTable dtPosition = new DataTable();
                result = bGeneral.GetAll(callFrom, ref dtPosition, "Position", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Position -> General_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Position -> General_GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(Employees_PositionID, dtPosition, "ID", "Name");

                #endregion

                #region Status

                DataTable dtStatus = new DataTable();
                result = bGeneral.GetAll(callFrom, ref dtStatus, "Status", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Status -> General_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Status -> General_GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(Employees_StatusID, dtStatus, "ID", "Name");
                Utilities.Multi.Populate_LookUpEdit(Users_StatusID, dtStatus, "ID", "Name");
                Utilities.Multi.Populate_LookUpEdit(lkStatus, dtStatus, "ID", "Name");

                #endregion

                #region Role

                DataTable dtRole = new DataTable();
                result = bGeneral.GetAll(callFrom, ref dtRole, "Role", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role -> General_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role -> General_GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(rlkcolUserAndRole_RoleID, dtRole, "ID", "Name");

                #endregion

                #region Users

                DataTable dtUsers = new DataTable();
                result = bUsers.GetAll(callFrom, ref dtUsers);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(rlkcolUserAndRole_CreatedBy, dtUsers, "ID", "Name");

                #endregion

                #endregion

                if (!Utilities.Multi.CheckRight_PermissionDetail(Utilities.Parameters.Permission_SET_RIGHT))
                    tabDecentralization.PageVisible = false;

                lkStatus.EditValue = (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;
                lkStatus_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ClearData(callFrom);
                if (gvList.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                selectedID = int.Parse(gvList.GetFocusedRowCellValue(colID).ToString());

                LoadEmployee(callFrom, selectedID.ToString());

                frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
                gvList.CollapseAllGroups();
            else
                gvList.ExpandAllGroups();
        }

        private void btnPositionAdd_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageCategories_groupSystem_Position_Edit frmEdit = new pageCategories_groupSystem_Position_Edit();
                frmEdit.typeAction = Utilities.Parameters.Permission_NEW;
                frmEdit.positionID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    #region Position

                    DataTable dtPosition = new DataTable();
                    string result = bGeneral.GetAll(callFrom, ref dtPosition, "Position", "Name asc");
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetAll:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetAll");
                    }
                    Utilities.Multi.Populate_LookUpEdit(Employees_PositionID, dtPosition, "ID", "Name");

                    #endregion

                    Employees_PositionID.EditValue = frmEdit.dtPosition.Rows[0]["ID"];
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void tlUserAndPermissionDetail_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnDeletePermission.Enabled = false;
                if (tlUserAndPermissionDetail.FocusedNode == null)
                    return;

                if (this.Tag != null &&
                    (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                    )
                {
                    if (tlUserAndPermissionDetail.FocusedNode.GetValue(coltlUserAndPermissionDetail_Type) != null &&
                        tlUserAndPermissionDetail.FocusedNode.GetValue(coltlUserAndPermissionDetail_Type).ToString() == "PermissionDetail")
                        btnDeletePermission.Enabled = true;
                }

                tlUserAndPermissionDetail.FocusedNode.SelectImageIndex = 3;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvEmployees_PositionID_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvRole_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnDeleteRole.Enabled = false;
                if (gvRole.FocusedRowHandle < 0)
                    return;

                if (this.Tag != null &&
                    (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                    )
                {
                    btnDeleteRole.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvRole_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnDeletePermission_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (tlUserAndPermissionDetail.FocusedNode == null ||
                    tlUserAndPermissionDetail.FocusedNode.GetValue(coltlUserAndPermissionDetail_Type).ToString() != "PermissionDetail")
                {
                    btnDeletePermission.Enabled = false;
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa quyền này?") != DialogResult.Yes)
                    return;

                tlUserAndPermissionDetail.Nodes.Remove(tlUserAndPermissionDetail.FocusedNode);
                dtData_UserAndPermissionDetail.AcceptChanges();
                tlUserAndPermissionDetail.PostEditor();

                int levelMax = 0;
                for (int i = 0; i < tlUserAndPermissionDetail.Nodes.Count; i++)
                    TreeList_GetLevelNodeMax(callFrom, tlUserAndPermissionDetail.Nodes[i], ref levelMax);

                List<TreeListNode> lstNodeDelete;
                for (int k = 0; k <= levelMax; k++)
                    for (int i = 0; i < tlUserAndPermissionDetail.Nodes.Count; i++)
                    {
                        lstNodeDelete = new List<TreeListNode>();
                        TreeList_GetNodeToDelete(callFrom, tlUserAndPermissionDetail.Nodes[i], ref lstNodeDelete, coltlUserAndPermissionDetail_Type, strPermissionDetail);
                        foreach (TreeListNode node in lstNodeDelete)
                            tlUserAndPermissionDetail.Nodes.Remove(node);
                    }
                tlUserAndPermissionDetail.PostEditor();
                tlUserAndPermissionDetail.Refresh();
                dtData_UserAndPermissionDetail.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvRole.FocusedRowHandle < 0)
                {
                    btnDeleteRole.Enabled = false;
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa nhóm quyền này?") != DialogResult.Yes)
                    return;

                gvRole.DeleteRow(gvRole.FocusedRowHandle);
                dtData_UserAndRole.AcceptChanges();
                gvRole.PostEditor();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageSystem_groupUser_UserAdministrator_PermissionDetail frmPermissionDetail = new pageSystem_groupUser_UserAdministrator_PermissionDetail();
                frmPermissionDetail.dtPermissionDetail = dtData_UserAndPermissionDetail;
                DialogResult dlg = frmPermissionDetail.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    DataTable dtPermissionDetailAdd = new DataTable();
                    string result = bUserAdministrator.GetPermissionDetailToAdd(callFrom, ref dtPermissionDetailAdd, frmPermissionDetail.lstPermissionDetail);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_GetPermissionDetailToAdd:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_GetPermissionDetailToAdd");
                        return;
                    }

                    foreach (DataRow dr in dtPermissionDetailAdd.Rows)
                        if (!dtData_UserAndPermissionDetail.AsEnumerable().Any(row => (decimal)dr["ID"] == row.Field<decimal>("ID")))
                        {
                            DataRow drAdd = dtData_UserAndPermissionDetail.NewRow();

                            drAdd["Name"] = dr["Name"].ToString();
                            drAdd["ID"] = dr["ID"];
                            drAdd["ParentID"] = dr["ParentID"];
                            drAdd["Type"] = dr["Type"];
                            drAdd["MainID"] = dr["MainID"];

                            dtData_UserAndPermissionDetail.Rows.Add(drAdd);
                        }

                    dtData_UserAndPermissionDetail.AcceptChanges();

                    for (int i = 0; i < tlUserAndPermissionDetail.Nodes.Count; i++)
                        TreeList_LoadImageIndex_UserAndPermissionDetail(callFrom, tlUserAndPermissionDetail.Nodes[i]);

                    tlUserAndPermissionDetail.PostEditor();
                    tlUserAndPermissionDetail.Refresh();
                    tlUserAndPermissionDetail.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageSystem_groupUser_UserAdministrator_Role frmRole = new pageSystem_groupUser_UserAdministrator_Role();
                frmRole.dtRole = dtData_UserAndRole;
                DialogResult dlg = frmRole.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    DataTable dtRoleAdd = new DataTable();
                    string result = bUserAdministrator.GetRoleToAdd(callFrom, ref dtRoleAdd, frmRole.lstRole);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_GetRoleToAdd:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_GetRoleToAdd");
                        return;
                    }

                    foreach (DataRow dr in dtRoleAdd.Rows)
                        if (!dtData_UserAndRole.AsEnumerable().Any(row => (int)dr["ID"] == row.Field<int>("RoleID")))
                        {
                            DataRow drAdd = dtData_UserAndRole.NewRow();
                            drAdd["RoleID"] = dr["ID"];
                            dtData_UserAndRole.Rows.Add(drAdd);
                        }

                    dtData_UserAndRole.AcceptChanges();
                    gvRole.PostEditor();
                    gvRole.RefreshData();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_UserAdministrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.Tag != null && (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT))
                {
                    if (Utilities.Functions.MessageBoxYesNo("Thông tin quản trị người dùng chưa được lưu.\nBạn muốn đóng giao diện này?") != DialogResult.Yes)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Employees_IdentityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Employees_CellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Employees_BirthDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            const char CheckMark = (char)47;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != CheckMark;
        }

        private void gvList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvList.FocusedRowHandle < 0)
                    return;

                object employeeID = gvList.GetFocusedRowCellValue(colID);
                if (employeeID == null || employeeID.ToString() == "")
                    return;

                DataTable dtUsers = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtUsers, "Users", new string[] { "EmployeesID" }, new string[] { employeeID.ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    return;
                }

                if (dtUsers == null || dtUsers.Rows.Count == 0)
                    return;

                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    contextMenuStrip1.Show(view.GridControl, e.Point);
                }

                if (Utilities.Multi.CheckRight_PermissionDetail(Utilities.Parameters.Permission_RESET_PASSWORD))
                    itemResetPassword.Visible = true;
                else
                    itemResetPassword.Visible = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void itemResetPassword_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvList.FocusedRowHandle < 0)
                    return;

                object employeeID = gvList.GetFocusedRowCellValue(colID);
                if (employeeID == null || employeeID.ToString() == "")
                    return;

                DataTable dtUsers = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtUsers, "Users", new string[] { "EmployeesID" }, new string[] { employeeID.ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    return;
                }

                if (dtUsers == null || dtUsers.Rows.Count == 0)
                    return;

                string userID = dtUsers.Rows[0]["ID"].ToString();

                if (userID == "")
                    return;

                if (!CheckUserIsActive(callFrom, userID))
                    return;

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn Khởi tạo lại mật khẩu?") != DialogResult.Yes)
                    return;

                dtoUsers User = new dtoUsers();
                User.ID = userID;
                User.Password = Utilities.Functions.EncryptByRC2(Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD, Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);
                User.Password_ResetBy = Utilities.Parameters.UserLogin.UserID;
                User.Password_ResetDate = DateTime.Now;

                BusinessLogicLayer.busUsers bUsers = new BusinessLogicLayer.busUsers();
                result = bUsers.ResetPassword(callFrom, User);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Users_ResetPassword:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Users_ResetPassword");
                    return;
                }
                else
                    Utilities.Functions.MessageBox("N", Utilities.Parameters.Result, "Khởi tạo mật khẩu thành công. Mật khẩu mặc định:" + Utilities.Parameters.Definition.USER_DEFAULT_PASSWORD, 5000);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void lkStatus_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (lkStatus.EditValue == null || lkStatus.EditValue.ToString() == "")
                    return;

                DataTable dtEmployee = new DataTable();
                string vResult = bEmployee.GetByStatus(callFrom, ref dtEmployee, lkStatus.EditValue.ToString());
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employee_GetByStatus:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Employee_GetByStatus");
                }

                gcList.DataSource = dtEmployee;

                if (selectedID > 0)
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        if (gvList.GetRowCellValue(i, colID) != null && gvList.GetRowCellValue(i, colID).ToString() == selectedID.ToString())
                        {
                            gvList.SelectRow(i);
                            gvList.FocusedRowHandle = i;
                            break;
                        }
                    }
                gvList.ExpandAllGroups();

                if (gvList.RowCount == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Employees_IsBreakTime_CheckedChanged(object sender, EventArgs e)
        {
            if (Employees_IsBreakTime.Checked)
            {
                if (this.Tag != null && (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT))
                {
                    Employees_BreakTimeFrom.ReadOnly = false;
                    Employees_BreakTimeTo.ReadOnly = false;
                }
                else
                {
                    Employees_BreakTimeFrom.ReadOnly = true;
                    Employees_BreakTimeTo.ReadOnly = true;
                }
            }
            else
            {
                Employees_BreakTimeFrom.Text = string.Empty;
                Employees_BreakTimeTo.Text = string.Empty;

                Employees_BreakTimeFrom.ReadOnly = true;
                Employees_BreakTimeTo.ReadOnly = true;
            }
        }
    }
}