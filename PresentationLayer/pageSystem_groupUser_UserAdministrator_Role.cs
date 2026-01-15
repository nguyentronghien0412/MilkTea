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
    public partial class pageSystem_groupUser_UserAdministrator_Role : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtRole = new DataTable();
        public List<string> lstRole = new List<string>();

        public pageSystem_groupUser_UserAdministrator_Role()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageSystem_groupUser_UserAdministrator_Role_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                BusinessLogicLayer.busUserAdministrator bUserAdministrator = new BusinessLogicLayer.busUserAdministrator();
                DataTable dtData = new DataTable();
                string result = bUserAdministrator.GetRole(callFrom, ref dtData, dtRole);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UserAdministrator_GetRole:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UserAdministrator_GetRole");
                    this.Close();
                }

                gcRole.DataSource = dtData;
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
                if (gvRole.SelectedRowsCount == 0)
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn ít nhất 1 nhóm quyền.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn thực hiện thao tác này?") != DialogResult.Yes)
                    return;

                lstRole = new List<string>();
                int[] lstID = gvRole.GetSelectedRows();
                foreach (int i in lstID)
                    lstRole.Add(gvRole.GetRowCellValue(i, colID).ToString());

                DialogResult = DialogResult.OK;
                this.Close();
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
    }
}