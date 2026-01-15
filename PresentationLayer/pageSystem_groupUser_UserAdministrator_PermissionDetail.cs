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
    public partial class pageSystem_groupUser_UserAdministrator_PermissionDetail : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtPermissionDetail = new DataTable();
        public List<string> lstPermissionDetail = new List<string>();

        string strPermissionGroupType = "PermissionGroupType";
        string strPermissionGroup = "PermissionGroup";
        string strPermission = "Permission";
        string strPermissionDetail = "PermissionDetail";

        BusinessLogicLayer.busUserAdministrator bUserAdministrator = new BusinessLogicLayer.busUserAdministrator();

        #region Functions

        private void TreeList_LoadImageIndex(string CallBy, TreeListNode node)
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
                    TreeList_LoadImageIndex(callFrom, item);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TreeList_CheckValid(string CallBy, TreeListNode node, ref bool IsChecked)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermissionDetail && node.CheckState == CheckState.Checked)
                {
                    IsChecked = true;
                    return;
                }

                foreach (TreeListNode item in node.Nodes)
                    TreeList_CheckValid(callFrom, item, ref IsChecked);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TreeList_GetPermissionDetail(string CallBy, TreeListNode node, ref List<string> lstID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (node.GetValue(coltlUserAndPermissionDetail_Type).ToString() == strPermissionDetail && node.CheckState == CheckState.Checked)
                    lstID.Add(node.GetValue(coltlUserAndPermissionDetail_MainID).ToString());

                foreach (TreeListNode item in node.Nodes)
                    TreeList_GetPermissionDetail(callFrom, item, ref lstID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageSystem_groupUser_UserAdministrator_PermissionDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageSystem_groupUser_UserAdministrator_PermissionDetail_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtData = new DataTable();
                string result = bUserAdministrator.GetPermissionDetail(callFrom, ref dtData, dtPermissionDetail);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_GetPermissionDetail:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_GetPermissionDetail");
                    this.Close();
                }

                tlPermissionDetail.DataSource = dtData;

                for (int i = 0; i < tlPermissionDetail.Nodes.Count; i++)
                    TreeList_LoadImageIndex(callFrom, tlPermissionDetail.Nodes[i]);

                tlPermissionDetail.ExpandAll();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void tlPermissionDetail_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                tlPermissionDetail.FocusedNode.SelectImageIndex = 3;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void tlPermissionDetail_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                bool isCheck = false;
                for (int i = 0; i < tlPermissionDetail.Nodes.Count; i++)
                    TreeList_CheckValid(callFrom, tlPermissionDetail.Nodes[i], ref isCheck);

                if (!isCheck)
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn ít nhất 1 quyền.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn thực hiện thao tác này?") != DialogResult.Yes)
                    return;

                lstPermissionDetail = new List<string>();
                for (int i = 0; i < tlPermissionDetail.Nodes.Count; i++)
                    TreeList_GetPermissionDetail(callFrom, tlPermissionDetail.Nodes[i], ref lstPermissionDetail);

                DialogResult = DialogResult.OK;
                this.Close();
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