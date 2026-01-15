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
    public partial class pageSystem_groupUser_Role : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        BusinessLogicLayer.busRole bRole = new BusinessLogicLayer.busRole();
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        int arrIndex = -1;

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
                    ShowIconForTree(callFrom, item);
                }
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
                pageSystem_groupUser_Role_Edit frmEdit = new pageSystem_groupUser_Role_Edit();
                frmEdit.vTypeAction = Utilities.Parameters.Permission_NEW;
                frmEdit.vRoleID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                    pageSystem_groupUser_Role_Load(null, null);
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
                if (gvRole.FocusedRowHandle < 0)
                {
                    tlRoleDetail.DataSource = null;
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Nhóm quyền cần cập nhật.", 5000);
                    return;
                }

                string RoleID = gvRole.GetFocusedRowCellValue(colID).ToString();

                pageSystem_groupUser_Role_Edit frmEdit = new pageSystem_groupUser_Role_Edit();
                frmEdit.vTypeAction = Utilities.Parameters.Permission_EDIT;
                frmEdit.vRoleID = RoleID;
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                    pageSystem_groupUser_Role_Load(null, null);
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
                pageSystem_groupUser_Role_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private bool RoleIsUsing(string CallBy, string RoleID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtCheck = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "UserAndRole", new string[] { "RoleID" }, new string[] { RoleID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    return true;
                }

                if (dtCheck.Rows.Count > 0)
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

        public void Delete(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvRole.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Nhóm quyền cần xóa.", 5000);
                    return;
                }

                string msg = "";
                string roleID = gvRole.GetFocusedRowCellValue(colID).ToString();
                if (RoleIsUsing(callFrom, roleID))
                {
                    frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);

                    msg = "Không thể xóa, vì nhóm quyền  (" + gvRole.GetFocusedRowCellValue(colName).ToString() + ")  đang được sử dụng.";
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa Nhóm quyền '" + gvRole.GetFocusedRowCellValue(colName).ToString() + "'?") != DialogResult.Yes)
                    return;

                if (RoleIsUsing(callFrom, roleID))
                {
                    frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);

                    msg = "Không thể xóa, vì nhóm quyền (" + gvRole.GetFocusedRowCellValue(colName).ToString() + ") đang được sử dụng.";
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                string result = bRole.Delete(callFrom, roleID);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_Delete");
                    return;
                }

                pageSystem_groupUser_Role_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageSystem_groupUser_Role()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Danh mục Nhóm quyền.");
                this.Close();
            }
        }

        private void pageSystem_groupUser_Role_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtRole = new DataTable();
                string result = bRole.GetAll(callFrom, ref dtRole);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_GetAll");
                }

                gcRole.DataSource = dtRole;

                gvRole_FocusedRowChanged(null, null);

                if (dtRole == null || dtRole.Rows.Count == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvRole_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvRole_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvRole.FocusedRowHandle < 0)
                {
                    tlRoleDetail.DataSource = null;
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                string RoleID = gvRole.GetFocusedRowCellValue(colID).ToString();
                DataTable dtRoleDetail = new DataTable();
                string result = bRole.GetByID(callFrom, ref dtRoleDetail, RoleID);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_GetByID:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_GetByID");
                }

                tlRoleDetail.DataSource = dtRoleDetail;

                for (int i = 0; i < tlRoleDetail.Nodes.Count; i++)
                    ShowIconForTree(callFrom, tlRoleDetail.Nodes[i]);

                tlRoleDetail.ExpandAll();

                if (RoleIsUsing(callFrom, RoleID))
                    frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(true, false, true, true, false, true, false, false, false, arrIndex);
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

        private void pageSystem_groupUser_Role_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageSystem_groupUser_Role_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        #endregion
    }
}