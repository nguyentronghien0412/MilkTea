using BusinessLogicLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PresentationLayer
{
    public partial class pageSystem_groupUser_Login : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtUserInfo = new DataTable();

        public pageSystem_groupUser_Login()
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
            if (txtUsername.Text == "")
            {
                txtUsername.Focus();
                return "Vui lòng nhập Tên đăng nhập.";
            }
            if (txtPassword.Text == "")
            {
                txtPassword.Focus();
                return "Vui lòng nhập Mật khẩu.";
            }

            return "";
        }

        private void EnableControl(bool Value)
        {
            txtUsername.Enabled = Value;
            txtPassword.Enabled = Value;
            chkRememberUsername.Enabled = Value;
            btnLogin.Enabled = Value;
            btnClose.Enabled = Value;
        }

        private void pageSystem_groupUser_Login_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                EnableControl(false);

                if (Utilities.Parameters.Definition == null)
                    Utilities.Parameters.Definition = new DataObject.dtoDefinition();

                if (Utilities.Parameters.Definition.COLOR_REQUIRED == null ||
                    (Utilities.Parameters.Definition.COLOR_REQUIRED.A == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.R == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.G == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.B == 0))
                    Utilities.Parameters.Definition.COLOR_REQUIRED = System.Drawing.ColorTranslator.FromHtml("#70e9b6");

                Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);


                if (File.Exists(Utilities.Parameters.SystemConfig_FileName))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Utilities.Parameters.SystemConfig_FileName);

                    XmlNode nodeLogin = doc.SelectSingleNode("Root//Login");
                    if (nodeLogin != null &&
                        nodeLogin.Attributes["RememberUsername"] != null &&
                        nodeLogin.Attributes["RememberUsername"].Value == "1")
                    {
                        txtUsername.Text = nodeLogin.Attributes["Username"].Value;
                        chkRememberUsername.Checked = true;
                    }

                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }

                EnableControl(true);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!btnLogin.Enabled)
                    return;

                EnableControl(false);

                string _CheckValid = CheckValid();
                if (_CheckValid != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Warning, _CheckValid, 5000);
                    EnableControl(true);
                    return;
                }

                bool _Result = CheckPasswordUser(callFrom, txtUsername.Text, txtPassword.Text);
                if (!_Result)
                {
                    EnableControl(true);
                    return;
                }

                #region Save to config

                XmlDocument doc = new XmlDocument();
                doc.Load(Utilities.Parameters.SystemConfig_FileName);

                XmlNode nodeRoot = doc.SelectSingleNode("Root");

                XmlNode nodeLogin = doc.SelectSingleNode("Root//Login");
                if (nodeLogin == null)
                {
                    nodeLogin = doc.CreateNode(XmlNodeType.Element, "Login", null);
                    nodeRoot.AppendChild(nodeLogin);
                }

                if (nodeLogin.Attributes["RememberUsername"] != null && nodeLogin.Attributes["RememberUsername"].Value != null)
                    nodeLogin.Attributes["RememberUsername"].Value = chkRememberUsername.Checked ? "1" : "0";
                else
                    nodeLogin.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "RememberUsername", chkRememberUsername.Checked ? "1" : "0"));

                string username = "";
                if (chkRememberUsername.Checked)
                    username = txtUsername.Text;

                if (nodeLogin.Attributes["Username"] != null && nodeLogin.Attributes["Username"].Value != null)
                    nodeLogin.Attributes["Username"].Value = username;
                else
                    nodeLogin.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Username", username));

                doc.Save(Utilities.Parameters.SystemConfig_FileName);

                #endregion

                #region Set value for UserLogin

                Utilities.Parameters.UserLogin.UserID = dtUserInfo.Rows[0]["UserID"].ToString();
                Utilities.Parameters.UserLogin.EmployeesID = dtUserInfo.Rows[0]["EmployeesID"].ToString();
                Utilities.Parameters.UserLogin.UserName = dtUserInfo.Rows[0]["UserName"].ToString();
                Utilities.Parameters.UserLogin.Password = Utilities.Functions.DecryptByRC2(dtUserInfo.Rows[0]["Password"].ToString(), Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);
                Utilities.Parameters.UserLogin.EmployeesCode = dtUserInfo.Rows[0]["EmployeesCode"].ToString();
                Utilities.Parameters.UserLogin.EmployeesName = dtUserInfo.Rows[0]["EmployeesName"].ToString();
                Utilities.Parameters.UserLogin.Position = dtUserInfo.Rows[0]["Position"].ToString();
                Utilities.Parameters.UserLogin.LoginDate = DateTime.Now;

                #endregion

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private bool CheckPasswordUser(string CallBy, string Username, string PasswordInput)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dtUserInfo = new DataTable();

                busUsers bUsers = new busUsers();
                string result = bUsers.GetByUsername(callFrom, ref dtUserInfo, Username);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByUsername:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByUsername");
                    return false;
                }

                if (dtUserInfo != null && dtUserInfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtUserInfo.Rows.Count; i++)
                    {
                        string passUser = Utilities.Functions.DecryptByRC2(dtUserInfo.Rows[i]["Password"].ToString(), Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);
                        if (PasswordInput != passUser)
                        {
                            dtUserInfo.Rows.RemoveAt(i);
                            i = i - 1;
                        }
                    }

                    dtUserInfo.AcceptChanges();
                }

                if (dtUserInfo == null || dtUserInfo.Rows.Count == 0)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Tài khoản không tồn tại.");
                    return false;
                }

                if (dtUserInfo.Rows.Count > 1)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Dữ liệu lỗi (Tên đăng nhập và mật khẩu có@@@ " + dtUserInfo.Rows.Count + " @@@User đang dùng).");
                    return false;
                }

                if ((int)dtUserInfo.Rows[0]["UserStatus"] == (int)Utilities.CategoriesEnum.Status.Tạm_ngưng)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Tài khoản này đã ngưng hoạt động.");
                    return false;
                }

                if ((int)dtUserInfo.Rows[0]["EmployeesStatus"] == (int)Utilities.CategoriesEnum.Status.Tạm_ngưng)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Trạng thái của nhân viên này đã tạm ngưng.");
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
    }
}