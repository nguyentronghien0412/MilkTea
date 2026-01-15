using BusinessLogicLayer;
using DataObject;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Utilities;

namespace PresentationLayer
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Functions

        public void ChangeCurrentForm(string CallBy, string FormName, string FormText)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                txtCurrentForm.Tag = FormName;
                txtCurrentForm.EditValue = FormText;

                GetFormOpening();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void GetFormOpening()
        {
            btnWindow.Reset();
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form frm = Application.OpenForms[i];
                if (frm.Name == "" || frm.Name == typeof(MainForm).Name || frm.Name == "pageSystem_Starting")
                    continue;


                BarButtonItem item = new BarButtonItem();
                item.Caption = frm.Text;
                item.Tag = frm.Name;

                if (txtCurrentForm.Tag.ToString() == frm.Name)
                    item.Glyph = imageList1.Images[0];
                else
                    item.Glyph = null;

                btnWindow.AddItem(item);
            }

            if (btnWindow.ItemLinks.Count > 0)
            {
                BarButtonItem item = new BarButtonItem();
                item.Caption = "Đóng tất cả";
                item.Tag = "CloseAll";
                btnWindow.AddItem(item);

                btnWindow.Enabled = true;
            }
        }

        public static void InitValueForAction(int Row, int Column)
        {
            Utilities.Parameters.UserLogin.arrButtonStatus = new bool[Row][];
            for (int i = 0; i < Row; i++)
                Utilities.Parameters.UserLogin.arrButtonStatus[i] = new bool[Column];

            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    Utilities.Parameters.UserLogin.arrButtonStatus[i][j] = false;

            Utilities.Parameters.UserLogin.arrButtonStatusDefault = new bool[Row][];
            for (int i = 0; i < Row; i++)
                Utilities.Parameters.UserLogin.arrButtonStatusDefault[i] = new bool[Column];

            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    Utilities.Parameters.UserLogin.arrButtonStatusDefault[i][j] = false;

            for (int i = 1; i < Row; i++)
            {
                Utilities.Parameters.UserLogin.arrButtonStatus[i][2] = true;
                Utilities.Parameters.UserLogin.arrButtonStatusDefault[i][2] = true;

                Utilities.Parameters.UserLogin.arrButtonStatus[i][5] = true;
                Utilities.Parameters.UserLogin.arrButtonStatusDefault[i][5] = true;

                Utilities.Parameters.UserLogin.arrButtonStatus[i][6] = true;
                Utilities.Parameters.UserLogin.arrButtonStatusDefault[i][6] = true;
            }
        }

        public void CloseAllForm(List<string> OpenFormName, bool IsConfirm)
        {
            if (IsConfirm)
            {
                string msg = "Bạn muốn đóng giao diện này?";
                if (OpenFormName == null)
                    msg = "Bạn muốn đóng tất cả giao diện?";

                if (Utilities.Functions.MessageBoxYesNo(msg) != DialogResult.Yes)
                    return;
            }

            if (OpenFormName == null || OpenFormName.Count == 0)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].GetType() != typeof(MainForm))
                    {
                        Application.OpenForms[i].Close();
                        i = i - 1;
                    }
            }
            else
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].GetType() != typeof(MainForm) && !OpenFormName.Contains(Application.OpenForms[i].Name))
                    {
                        Application.OpenForms[i].Close();
                        i = i - 1;
                    }
            }
        }

        private void ResetMenu(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                for (int i = 0; i < ribbonMenu.Pages.Count; i++)
                {
                    ribbonMenu.Pages[i].Visible = false;
                    for (int j = 0; j < ribbonMenu.Pages[i].Groups.Count; j++)
                    {
                        ribbonMenu.Pages[i].Groups[j].Visible = false;
                        for (int k = 0; k < ribbonMenu.Pages[i].Groups[j].ItemLinks.Count; k++)
                            ribbonMenu.Pages[i].Groups[j].ItemLinks[k].Visible = false;
                    }
                }

                pageSystem.Visible = true;

                pageSystem_groupConfiguration.Visible = true;
                for (int i = 0; i < pageSystem_groupConfiguration.ItemLinks.Count; i++)
                    if (pageSystem_groupConfiguration.ItemLinks[i].Item.Name == pageSystem_groupConfiguration_ConnectToDatabase.Name)
                        pageSystem_groupConfiguration.ItemLinks[i].Visible = true;

                pageSystem_groupUser.Visible = true;
                for (int i = 0; i < pageSystem_groupUser.ItemLinks.Count; i++)
                    if (pageSystem_groupUser.ItemLinks[i].Item.Name == pageSystem_groupUser_Login.Name)
                        pageSystem_groupUser.ItemLinks[i].Visible = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void EnableAction(bool New, bool Save, bool Edit, bool Delete, bool Cancel, bool Refresh, bool View,
                                bool Print, bool Export, int ArrayIndex)
        {
            try
            {
                #region New
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][1])
                {
                    btnNew.Enabled = New;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][1] = New;
                }
                else
                {
                    btnNew.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][1] = false;
                }
                #endregion

                #region Save
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][2])
                {
                    btnSave.Enabled = Save;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][2] = Save;
                }
                else
                {
                    btnSave.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][2] = false;
                }
                #endregion

                #region Edit
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][3])
                {
                    btnEdit.Enabled = Edit;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][3] = Edit;
                }
                else
                {
                    btnEdit.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][3] = false;
                }
                #endregion

                #region Delete
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][4])
                {
                    btnDelete.Enabled = Delete;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][4] = Delete;
                }
                else
                {
                    btnDelete.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][4] = false;
                }
                #endregion

                #region Cancel
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][5])
                {
                    btnCancel.Enabled = Cancel;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][5] = Cancel;
                }
                else
                {
                    btnCancel.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][5] = false;
                }
                #endregion

                #region Refresh
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][6])
                {
                    btnRefresh.Enabled = Refresh;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][6] = Refresh;
                }
                else
                {
                    btnRefresh.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][6] = false;
                }
                #endregion

                #region Print View
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][7])
                {
                    btnPrintView.Enabled = View;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][7] = View;
                }
                else
                {
                    btnPrintView.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][7] = false;
                }
                #endregion

                #region Print
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][8])
                {
                    btnPrint.Enabled = Print;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][8] = Print;
                }
                else
                {
                    btnPrint.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][8] = false;
                }
                #endregion

                #region Export
                if (Utilities.Parameters.UserLogin.arrButtonStatusDefault[ArrayIndex][9])
                {
                    btnExportFile.Enabled = Export;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][9] = Export;
                }
                else
                {
                    btnExportFile.Enabled = false;
                    Utilities.Parameters.UserLogin.arrButtonStatus[ArrayIndex][9] = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ResetApplication(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                List<string> lst = new List<string>();
                lst.Add("frmSystem_Starting");
                CloseAllForm(lst, false);

                ResetMenu(callFrom);

                InitValueForAction(1, Utilities.Parameters.TotalAction);
                EnableAction(false, false, false, false, false, false, false, false, false, 0);

                btnWindow.Enabled = false;
                txtCurrentForm.EditValue = "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string LoadConfigurationOfDatabase(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!File.Exists(Utilities.Parameters.SystemConfig_FileName))
                    return "Không tìm thấy Tập tin cấu hình !!!";

                XmlDocument doc = new XmlDocument();
                doc.Load(Utilities.Parameters.SystemConfig_FileName);
                XmlNode node = doc.SelectSingleNode(@"Root/DatabaseConfiguration");
                Utilities.Parameters.Server = Utilities.Functions.DecryptByRC2(node.Attributes["Server"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                Utilities.Parameters.Port = Utilities.Functions.DecryptByRC2(node.Attributes["Port"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                Utilities.Parameters.Username = Utilities.Functions.DecryptByRC2(node.Attributes["Username"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                Utilities.Parameters.Password = Utilities.Functions.DecryptByRC2(node.Attributes["Password"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);
                Utilities.Parameters.Database = Utilities.Functions.DecryptByRC2(node.Attributes["Database"].Value, Utilities.Parameters.KEY_SystemConfig, Utilities.Parameters.IV_SystemConfig);

                Utilities.Parameters.ConnectionString = "Server=" + Utilities.Parameters.Server + ";Database=" + Utilities.Parameters.Database + ";Port=" + Utilities.Parameters.Port + ";User Id=" + Utilities.Parameters.Username + ";Password='" + Utilities.Parameters.Password + "';SSL Mode=None";

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                return ex.Message + "\n" + callFrom;
            }
        }

        public void LoadInfoLogin(bool IsLogin)
        {
            if (IsLogin)
            {
                bsLoginName.Caption = Utilities.Parameters.UserLogin.EmployeesName;
                bsPosition.Caption = Utilities.Parameters.UserLogin.Position;
                bsLoginDate.Caption = "Giờ đăng nhập" + ": " + Utilities.Parameters.UserLogin.LoginDate.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                bsLoginName.Caption = "Đã đăng xuất";
                bsPosition.Caption = "Đã đăng xuất";
                bsLoginDate.Caption = "Giờ đăng xuất" + ": " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }
        }

        private void DisplayMenu()
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                for (int k = 0; k < ribbonMenu.Pages.Count; k++)
                {
                    if (ribbonMenu.Pages[k].Name != null)
                    {
                        string pageName = ribbonMenu.Pages[k].Name.ToString();
                        for (int m = 0; m < ribbonMenu.Pages[k].Groups.Count; m++)
                        {
                            if (ribbonMenu.Pages[k].Groups[m].Name != null)
                            {
                                string groupName = ribbonMenu.Pages[k].Groups[m].Name.ToString();
                                for (int l = 0; l < ribbonMenu.Pages[k].Groups[m].ItemLinks.Count; l++)
                                {
                                    if (ribbonMenu.Pages[k].Groups[m].ItemLinks[l].Item.Name != null)
                                    {
                                        string itemName = ribbonMenu.Pages[k].Groups[m].ItemLinks[l].Item.Name.ToString();
                                        for (int i = 0; i < Utilities.Parameters.UserLogin.dtPermission.Rows.Count; i++)
                                        {
                                            string itemCode = Utilities.Parameters.UserLogin.dtPermission.Rows[i]["Code"].ToString();
                                            if (itemCode.CompareTo(itemName) == 0)
                                            {
                                                ribbonMenu.Pages[k].Groups[m].ItemLinks[l].Visible = true;
                                                int index_group = itemCode.LastIndexOf("_");
                                                if (index_group > -1)
                                                {
                                                    string groupCode = itemCode.Substring(0, index_group);
                                                    if (groupCode.CompareTo(groupName) == 0)
                                                    {
                                                        ribbonMenu.Pages[k].Groups[m].Visible = true;
                                                        int index_page = groupCode.LastIndexOf("_");
                                                        if (index_page > -1)
                                                        {
                                                            string page_code = groupCode.Substring(0, index_page);
                                                            if (page_code.CompareTo(pageName) == 0)
                                                            {
                                                                ribbonMenu.Pages[k].Visible = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                #region Visible Category

                //bool flagVisibleCategory = false;
                //foreach (DataRow dr in ERP_Ultilities.Parameters.UserLogin.dtPermission.Rows)
                //{
                //    if ((int)dr["PermissionGroupTypeID"] == (int)ERP_Ultilities.CategoriesEnum.PermissionGroupType.Danh_mục)
                //    {
                //        flagVisibleCategory = true;
                //        break;
                //    }
                //}

                //if (flagVisibleCategory)
                //{
                //    foreach (RibbonPage page in ribbonMenu.Pages)
                //    {
                //        if (page.Name == pageSystem)
                //        {
                //            page.Visible = true;
                //            foreach (RibbonPageGroup group in page.Groups)
                //            {
                //                if (group.Name == pageSystem + "_" + pageSystem_GroupCategories)
                //                {
                //                    group.Visible = true;
                //                    foreach (BarButtonItemLink itemLink in group.ItemLinks)
                //                    {
                //                        if (itemLink.Item.Name == pageSystem + "_" + pageSystem_GroupCategories + "_" + pageSystem_GroupCategories_CategoriesSystem)
                //                        {
                //                            itemLink.Visible = true;
                //                            break;
                //                        }
                //                    }
                //                }
                //            }
                //            break;
                //        }
                //    }
                //}

                #endregion

                #region Visible Configuration

                //bool flagVisibleConfiguration = false;
                //foreach (DataRow dr in ERP_Ultilities.Parameters.UserLogin.dtPermission.Rows)
                //{
                //    if ((int)dr["PermissionGroupTypeID"] == (int)ERP_Ultilities.CategoriesEnum.PermissionGroupType.Cấu_hình)
                //    {
                //        flagVisibleConfiguration = true;
                //        break;
                //    }
                //}

                //if (flagVisibleConfiguration)
                //{
                //    foreach (RibbonPage page in ribbonMenu.Pages)
                //    {
                //        if (page.Name == pageSystem)
                //        {
                //            page.Visible = true;
                //            foreach (RibbonPageGroup group in page.Groups)
                //            {
                //                if (group.Name == pageSystem + "_" + pageSystem_GroupConfiguration)
                //                {
                //                    group.Visible = true;
                //                    foreach (BarButtonItemLink itemLink in group.ItemLinks)
                //                    {
                //                        if (itemLink.Item.Name == pageSystem + "_" + pageSystem_GroupConfiguration + "_" + pageSystem_GroupConfiguration_SystemConfiguration)
                //                        {
                //                            itemLink.Visible = true;
                //                            break;
                //                        }
                //                    }
                //                }
                //            }
                //            break;
                //        }
                //    }
                //}

                #endregion

                #region Load button after login

                foreach (RibbonPage page in ribbonMenu.Pages)
                {
                    if (page.Name == pageSystem.Name)
                    {
                        page.Visible = true;
                        foreach (RibbonPageGroup group in page.Groups)
                        {
                            if (group.Name == pageSystem_groupUser.Name)
                            {
                                group.Visible = true;
                                foreach (BarButtonItemLink itemLink in group.ItemLinks)
                                {
                                    if (itemLink.Item.Name == pageSystem_groupUser_Login.Name)
                                        itemLink.Visible = false;
                                    else if (itemLink.Item.Name == pageSystem_groupUser_Logout.Name)
                                        itemLink.Visible = true;
                                    else if (itemLink.Item.Name == pageSystem_groupUser_ChangePassword.Name)
                                        itemLink.Visible = true;
                                }
                            }
                        }
                        break;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void LoadDefinition(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtDefinition = new DataTable();
                busGeneralFunctions bGeneral = new busGeneralFunctions();
                string _Result = bGeneral.GetAll(callFrom,ref dtDefinition, "Definition", "");
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Definition_GetAll:\n" + _Result);
                    MessageBox.Show(_Result + "\n" + callFrom + " -> Definition_GetAll", Utilities.Parameters.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataRow dr in dtDefinition.Rows)
                    if (dr["IsEncrypt"].ToString() == "1")
                        if (dr["Value"].ToString() != "")
                            dr["Value"] = Utilities.Functions.DecryptByRC2(dr["Value"].ToString(), Utilities.Parameters.KEY_Definition, Utilities.Parameters.IV_Definition);

                _Result = Utilities.Multi.LoadDefinition(dtDefinition);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> LoadDefinition:\n" + _Result);
                    MessageBox.Show(_Result + "\n" + callFrom + " -> LoadDefinition", Utilities.Parameters.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                switch (keyData)
                {
                    case (Keys.N | Keys.Control):
                        {
                            if (btnNew.Enabled == false)
                                break;
                            btnNew_ItemClick(null, null);
                            break;
                        }
                    case (Keys.E | Keys.Control):
                        {
                            if (btnEdit.Enabled == false)
                                break;
                            btnEdit_ItemClick(null, null);
                            break;
                        }
                    case (Keys.S | Keys.Control):
                        {
                            if (btnSave.Enabled == false)
                                break;
                            btnSave_ItemClick(null, null);
                            break;
                        }
                    case (Keys.D | Keys.Control):
                        {
                            if (btnDelete.Enabled == false)
                                break;
                            btnDelete_ItemClick(null, null);
                            break;
                        }
                    case (Keys.I | Keys.Control):
                        {
                            if (btnCancel.Enabled == false)
                                break;
                            btnCancel_ItemClick(null, null);
                            break;
                        }
                    case (Keys.R | Keys.Control):
                        {
                            if (btnRefresh.Enabled == false)
                                break;
                            btnRefresh_ItemClick(null, null);
                            break;
                        }
                    case (Keys.M | Keys.Control):
                        {
                            if (btnPrintView.Enabled == false)
                                break;
                            btnPrintView_ItemClick(null, null);
                            break;
                        }
                    case (Keys.P | Keys.Control):
                        {
                            if (btnPrint.Enabled == false)
                                break;
                            btnPrint_ItemClick(null, null);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Events

        public MainForm()
        {
            InitializeComponent();

            Utilities.Parameters.UserLogin = new dtoUserLogin();
            Utilities.Parameters.Definition = new dtoDefinition();
        }

        private void pageSystem_groupConfiguration_ConnectToDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageSystem_groupConfiguration_ConnectToDatabase frmConnectToDatabase = new pageSystem_groupConfiguration_ConnectToDatabase();
                frmConnectToDatabase.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void AutoReport()
        {
            timerAutoReport.Stop();
            timerAutoReport.Enabled = false;

            //timerAutoReport.Interval = (60 * 1000) * 5;
            timerAutoReport.Interval = 10000;
            timerAutoReport.Enabled = true;
            timerAutoReport.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                //MailManagement.SendMail_GoogleSMTP(null);

                #region permission

                //string permission = "pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay";
                //////string permissionDecrypt = Utilities.Functions.DecryptByRC2(permission, Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);
                //string permissionEncrypt = Utilities.Functions.EncryptByRC2(permission, Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);

                #endregion

                #region permission detail

                //string permissionDetail = "CREATE_DATA";
                //string permissionDetailDecrypt = Utilities.Functions.DecryptByRC2("11 H0olhFY/Jj8CZq7lWT+iYw==", Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);
                //string permissionDetailEncrypt = Utilities.Functions.EncryptByRC2(permissionDetail, Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);

                #endregion

                #region password user

                //string password = "a";
                string permissionDecrypt = Utilities.Functions.DecryptByRC2("9 e9b1Qicx/hcW8/mAWFRh8Q==", Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);
                //string passwordEncrypt = Utilities.Functions.EncryptByRC2(password, Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);

                #endregion

                timerAutoReport.Stop();
                timerAutoReport.Enabled = false;

                this.Text = "Phần mềm quản lý tiệm trà sữa " + " v." + Application.ProductVersion;

                ResetApplication(callFrom);

                #region Load configuration of database

                string result = LoadConfigurationOfDatabase(callFrom);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result);
                    return;
                }

                #endregion

                #region Check connect to database

                BusinessLogicLayer.busSystemConfiguration SystemConfig = new BusinessLogicLayer.busSystemConfiguration();
                string _IsConnect = SystemConfig.TestConnectToDatabase(callFrom, Utilities.Parameters.Server, Utilities.Parameters.Port, Utilities.Parameters.Database, Utilities.Parameters.Username, Utilities.Parameters.Password);
                if (_IsConnect != Utilities.Parameters.ResultMessage)
                {
                    pageSystem_groupUser_Login.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    pageSystem_groupUser.Visible = false;

                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, "Không thể kết nối với cơ sở dữ liệu: " + _IsConnect);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không thể kết nối với cơ sở dữ liệu: " + _IsConnect);
                    return;
                }

                #endregion

                LoadDefinition(callFrom);

                this.Text = "Phần mềm quản lý tiệm trà sữa - "+ Parameters.Definition.BRANCH_NAME + " v." + Application.ProductVersion;

                pageSystem_groupUser_Login frmLogin = new pageSystem_groupUser_Login();
                frmLogin.BringToFront();
                DialogResult dlg = frmLogin.ShowDialog();
                if (dlg != DialogResult.OK)
                    return;

                LoadInfoLogin(true);

                #region Set Pemission

                DataTable dtPerm = new DataTable();
                DataTable dtPermDetail = new DataTable();
                bool[][] arrStatus = Utilities.Parameters.UserLogin.arrButtonStatusDefault;

                busUsers bUser = new busUsers();
                result = bUser.GetPermission(callFrom, ref dtPerm, ref dtPermDetail, ref arrStatus, Utilities.Parameters.UserLogin.UserID);

                Utilities.Parameters.UserLogin.dtPermission = dtPerm;
                Utilities.Parameters.UserLogin.dtPermissionDetail = dtPermDetail;
                Utilities.Parameters.UserLogin.arrButtonStatusDefault = arrStatus;

                int row = arrStatus.Length;
                int column = arrStatus[0].Length;

                Utilities.Parameters.UserLogin.arrButtonStatus = new bool[row][];
                for (int i = 0; i < row; i++)
                    Utilities.Parameters.UserLogin.arrButtonStatus[i] = new bool[column];

                for (int i = 0; i < row; i++)
                    for (int j = 0; j < column; j++)
                        Utilities.Parameters.UserLogin.arrButtonStatus[i][j] = false;

                for (int i = 1; i < row; i++)
                {
                    Utilities.Parameters.UserLogin.arrButtonStatus[i][2] = true;
                    Utilities.Parameters.UserLogin.arrButtonStatus[i][5] = true;
                    Utilities.Parameters.UserLogin.arrButtonStatus[i][6] = true;
                }

                #endregion

                DisplayMenu();
                ribbonMenu.SelectedPage = pageManagement;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_Login_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MainForm_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_Logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn đăng xuất?") != DialogResult.Yes)
                    return;

                ResetApplication(callFrom);
                LoadInfoLogin(false);

                Utilities.Parameters.UserLogin = new dtoUserLogin();

                pageSystem_groupUser_Login_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupConfiguration_UserConfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageSystem_groupConfiguration_UserConfiguration), this, txtCurrentForm))
                {
                    pageSystem_groupConfiguration_UserConfiguration frmDefinition = new pageSystem_groupConfiguration_UserConfiguration();
                    frmDefinition.MdiParent = this;
                    txtCurrentForm.EditValue = frmDefinition.Text;
                    frmDefinition.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_Role.Name)
                {
                    pageSystem_groupUser_Role frmRole = (pageSystem_groupUser_Role)Application.OpenForms[pageSystem_groupUser_Role.Name];
                    frmRole.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_UserAdministrator.Name)
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = (pageSystem_groupUser_UserAdministrator)Application.OpenForms[pageSystem_groupUser_UserAdministrator.Name];
                    frmUserAdministrator.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupSystem_Position.Name)
                {
                    pageCategories_groupSystem_Position frmPosition = (pageCategories_groupSystem_Position)Application.OpenForms[pageCategories_groupSystem_Position.Name];
                    frmPosition.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_DinnerTable.Name)
                {
                    pageCategories_groupMaterialMenu_DinnerTable frmDinnerTable = (pageCategories_groupMaterialMenu_DinnerTable)Application.OpenForms[pageCategories_groupMaterialMenu_DinnerTable.Name];
                    frmDinnerTable.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_MenuGroup.Name)
                {
                    pageCategories_groupMaterialMenu_MenuGroup frmMenuGroup = (pageCategories_groupMaterialMenu_MenuGroup)Application.OpenForms[pageCategories_groupMaterialMenu_MenuGroup.Name];
                    frmMenuGroup.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_ListOfMaterials.Name)
                {
                    pageCategories_groupMaterialMenu_ListOfMaterials frmListOfMaterials = (pageCategories_groupMaterialMenu_ListOfMaterials)Application.OpenForms[pageCategories_groupMaterialMenu_ListOfMaterials.Name];
                    frmListOfMaterials.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Menu.Name)
                {
                    pageCategories_groupMaterialMenu_Menu frmMenu = (pageCategories_groupMaterialMenu_Menu)Application.OpenForms[pageCategories_groupMaterialMenu_Menu.Name];
                    frmMenu.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Unit.Name)
                {
                    pageCategories_groupMaterialMenu_Unit frmUnit = (pageCategories_groupMaterialMenu_Unit)Application.OpenForms[pageCategories_groupMaterialMenu_Unit.Name];
                    frmUnit.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupPriceList_Price.Name)
                {
                    pageCategories_groupPriceList_Price frmPrice = (pageCategories_groupPriceList_Price)Application.OpenForms[pageCategories_groupPriceList_Price.Name];
                    frmPrice.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_PromotionOnTotalBill.Name)
                {
                    pageManagement_groupFunctions_PromotionOnTotalBill frmPromotionOnTotalBill = (pageManagement_groupFunctions_PromotionOnTotalBill)Application.OpenForms[pageManagement_groupFunctions_PromotionOnTotalBill.Name];
                    frmPromotionOnTotalBill.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_MenuAndMaterial.Name)
                {
                    pageCategories_groupMaterialMenu_MenuAndMaterial frmMenuAndMaterial = (pageCategories_groupMaterialMenu_MenuAndMaterial)Application.OpenForms[pageCategories_groupMaterialMenu_MenuAndMaterial.Name];
                    frmMenuAndMaterial.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_ImportMaterials.Name)
                {
                    pageManagement_groupFunctions_ImportMaterials frmImportMaterials = (pageManagement_groupFunctions_ImportMaterials)Application.OpenForms[pageManagement_groupFunctions_ImportMaterials.Name];
                    frmImportMaterials.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_AttendanceData.Name)
                {
                    pageManagement_groupSalaryManagement_AttendanceData frmAttendanceData = (pageManagement_groupSalaryManagement_AttendanceData)Application.OpenForms[pageManagement_groupSalaryManagement_AttendanceData.Name];
                    frmAttendanceData.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Payroll.Name)
                {
                    pageManagement_groupSalaryManagement_Payroll frmPayroll = (pageManagement_groupSalaryManagement_Payroll)Application.OpenForms[pageManagement_groupSalaryManagement_Payroll.Name];
                    frmPayroll.New(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Overtime.Name)
                {
                    pageManagement_groupSalaryManagement_Overtime frmOvertime = (pageManagement_groupSalaryManagement_Overtime)Application.OpenForms[pageManagement_groupSalaryManagement_Overtime.Name];
                    frmOvertime.New(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupConfiguration_UserConfiguration.Name)
                {
                    pageSystem_groupConfiguration_UserConfiguration frmUserConfiguration = (pageSystem_groupConfiguration_UserConfiguration)Application.OpenForms[pageSystem_groupConfiguration_UserConfiguration.Name];
                    frmUserConfiguration.Save(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_UserAdministrator.Name)
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = (pageSystem_groupUser_UserAdministrator)Application.OpenForms[pageSystem_groupUser_UserAdministrator.Name];
                    frmUserAdministrator.Save(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupPriceList_Price.Name)
                {
                    pageCategories_groupPriceList_Price frmPrice = (pageCategories_groupPriceList_Price)Application.OpenForms[pageCategories_groupPriceList_Price.Name];
                    frmPrice.Save(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.Save(callFrom);
                }               
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupConfiguration_UserConfiguration.Name)
                {
                    pageSystem_groupConfiguration_UserConfiguration frmUserConfiguration = (pageSystem_groupConfiguration_UserConfiguration)Application.OpenForms[pageSystem_groupConfiguration_UserConfiguration.Name];
                    frmUserConfiguration.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_Role.Name)
                {
                    pageSystem_groupUser_Role frmRole = (pageSystem_groupUser_Role)Application.OpenForms[pageSystem_groupUser_Role.Name];
                    frmRole.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_UserAdministrator.Name)
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = (pageSystem_groupUser_UserAdministrator)Application.OpenForms[pageSystem_groupUser_UserAdministrator.Name];
                    frmUserAdministrator.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupSystem_Position.Name)
                {
                    pageCategories_groupSystem_Position frmPosition = (pageCategories_groupSystem_Position)Application.OpenForms[pageCategories_groupSystem_Position.Name];
                    frmPosition.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_DinnerTable.Name)
                {
                    pageCategories_groupMaterialMenu_DinnerTable frmDinnerTable = (pageCategories_groupMaterialMenu_DinnerTable)Application.OpenForms[pageCategories_groupMaterialMenu_DinnerTable.Name];
                    frmDinnerTable.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_MenuGroup.Name)
                {
                    pageCategories_groupMaterialMenu_MenuGroup frmMenuGroup = (pageCategories_groupMaterialMenu_MenuGroup)Application.OpenForms[pageCategories_groupMaterialMenu_MenuGroup.Name];
                    frmMenuGroup.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_ListOfMaterials.Name)
                {
                    pageCategories_groupMaterialMenu_ListOfMaterials frmListOfMaterials = (pageCategories_groupMaterialMenu_ListOfMaterials)Application.OpenForms[pageCategories_groupMaterialMenu_ListOfMaterials.Name];
                    frmListOfMaterials.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Menu.Name)
                {
                    pageCategories_groupMaterialMenu_Menu frmMenu = (pageCategories_groupMaterialMenu_Menu)Application.OpenForms[pageCategories_groupMaterialMenu_Menu.Name];
                    frmMenu.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Unit.Name)
                {
                    pageCategories_groupMaterialMenu_Unit frmUnit = (pageCategories_groupMaterialMenu_Unit)Application.OpenForms[pageCategories_groupMaterialMenu_Unit.Name];
                    frmUnit.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupPriceList_Price.Name)
                {
                    pageCategories_groupPriceList_Price frmPrice = (pageCategories_groupPriceList_Price)Application.OpenForms[pageCategories_groupPriceList_Price.Name];
                    frmPrice.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_PromotionOnTotalBill.Name)
                {
                    pageManagement_groupFunctions_PromotionOnTotalBill frmPromotionOnTotalBill = (pageManagement_groupFunctions_PromotionOnTotalBill)Application.OpenForms[pageManagement_groupFunctions_PromotionOnTotalBill.Name];
                    frmPromotionOnTotalBill.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_MenuAndMaterial.Name)
                {
                    pageCategories_groupMaterialMenu_MenuAndMaterial frmMenuAndMaterial = (pageCategories_groupMaterialMenu_MenuAndMaterial)Application.OpenForms[pageCategories_groupMaterialMenu_MenuAndMaterial.Name];
                    frmMenuAndMaterial.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_ImportMaterials.Name)
                {
                    pageManagement_groupFunctions_ImportMaterials frmImportMaterials = (pageManagement_groupFunctions_ImportMaterials)Application.OpenForms[pageManagement_groupFunctions_ImportMaterials.Name];
                    frmImportMaterials.Edit(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Overtime.Name)
                {
                    pageManagement_groupSalaryManagement_Overtime frmOvertime = (pageManagement_groupSalaryManagement_Overtime)Application.OpenForms[pageManagement_groupSalaryManagement_Overtime.Name];
                    frmOvertime.Edit(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_Role.Name)
                {
                    pageSystem_groupUser_Role frmRole = (pageSystem_groupUser_Role)Application.OpenForms[pageSystem_groupUser_Role.Name];
                    frmRole.Delete(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.Delete(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_PromotionOnTotalBill.Name)
                {
                    pageManagement_groupFunctions_PromotionOnTotalBill frmPromotionOnTotalBill = (pageManagement_groupFunctions_PromotionOnTotalBill)Application.OpenForms[pageManagement_groupFunctions_PromotionOnTotalBill.Name];
                    frmPromotionOnTotalBill.Delete(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_AttendanceData.Name)
                {
                    pageManagement_groupSalaryManagement_AttendanceData frmAttendanceData = (pageManagement_groupSalaryManagement_AttendanceData)Application.OpenForms[pageManagement_groupSalaryManagement_AttendanceData.Name];
                    frmAttendanceData.Delete(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Payroll.Name)
                {
                    pageManagement_groupSalaryManagement_Payroll frmPayroll = (pageManagement_groupSalaryManagement_Payroll)Application.OpenForms[pageManagement_groupSalaryManagement_Payroll.Name];
                    frmPayroll.Delete(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Overtime.Name)
                {
                    pageManagement_groupSalaryManagement_Overtime frmOvertime = (pageManagement_groupSalaryManagement_Overtime)Application.OpenForms[pageManagement_groupSalaryManagement_Overtime.Name];
                    frmOvertime.Delete(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupConfiguration_UserConfiguration.Name)
                {
                    pageSystem_groupConfiguration_UserConfiguration frmUserConfiguration = (pageSystem_groupConfiguration_UserConfiguration)Application.OpenForms[pageSystem_groupConfiguration_UserConfiguration.Name];
                    frmUserConfiguration.Cancel(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_UserAdministrator.Name)
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = (pageSystem_groupUser_UserAdministrator)Application.OpenForms[pageSystem_groupUser_UserAdministrator.Name];
                    frmUserAdministrator.Cancel(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupPriceList_Price.Name)
                {
                    pageCategories_groupPriceList_Price frmPrice = (pageCategories_groupPriceList_Price)Application.OpenForms[pageCategories_groupPriceList_Price.Name];
                    frmPrice.Cancel(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.Cancel(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupConfiguration_UserConfiguration.Name)
                {
                    pageSystem_groupConfiguration_UserConfiguration frmUserConfiguration = (pageSystem_groupConfiguration_UserConfiguration)Application.OpenForms[pageSystem_groupConfiguration_UserConfiguration.Name];
                    frmUserConfiguration.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_Role.Name)
                {
                    pageSystem_groupUser_Role frmRole = (pageSystem_groupUser_Role)Application.OpenForms[pageSystem_groupUser_Role.Name];
                    frmRole.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageSystem_groupUser_UserAdministrator.Name)
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = (pageSystem_groupUser_UserAdministrator)Application.OpenForms[pageSystem_groupUser_UserAdministrator.Name];
                    frmUserAdministrator.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupSystem_Position.Name)
                {
                    pageCategories_groupSystem_Position frmPosition = (pageCategories_groupSystem_Position)Application.OpenForms[pageCategories_groupSystem_Position.Name];
                    frmPosition.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_DinnerTable.Name)
                {
                    pageCategories_groupMaterialMenu_DinnerTable frmDinnerTable = (pageCategories_groupMaterialMenu_DinnerTable)Application.OpenForms[pageCategories_groupMaterialMenu_DinnerTable.Name];
                    frmDinnerTable.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_MenuGroup.Name)
                {
                    pageCategories_groupMaterialMenu_MenuGroup frmMenuGroup = (pageCategories_groupMaterialMenu_MenuGroup)Application.OpenForms[pageCategories_groupMaterialMenu_MenuGroup.Name];
                    frmMenuGroup.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_ListOfMaterials.Name)
                {
                    pageCategories_groupMaterialMenu_ListOfMaterials frmListOfMaterials = (pageCategories_groupMaterialMenu_ListOfMaterials)Application.OpenForms[pageCategories_groupMaterialMenu_ListOfMaterials.Name];
                    frmListOfMaterials.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Menu.Name)
                {
                    pageCategories_groupMaterialMenu_Menu frmMenu = (pageCategories_groupMaterialMenu_Menu)Application.OpenForms[pageCategories_groupMaterialMenu_Menu.Name];
                    frmMenu.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupMaterialMenu_Unit.Name)
                {
                    pageCategories_groupMaterialMenu_Unit frmUnit = (pageCategories_groupMaterialMenu_Unit)Application.OpenForms[pageCategories_groupMaterialMenu_Unit.Name];
                    frmUnit.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageCategories_groupPriceList_Price.Name)
                {
                    pageCategories_groupPriceList_Price frmPrice = (pageCategories_groupPriceList_Price)Application.OpenForms[pageCategories_groupPriceList_Price.Name];
                    frmPrice.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_CollectAndSpend.Name)
                {
                    pageManagement_groupFunctions_CollectAndSpend frmPrice = (pageManagement_groupFunctions_CollectAndSpend)Application.OpenForms[pageManagement_groupFunctions_CollectAndSpend.Name];
                    frmPrice.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupFunctions_PromotionOnTotalBill.Name)
                {
                    pageManagement_groupFunctions_PromotionOnTotalBill frmPromotionOnTotalBill = (pageManagement_groupFunctions_PromotionOnTotalBill)Application.OpenForms[pageManagement_groupFunctions_PromotionOnTotalBill.Name];
                    frmPromotionOnTotalBill.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_AttendanceData.Name)
                {
                    pageManagement_groupSalaryManagement_AttendanceData frmAttendanceData = (pageManagement_groupSalaryManagement_AttendanceData)Application.OpenForms[pageManagement_groupSalaryManagement_AttendanceData.Name];
                    frmAttendanceData.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Payroll.Name)
                {
                    pageManagement_groupSalaryManagement_Payroll frmPayroll = (pageManagement_groupSalaryManagement_Payroll)Application.OpenForms[pageManagement_groupSalaryManagement_Payroll.Name];
                    frmPayroll.Refreshed(callFrom);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageManagement_groupSalaryManagement_Overtime.Name)
                {
                    pageManagement_groupSalaryManagement_Overtime frmOvertime = (pageManagement_groupSalaryManagement_Overtime)Application.OpenForms[pageManagement_groupSalaryManagement_Overtime.Name];
                    frmOvertime.Refreshed(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnPrintView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_Employee.Name)
                {
                    pageReport_groupRevenue_Employee frmEmployee = (pageReport_groupRevenue_Employee)Application.OpenForms[pageReport_groupRevenue_Employee.Name];
                    frmEmployee.Print(callFrom, false);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Print(callFrom, false);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_BestSeller.Name)
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = (pageReport_groupRevenue_BestSeller)Application.OpenForms[pageReport_groupRevenue_BestSeller.Name];
                    frmBestSeller.Print(callFrom, false);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_Employee.Name)
                {
                    pageReport_groupRevenue_Employee frmEmployee = (pageReport_groupRevenue_Employee)Application.OpenForms[pageReport_groupRevenue_Employee.Name];
                    frmEmployee.Print(callFrom, true);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Print(callFrom, true);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_BestSeller.Name)
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = (pageReport_groupRevenue_BestSeller)Application.OpenForms[pageReport_groupRevenue_BestSeller.Name];
                    frmBestSeller.Print(callFrom, true);
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name)
                {
                    pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay frmSummaryOfRevenue = (pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay)Application.OpenForms[pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name];
                    frmSummaryOfRevenue.Print(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ribbonMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.Item is BarButtonItem)
                {
                    if (e.Item.Tag != null && e.Item.Tag.ToString() != "")
                    {
                        if (e.Item.Tag.ToString() == "CloseAll")
                            CloseAllForm(null, true);

                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            Form frm = Application.OpenForms[i];
                            if (frm.Name == e.Item.Tag.ToString())
                            {
                                frm.Focus();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_Role_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageSystem_groupUser_Role), this, txtCurrentForm))
                {
                    pageSystem_groupUser_Role frmRole = new pageSystem_groupUser_Role();
                    frmRole.MdiParent = this;
                    txtCurrentForm.EditValue = frmRole.Text;
                    frmRole.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_UserAdministrator_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageSystem_groupUser_UserAdministrator), this, txtCurrentForm))
                {
                    pageSystem_groupUser_UserAdministrator frmUserAdministrator = new pageSystem_groupUser_UserAdministrator();
                    frmUserAdministrator.MdiParent = this;
                    txtCurrentForm.EditValue = frmUserAdministrator.Text;
                    frmUserAdministrator.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupUser_ChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageSystem_groupUser_ChangePassword frmChangePassword = new pageSystem_groupUser_ChangePassword();
                DialogResult dlg = frmChangePassword.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    ResetApplication(callFrom);
                    LoadInfoLogin(false);

                    Utilities.Parameters.UserLogin = new dtoUserLogin();

                    MainForm_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupSystem_Position_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupSystem_Position), this, txtCurrentForm))
                {
                    pageCategories_groupSystem_Position frmPosition = new pageCategories_groupSystem_Position();
                    frmPosition.MdiParent = this;
                    txtCurrentForm.EditValue = frmPosition.Text;
                    frmPosition.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_DinnerTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_DinnerTable), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_DinnerTable frmTable = new pageCategories_groupMaterialMenu_DinnerTable();
                    frmTable.MdiParent = this;
                    txtCurrentForm.EditValue = frmTable.Text;
                    frmTable.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_MenuGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_MenuGroup), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_MenuGroup frmMenuGroup = new pageCategories_groupMaterialMenu_MenuGroup();
                    frmMenuGroup.MdiParent = this;
                    txtCurrentForm.EditValue = frmMenuGroup.Text;
                    frmMenuGroup.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_Menu), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_Menu frmMenu = new pageCategories_groupMaterialMenu_Menu();
                    frmMenu.MdiParent = this;
                    txtCurrentForm.EditValue = frmMenu.Text;
                    frmMenu.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_ListOfMaterials_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_ListOfMaterials), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_ListOfMaterials frmListOfMaterials = new pageCategories_groupMaterialMenu_ListOfMaterials();
                    frmListOfMaterials.MdiParent = this;
                    txtCurrentForm.EditValue = frmListOfMaterials.Text;
                    frmListOfMaterials.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_Unit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_Unit), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_Unit frmUnit = new pageCategories_groupMaterialMenu_Unit();
                    frmUnit.MdiParent = this;
                    txtCurrentForm.EditValue = frmUnit.Text;
                    frmUnit.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupPriceList_Price_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupPriceList_Price), this, txtCurrentForm))
                {
                    pageCategories_groupPriceList_Price frmPrice = new pageCategories_groupPriceList_Price();
                    frmPrice.MdiParent = this;
                    txtCurrentForm.EditValue = frmPrice.Text;
                    frmPrice.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupFunctions_TableAndDish_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_TableAndDish frmTableAndDish = new pageManagement_groupFunctions_TableAndDish();
                frmTableAndDish.BringToFront();
                frmTableAndDish.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageReport_groupRevenue_Employee_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageReport_groupRevenue_Employee), this, txtCurrentForm))
                {
                    pageReport_groupRevenue_Employee frmEmployee = new pageReport_groupRevenue_Employee();
                    frmEmployee.MdiParent = this;
                    txtCurrentForm.EditValue = frmEmployee.Text;
                    frmEmployee.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnExportFile_Pdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_Employee.Name)
                {
                    pageReport_groupRevenue_Employee frmEmployee = (pageReport_groupRevenue_Employee)Application.OpenForms[pageReport_groupRevenue_Employee.Name];
                    frmEmployee.Export(callFrom, "PDF");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Export(callFrom, "PDF");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_BestSeller.Name)
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = (pageReport_groupRevenue_BestSeller)Application.OpenForms[pageReport_groupRevenue_BestSeller.Name];
                    frmBestSeller.Export(callFrom, "PDF");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name)
                {
                    pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay frmSummaryOfRevenue = (pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay)Application.OpenForms[pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name];
                    frmSummaryOfRevenue.Export(callFrom, "PDF");
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnExportFile_Word_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_Employee.Name)
                {
                    pageReport_groupRevenue_Employee frmEmployee = (pageReport_groupRevenue_Employee)Application.OpenForms[pageReport_groupRevenue_Employee.Name];
                    frmEmployee.Export(callFrom, "DOCX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Export(callFrom, "DOCX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_BestSeller.Name)
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = (pageReport_groupRevenue_BestSeller)Application.OpenForms[pageReport_groupRevenue_BestSeller.Name];
                    frmBestSeller.Export(callFrom, "DOCX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name)
                {
                    pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay frmSummaryOfRevenue = (pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay)Application.OpenForms[pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name];
                    frmSummaryOfRevenue.Export(callFrom, "DOCX");
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnExportFile_Excel_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_Employee.Name)
                {
                    pageReport_groupRevenue_Employee frmEmployee = (pageReport_groupRevenue_Employee)Application.OpenForms[pageReport_groupRevenue_Employee.Name];
                    frmEmployee.Export(callFrom, "XLSX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupWarehouse_Inventory.Name)
                {
                    pageReport_groupWarehouse_Inventory frmInventory = (pageReport_groupWarehouse_Inventory)Application.OpenForms[pageReport_groupWarehouse_Inventory.Name];
                    frmInventory.Export(callFrom, "XLSX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_BestSeller.Name)
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = (pageReport_groupRevenue_BestSeller)Application.OpenForms[pageReport_groupRevenue_BestSeller.Name];
                    frmBestSeller.Export(callFrom, "XLSX");
                }
                else if (this.ActiveMdiChild != null && this.ActiveMdiChild.Name == pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name)
                {
                    pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay frmSummaryOfRevenue = (pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay)Application.OpenForms[pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name];
                    frmSummaryOfRevenue.Export(callFrom, "XLSX");
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn đóng phần mềm?") != DialogResult.Yes)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupFunctions_CollectAndSpend_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupFunctions_CollectAndSpend), this, txtCurrentForm))
                {
                    pageManagement_groupFunctions_CollectAndSpend frmCollectAndSpend = new pageManagement_groupFunctions_CollectAndSpend();
                    frmCollectAndSpend.MdiParent = this;
                    txtCurrentForm.EditValue = frmCollectAndSpend.Text;
                    frmCollectAndSpend.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupFunctions_PromotionOnTotalBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupFunctions_PromotionOnTotalBill), this, txtCurrentForm))
                {
                    pageManagement_groupFunctions_PromotionOnTotalBill frmPromotionOnTotalBill = new pageManagement_groupFunctions_PromotionOnTotalBill();
                    frmPromotionOnTotalBill.MdiParent = this;
                    txtCurrentForm.EditValue = frmPromotionOnTotalBill.Text;
                    frmPromotionOnTotalBill.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageCategories_groupMaterialMenu_MenuAndMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageCategories_groupMaterialMenu_MenuAndMaterial), this, txtCurrentForm))
                {
                    pageCategories_groupMaterialMenu_MenuAndMaterial frmMenuAndMaterial = new pageCategories_groupMaterialMenu_MenuAndMaterial();
                    frmMenuAndMaterial.MdiParent = this;
                    txtCurrentForm.EditValue = frmMenuAndMaterial.Text;
                    frmMenuAndMaterial.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupFunctions_ImportMaterials_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupFunctions_ImportMaterials), this, txtCurrentForm))
                {
                    pageManagement_groupFunctions_ImportMaterials frmImportMaterials = new pageManagement_groupFunctions_ImportMaterials();
                    frmImportMaterials.MdiParent = this;
                    txtCurrentForm.EditValue = frmImportMaterials.Text;
                    frmImportMaterials.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageReport_groupWarehouse_Inventory_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageReport_groupWarehouse_Inventory), this, txtCurrentForm))
                {
                    pageReport_groupWarehouse_Inventory frmInventory = new pageReport_groupWarehouse_Inventory();
                    frmInventory.MdiParent = this;
                    txtCurrentForm.EditValue = frmInventory.Text;
                    frmInventory.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupSalaryManagement_Payroll_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupSalaryManagement_Payroll), this, txtCurrentForm))
                {
                    pageManagement_groupSalaryManagement_Payroll frmPayroll = new pageManagement_groupSalaryManagement_Payroll();
                    frmPayroll.MdiParent = this;
                    txtCurrentForm.EditValue = frmPayroll.Text;
                    frmPayroll.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupSalaryManagement_Overtime_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupSalaryManagement_Overtime), this, txtCurrentForm))
                {
                    pageManagement_groupSalaryManagement_Overtime frmOvertime = new pageManagement_groupSalaryManagement_Overtime();
                    frmOvertime.MdiParent = this;
                    txtCurrentForm.EditValue = frmOvertime.Text;
                    frmOvertime.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupSalaryManagement_Timekeeping_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupSalaryManagement_Timekeeping frmTimekeeping = new pageManagement_groupSalaryManagement_Timekeeping();
                frmTimekeeping.BringToFront();
                frmTimekeeping.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupSalaryManagement_AttendanceData_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageManagement_groupSalaryManagement_AttendanceData), this, txtCurrentForm))
                {
                    pageManagement_groupSalaryManagement_AttendanceData frmAttendanceData = new pageManagement_groupSalaryManagement_AttendanceData();
                    frmAttendanceData.MdiParent = this;
                    txtCurrentForm.EditValue = frmAttendanceData.Text;
                    frmAttendanceData.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageReport_groupRevenue_BestSeller_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageReport_groupRevenue_BestSeller), this, txtCurrentForm))
                {
                    pageReport_groupRevenue_BestSeller frmBestSeller = new pageReport_groupRevenue_BestSeller();
                    frmBestSeller.MdiParent = this;
                    txtCurrentForm.EditValue = frmBestSeller.Text;
                    frmBestSeller.Show();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageManagement_groupSalaryManagement_TimekeepingOther_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupSalaryManagement_TimekeepingOther frmTimekeepingOther = new pageManagement_groupSalaryManagement_TimekeepingOther();
                frmTimekeepingOther.BringToFront();
                frmTimekeepingOther.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void timerAutoReport_Tick(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                timerAutoReport.Stop();
                timerAutoReport.Enabled = false;

                #region Load Email to

                string vEmailAddress = Parameters.Definition.AUTO_REPORT_EMAIL;
                string[] vArrEmail = vEmailAddress.Split(';');

                #endregion

                #region Subject

                string vSubject = "Ken&Ben - " + Parameters.Definition.BRANCH_NAME + "(" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ")";

                #endregion

                #region Body

                string vBody_Content = "";
               
                DataTable dtOrder = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.Revenue_Employee(callFrom, ref dtOrder, "", DateTime.Now, DateTime.Now, "'CASH','BANK','GRAB','SHOPEE'");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_Employee:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_Employee");
                    return;
                }

                if (dtOrder == null || dtOrder.Rows.Count == 0)
                    return;

                DataView dv = dtOrder.DefaultView;
                dv.Sort = "PaymentedDate DESC";
                dtOrder = dv.ToTable();

                vBody_Content = "<body>";
                vBody_Content = vBody_Content + @"   <table>
                                                        <tr>
                                                            <td><center><b>Loại thanh toán</b></center></td>
                                                            <td><center><b>Thời gian thu tiền</b></center></td>
                                                            <td><center><b>Nhân viên thu tiền</b></center></td>
                                                            <td><center><b>Tổng tiền</b></center></td>
                                                        </tr>";

                string vBody_Content_Detail = "";
                string vBody_Content_Total = "";

                decimal vTotal = 0;
                foreach (DataRow dr in dtOrder.Rows)
                {
                    vBody_Content_Detail = vBody_Content_Detail + @"   <tr>
                                                            <td><center>" + dr["PaymentedType"].ToString() + @"</center></td>
                                                            <td><center>" + DateTime.Parse(dr["PaymentedDate"].ToString()).ToString("dd/MM/yyyy HH:mm") + @"</center></td>
                                                            <td><center>" + dr["PaymentedByName"].ToString() + @"</center></td>
                                                            <td style=""text-align:right;color:red"">" + decimal.Parse(dr["PaymentedTotal"].ToString()).ToString("n0") + @"</td>
                                                        </tr>";

                    vTotal = vTotal + decimal.Parse(dr["PaymentedTotal"].ToString());
                }

                vBody_Content_Total = @"      <tr>
                                                            <td colspan=3 style=""text-align:right;color:blue""><b>Tổng cộng</b></td>
                                                            <td style=""text-align:right;color:red""><b>" + vTotal.ToString("n0") + @"</b></td>
                                                        </tr>";

                vBody_Content = vBody_Content + vBody_Content_Total + vBody_Content_Detail + "   </table>";
                vBody_Content = vBody_Content + "</body>";

                string vBody_Begin = @"<html>
                                            <head>
                                                <style>
                                                    table, th, td {
                                                                      border: 1px solid black;
                                                                      border-collapse: collapse;
                                                                    }
                                                </style>
                                            </head>";
                string vBody_End = "</html>";

                string vBody = vBody_Begin + vBody_Content + vBody_End;

                #endregion

                dtoMailMessage Msg = new dtoMailMessage();
                Msg.EmailTo = new List<string>();

                foreach (string email in vArrEmail)
                    if (email.Trim() != "")
                        Msg.EmailTo.Add(email.Trim());

                if (Msg.EmailTo.Count == 0)
                    return;

                Msg.Subject = vSubject;
                Msg.Body = vBody;
                Msg.IsBodyHtml = true;

                string vResult = Utilities.MailManagement.SendMail_GoogleSMTP(Msg);
                if (vResult != "@@SUCCESS@@") {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.IsFocusForm(typeof(pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay), this, txtCurrentForm))
                {
                    pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay frmEmployee = new pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay();
                    frmEmployee.MdiParent = this;
                    txtCurrentForm.EditValue = frmEmployee.Text;
                    frmEmployee.Show();
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