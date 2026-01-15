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
    public partial class pageSystem_groupConfiguration_ConnectToDatabase : DevExpress.XtraEditors.XtraForm
    {
        public pageSystem_groupConfiguration_ConnectToDatabase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageSystem_groupConfiguration_ConnectToDatabase_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
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
                    XmlNode node = doc.SelectSingleNode(@"Root/DatabaseConfiguration");
                    txtServer.Text = Utilities.Functions.DecryptByRC2(node.Attributes["Server"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                    txtPort.Text = Utilities.Functions.DecryptByRC2(node.Attributes["Port"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                    txtUserName.Text = Utilities.Functions.DecryptByRC2(node.Attributes["Username"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                    txtPassword.Text = Utilities.Functions.DecryptByRC2(node.Attributes["Password"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                    txtDatabase.Text = Utilities.Functions.DecryptByRC2(node.Attributes["Database"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTestConnectToDatabase_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.");
                    return;
                }

                BusinessLogicLayer.busSystemConfiguration SystemConfig = new BusinessLogicLayer.busSystemConfiguration();

                string _IsConnect = SystemConfig.TestConnectToDatabase(callFrom, txtServer.Text, txtPort.Text, txtDatabase.Text, txtUserName.Text, txtPassword.Text);
                if (_IsConnect == Utilities.Parameters.ResultMessage)
                    Utilities.Functions.MessageBoxOK("N", Utilities.Parameters.Result, "Kết nối với cơ sở dữ liệu thành công !!!");
                else
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không thể kết nối với cơ sở dữ liệu: " + _IsConnect);
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
                #region Check valid

                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.");
                    return;
                }

                BusinessLogicLayer.busSystemConfiguration SystemConfig = new BusinessLogicLayer.busSystemConfiguration();
                string _IsConnect = SystemConfig.TestConnectToDatabase(callFrom, txtServer.Text, txtPort.Text, txtDatabase.Text, txtUserName.Text, txtPassword.Text);
                if (_IsConnect != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không thể kết nối với cơ sở dữ liệu: " + _IsConnect);
                    return;
                }

                #endregion

                #region Set data

                string server = Utilities.Functions.EncryptByRC2(txtServer.Text, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);

                string port = "";
                if (txtPort.Text != "")
                    port = Utilities.Functions.EncryptByRC2(txtPort.Text, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                
                string username = Utilities.Functions.EncryptByRC2(txtUserName.Text, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                string password = Utilities.Functions.EncryptByRC2(txtPassword.Text, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                string database = Utilities.Functions.EncryptByRC2(txtDatabase.Text, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);

                #endregion

                #region Save to config file

                XmlDocument doc = new XmlDocument();
                if (!File.Exists(Utilities.Parameters.SystemConfig_FileName))
                {
                    //create new file
                    string xmlInfo = string.Format("<Root Email=\"{0}\" Phone=\"{1}\">" +
                        "<DatabaseConfiguration Server=\"{2}\" Database=\"{3}\" Username=\"{4}\" Password=\"{5}\" Port=\"{6}\" />" +
                        "</Root>", "nguyentronghien0412@gmail.com", "0937410899", server, database, username, password, port);
                    doc.LoadXml(xmlInfo);
                }
                else
                {
                    doc.Load(Utilities.Parameters.SystemConfig_FileName);

                    XmlNode nodeDatabaseConfiguration = doc.SelectSingleNode(@"Root/DatabaseConfiguration");

                    if (nodeDatabaseConfiguration.Attributes["Server"] != null && nodeDatabaseConfiguration.Attributes["Server"].Value != null)
                        nodeDatabaseConfiguration.Attributes["Server"].Value = server;
                    else
                        nodeDatabaseConfiguration.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Server", server));

                    if (nodeDatabaseConfiguration.Attributes["Port"] != null && nodeDatabaseConfiguration.Attributes["Port"].Value != null)
                        nodeDatabaseConfiguration.Attributes["Port"].Value = port;
                    else
                        nodeDatabaseConfiguration.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Port", port));

                    if (nodeDatabaseConfiguration.Attributes["Username"] != null && nodeDatabaseConfiguration.Attributes["Username"].Value != null)
                        nodeDatabaseConfiguration.Attributes["Username"].Value = username;
                    else
                        nodeDatabaseConfiguration.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Username", username));

                    if (nodeDatabaseConfiguration.Attributes["Password"] != null && nodeDatabaseConfiguration.Attributes["Password"].Value != null)
                        nodeDatabaseConfiguration.Attributes["Password"].Value = password;
                    else
                        nodeDatabaseConfiguration.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Password", password));

                    if (nodeDatabaseConfiguration.Attributes["Database"] != null && nodeDatabaseConfiguration.Attributes["Database"].Value != null)
                        nodeDatabaseConfiguration.Attributes["Database"].Value = database;
                    else
                        nodeDatabaseConfiguration.Attributes.Append(Utilities.Functions.CreatedAttribute(doc, "Database", database));
                }

                doc.Save(Utilities.Parameters.SystemConfig_FileName);

                #endregion

                Utilities.Functions.MessageBoxOK("N", Utilities.Parameters.Result, "Lưu cấu hình thành công.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}