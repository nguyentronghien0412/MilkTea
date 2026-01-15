using DevExpress.XtraEditors;
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
    public partial class pageSystem_groupUser_Role_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vTypeAction = "";
        public string vRoleID = "";

        DataTable dtRole = null;
        DataTable dtRoleDetail = null;

        BusinessLogicLayer.busRole bRole = new BusinessLogicLayer.busRole();
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        #region Functions

        private void ShowIconForTree(string CallBy, TreeListNode node)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                foreach (TreeListNode item in node.Nodes)
                {
                    if (item.GetValue(colType).ToString() == "PermissionGroup")
                        item.ImageIndex = 0;
                    else if (item.GetValue(colType).ToString() == "Permission")
                        item.ImageIndex = 1;
                    else if (item.GetValue(colType).ToString() == "PermissionDetail")
                        item.ImageIndex = 2;
                    ShowIconForTree(CallBy, item);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void LoadPermissionForRole(string CallBy, DataTable dtDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            foreach (DataRow dr in dtDetail.Rows)
            {
                string permdID = dr["PermissionDetailID"].ToString();
                foreach (TreeListNode node in tlRoleDetail.Nodes)
                    if (CheckedPermission(callFrom, node, permdID))
                        break;
            }
        }

        private bool CheckedPermission(string CallBy, TreeListNode node, string PermdID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (node.GetValue(colType).ToString() == "PermissionDetail" && node.GetValue(colMainID).ToString() == PermdID)
                {
                    node.CheckState = CheckState.Checked;
                    return true;
                }

                foreach (TreeListNode item in node.Nodes)
                    if (CheckedPermission(callFrom, item, PermdID))
                        return true;

                return false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return false;
            }
        }

        private void CheckPermissionToSave(string CallBy, TreeListNode node, ref DataTable dtDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (node.GetValue(colType).ToString() == "PermissionDetail" && node.Checked)
            {
                DataRow dr = dtDetail.NewRow();
                dr["PermissionDetailID"] = node.GetValue(colMainID);
                dtDetail.Rows.Add(dr);
            }

            foreach (TreeListNode item in node.Nodes)
                CheckPermissionToSave(callFrom, item, ref dtDetail);
        }

        private string CheckValid(string CallBy, ref DataTable dtDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (Role_Name.Text.Trim() == "")
                return "Vui lòng nhập Tên nhóm quyền.";

            if (Role_StatusID.EditValue == null || Role_StatusID.EditValue.ToString() == "")
                return "Vui lòng nhập Trạng thái";

            foreach (TreeListNode node in tlRoleDetail.Nodes)
                CheckPermissionToSave(callFrom, node, ref dtDetail);

            if (dtDetail.Rows.Count == 0)
                return "Vui lòng nhập quyền trước khi lưu.";

            return "";
        }

        #endregion

        #region Events

        public pageSystem_groupUser_Role_Edit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageSystem_groupUser_Role_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vRoleID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã nhóm quyền.");
                    return;
                }

                #region Init data

                DataTable dtStatus = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtStatus, "Status", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Status_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Status_GetAll");
                }

                Utilities.Multi.Populate_LookUpEdit(Role_StatusID, dtStatus, "ID", "Name");

                #endregion

                #region Load all perrmission

                DataTable dtPermDetail = new DataTable();
                result = bRole.GetAllPermissionToEdit(callFrom, ref dtPermDetail, vRoleID);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_GetAllPermissionToEdit:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_GetAllPermissionToEdit");
                }

                tlRoleDetail.DataSource = dtPermDetail;

                for (int i = 0; i < tlRoleDetail.Nodes.Count; i++)
                    ShowIconForTree(callFrom, tlRoleDetail.Nodes[i]);

                tlRoleDetail.ExpandAll();

                #endregion

                dtRole = new DataTable();
                result = bGeneral.GetByCondition(callFrom, ref dtRole, "Role", new string[] { "ID" }, new string[] { vRoleID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role -> GetByCondition");
                }

                dtRoleDetail = new DataTable();
                result = bGeneral.GetByCondition(callFrom, ref dtRoleDetail, "RoleDetail", new string[] { "RoleID" }, new string[] { vRoleID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> RoleDetail -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> RoleDetail -> GetByCondition");
                }

                if (vTypeAction == Utilities.Parameters.Permission_NEW)
                {
                    this.Text = "Nhóm Quyền - Tạo mới";

                    DataRow drRole = dtRole.NewRow();
                    drRole["StatusID"] = (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;
                    dtRole.Rows.Add(drRole);
                }
                else if (vTypeAction == Utilities.Parameters.Permission_EDIT)
                {
                    this.Text = "Nhóm Quyền - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(dtRole.Rows[0], this, callFrom);
                LoadPermissionForRole(callFrom, dtRoleDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void tlRoleDetail_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            e.Node.SelectImageIndex = 3;
        }

        private void tlRoleDetail_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.Node.CheckState == CheckState.Checked)
                {
                    e.Node.CheckAll();
                    e.Node.Checked = true;
                }
                else
                {
                    e.Node.UncheckAll();
                    e.Node.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtRoleDetail.Rows.Count > 0)
                    dtRoleDetail.Rows.Clear();

                string msg = CheckValid(callFrom, ref dtRoleDetail);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                if (dtRoleDetail.Rows.Count > 0)
                    dtRoleDetail.Rows.Clear();

                msg = CheckValid(callFrom, ref dtRoleDetail);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(dtRole.Rows[0], this, callFrom);

                DateTime actionDate = DateTime.Now;
                foreach (DataRow dr in dtRoleDetail.Rows)
                {
                    dr["CreatedBy"] = Utilities.Parameters.UserLogin.UserID;
                    dr["CreatedDate"] = actionDate;
                    dr["RoleID"] = dtRole.Rows[0]["ID"];
                }

                string result = "";
                if (vTypeAction == Utilities.Parameters.Permission_NEW)
                {
                    dtRole.Rows[0]["CreatedBy"] = Utilities.Parameters.UserLogin.UserID;
                    dtRole.Rows[0]["CreatedDate"] = actionDate;

                    result = bRole.Insert(callFrom, ref dtRole, dtRoleDetail);
                }
                else if (vTypeAction == Utilities.Parameters.Permission_EDIT)
                {
                    dtRole.Rows[0]["LastUpdatedBy"] = Utilities.Parameters.UserLogin.UserID;
                    dtRole.Rows[0]["LastUpdatedDate"] = actionDate;

                    result = bRole.Update(callFrom, dtRole, dtRoleDetail);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (vTypeAction == Utilities.Parameters.Permission_NEW)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_Update");
                    }

                    return;
                }
                else
                {
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

        #endregion
    }
}