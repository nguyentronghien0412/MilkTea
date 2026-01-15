using BusinessLogicLayer;
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
    public partial class pageSystem_groupUser_ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public pageSystem_groupUser_ChangePassword()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string CheckValid()
        {
            if (txtOldPassword.Text == "")
            {
                txtOldPassword.Focus();
                return "Vui lòng nhập Mật khẩu cũ.";
            }
            if (txtNewPassword.Text == "")
            {
                txtNewPassword.Focus();
                return "Vui lòng nhập Mật khẩu mới.";
            }
            if (txtRe_NewPassword.Text == "")
            {
                txtRe_NewPassword.Focus();
                return "Vui lòng nhập lại Mật khẩu mới.";
            }
            if (txtNewPassword.Text != txtRe_NewPassword.Text)
            {
                txtNewPassword.Focus();
                return "Vui lòng kiểm tra lại Mật khẩu mới.";
            }

            if (txtOldPassword.Text != Utilities.Parameters.UserLogin.Password)
            {
                txtRe_NewPassword.Focus();
                return "Mật khẩu cũ không đúng.";
            }

            return "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string checkValid = CheckValid();
                if (checkValid != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, checkValid, 5000);
                    return;
                }

                string newPassword = Utilities.Functions.EncryptByRC2(txtNewPassword.Text, Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);

                busGeneralFunctions bGeneral = new busGeneralFunctions();
                busUsers bUsers = new busUsers();

                DataTable dtUser = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtUser, "Users", new string[] { "ID" }, new string[] { Utilities.Parameters.UserLogin.UserID }, null);
                if (result != Utilities.Parameters.ResultMessage || dtUser == null || dtUser.Rows.Count == 0)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                }

                dtUser.Rows[0]["Password"] = newPassword;

                result = bUsers.ChangePassword(callFrom, dtUser);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> ChangePassword:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> ChangePassword");
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
    }
}