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
    public partial class pageManagement_groupFunctions_TableAndDish_PrintBank : DevExpress.XtraEditors.XtraForm
    {
        public string _UserLogin_Name = "";
        public string _UserDefault_Name = "";
        public string _SelectedUser = "DEFAULT";

        public pageManagement_groupFunctions_TableAndDish_PrintBank()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _SelectedUser = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_PrintBank_Load(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnUserLogin.Text = _UserLogin_Name;
                btnUserDefault.Text = _UserDefault_Name;

                if (_UserLogin_Name == "")
                    btnUserLogin.Enabled = false;

                if (_UserDefault_Name == "")
                    btnUserDefault.Enabled = false;

            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            _SelectedUser = "LOGIN";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUserDefault_Click(object sender, EventArgs e)
        {
            _SelectedUser = "DEFAULT";
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}