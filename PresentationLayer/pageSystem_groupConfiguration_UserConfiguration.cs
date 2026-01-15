using BusinessLogicLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PresentationLayer
{
    public partial class pageSystem_groupConfiguration_UserConfiguration : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        DataTable dtDefinition = new DataTable();

        #region Functions

        private void SetData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.Tag != null && this.Tag.ToString() != Utilities.Parameters.Permission_EDIT)
                {
                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    frmMain.EnableAction(false, false, true, false, false, true, false, false, false, arrIndex);
                    return;
                }

                if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                    gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_COLOR_REQUIRED)
                {
                    #region Definition_COLOR_REQUIRED

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    ColorDialog col = new ColorDialog();
                    DialogResult dlg = col.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        string color = col.Color.ToArgb().ToString("x");
                        color = color.Substring(2, 6);
                        color = "#" + color;
                        gvDefinition.SetFocusedRowCellValue(colValue, color);
                    }

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                  gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_WAREHOUSE)
                {
                    #region Definition_WAREHOUSE

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    pageSystem_groupConfiguration_UserConfiguration_Warehouse frmWarehouse = new pageSystem_groupConfiguration_UserConfiguration_Warehouse();
                    frmWarehouse._Title = "Quản lý tồn kho";
                    DialogResult dlg = frmWarehouse.ShowDialog();
                    if (dlg == DialogResult.Yes)
                        gvDefinition.SetFocusedRowCellValue(colValue, "ON");
                    else
                        gvDefinition.SetFocusedRowCellValue(colValue, "OFF");

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                   gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_BANK_QRCODE)
                {
                    #region Definition_BANK_QRCODE

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    if (gvDefinition.GetFocusedRowCellValue(colValueImage) == null || gvDefinition.GetFocusedRowCellValue(colValueImage).ToString() == "")
                    {
                        DialogResult dlg = xtraOpenFileDialog1.ShowDialog();
                        if (dlg == DialogResult.Cancel)
                            return;

                        Image img = null;
                        FileStream fs = new FileStream(xtraOpenFileDialog1.FileName, FileMode.Open);
                        img = Image.FromStream(fs);
                        fs.Close();

                        byte[] b = Utilities.Functions.ImageToByteArray(img);

                        gvDefinition.SetFocusedRowCellValue(colValueImage, b);
                    }
                    else
                    {
                        if (Utilities.Functions.MessageBoxYesNo("Bạn có muốn bỏ QR Code này không ?") == DialogResult.Yes)
                        {
                            gvDefinition.SetFocusedRowCellValue(colValueImage, null);
                        }
                        else
                        {
                            DialogResult dlg = xtraOpenFileDialog1.ShowDialog();
                            if (dlg == DialogResult.Cancel)
                                return;

                            Image img = null;
                            FileStream fs = new FileStream(xtraOpenFileDialog1.FileName, FileMode.Open);
                            img = Image.FromStream(fs);
                            fs.Close();

                            byte[] b = Utilities.Functions.ImageToByteArray(img);

                            gvDefinition.SetFocusedRowCellValue(colValueImage, b);
                        }
                    }

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                  gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_PRINT_STICKER)
                {
                    #region Definition_PRINT_STICKER

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    pageSystem_groupConfiguration_UserConfiguration_Warehouse frmWarehouse = new pageSystem_groupConfiguration_UserConfiguration_Warehouse();
                    frmWarehouse._Title = "In Sticker tên món khi thanh toán";
                    DialogResult dlg = frmWarehouse.ShowDialog();
                    if (dlg == DialogResult.Yes)
                        gvDefinition.SetFocusedRowCellValue(colValue, "ON");
                    else
                        gvDefinition.SetFocusedRowCellValue(colValue, "OFF");

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                  gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_SMTP_GG_SSL)
                {
                    #region Definition_SMTP_GG_SSL

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    pageSystem_groupConfiguration_UserConfiguration_Warehouse frmWarehouse = new pageSystem_groupConfiguration_UserConfiguration_Warehouse();
                    frmWarehouse._Title = "Enable Ssl";
                    DialogResult dlg = frmWarehouse.ShowDialog();
                    if (dlg == DialogResult.Yes)
                        gvDefinition.SetFocusedRowCellValue(colValue, "ON");
                    else
                        gvDefinition.SetFocusedRowCellValue(colValue, "OFF");

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                  gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_SMTP_GG_CREDENTIALS)
                {
                    #region Definition_SMTP_GG_CREDENTIALS

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    pageSystem_groupConfiguration_UserConfiguration_Warehouse frmWarehouse = new pageSystem_groupConfiguration_UserConfiguration_Warehouse();
                    frmWarehouse._Title = "Use Default Credentials";
                    DialogResult dlg = frmWarehouse.ShowDialog();
                    if (dlg == DialogResult.Yes)
                        gvDefinition.SetFocusedRowCellValue(colValue, "ON");
                    else
                        gvDefinition.SetFocusedRowCellValue(colValue, "OFF");

                    #endregion
                }
                else if (gvDefinition.GetFocusedRowCellValue(colCode) != null &&
                  gvDefinition.GetFocusedRowCellValue(colCode).ToString() == Utilities.Parameters.Definition_SMTP_GG_ENABLE)
                {
                    #region Definition_SMTP_GG_ENABLE

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;

                    pageSystem_groupConfiguration_UserConfiguration_Warehouse frmWarehouse = new pageSystem_groupConfiguration_UserConfiguration_Warehouse();
                    frmWarehouse._Title = "Tự động gửi báo cáo thanh toán đơn hàng";
                    DialogResult dlg = frmWarehouse.ShowDialog();
                    if (dlg == DialogResult.Yes)
                        gvDefinition.SetFocusedRowCellValue(colValue, "ON");
                    else
                        gvDefinition.SetFocusedRowCellValue(colValue, "OFF");

                    #endregion
                }
                else
                {
                    gvDefinition.OptionsBehavior.Editable = true;
                    gvDefinition.OptionsBehavior.ReadOnly = false;
                }

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
                EnableControl(callFrom, true);

                gvDefinition.OptionsBehavior.Editable = false;
                gvDefinition.OptionsBehavior.ReadOnly = true;

                if (gvDefinition.FocusedRowHandle >= 0)
                {
                    if (gvDefinition.GetFocusedRowCellValue(colCode) != null && 
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_COLOR_REQUIRED &&
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_WAREHOUSE &&
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_PRINT_STICKER &&
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_SMTP_GG_ENABLE &&
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_SMTP_GG_SSL &&
                        gvDefinition.GetFocusedRowCellValue(colCode).ToString() != Utilities.Parameters.Definition_SMTP_GG_CREDENTIALS)
                    {
                        gvDefinition.OptionsBehavior.Editable = true;
                        gvDefinition.OptionsBehavior.ReadOnly = false;
                    }
                }

                colValue.AppearanceCell.BackColor = Color.FromArgb(192, 255, 255);

                gvDefinition.FocusedRowHandle = 0;

                this.Tag = Utilities.Parameters.Permission_EDIT;
                frmMain.EnableAction(false, true, false, false, true, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckValid()
        {
            foreach (DataRow dr in dtDefinition.Rows)
            {
                if (dr["Value"].ToString().Trim() == "")
                    return "Vui lòng nhập đầy đủ thông tin.";

                if (dr["Code"].ToString().Trim() == "QUANTITY_BILL")
                {
                    if (dr["Value"].ToString().Trim() == "")
                        return "Vui lòng nhập Số lượng bản in.";
                    //else if (decimal.Parse(dr["Value"].ToString().Trim()) == 0)
                    //    return "Vui lòng nhập Số lượng bản in.";
                    else if (decimal.Parse(dr["Value"].ToString().Trim()) > 5)
                        return "Số lượng bản in tối đa là 5.";
                }
            }

            return "";
        }

        public void Save(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gvDefinition.CloseEditor();
                gvDefinition.UpdateCurrentRow();
                dtDefinition.AcceptChanges();

                string msg = CheckValid();
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Warning, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                msg = CheckValid();
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Warning, msg, 5000);
                    return;
                }

                foreach (DataRow dr in dtDefinition.Rows)
                    if (dr["IsEncrypt"].ToString() == "1")
                        if (dr["Value"].ToString() != "")
                            dr["Value"] = Utilities.Functions.EncryptByRC2(dr["Value"].ToString(), Utilities.Parameters.KEY_Definition, Utilities.Parameters.IV_Definition);

                dtDefinition.AcceptChanges();

                busGeneralFunctions bGeneral = new busGeneralFunctions();
                string result = bGeneral.UpdateByID(callFrom, dtDefinition);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UpdateByID:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> UpdateByID");
                    return;
                }
                else
                {
                    #region save to xml config

                    XmlDocument doc = new XmlDocument();
                    if (File.Exists(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath)))
                    {
                        doc.Load(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                        #region node PRINTER_LABEL

                        XmlNode PRINTER_BILL = doc.SelectSingleNode(@"Root/PRINTER_BILL");
                        if (PRINTER_BILL == null)
                        {
                            #region new node PRINTER_BILL

                            PRINTER_BILL = doc.CreateNode(XmlNodeType.Element, "PRINTER_BILL", "");

                            XmlAttribute Name = doc.CreateAttribute("PrinterName");
                            Name.Value = glkPrinterBill.Text;
                            PRINTER_BILL.Attributes.Append(Name);

                            XmlElement root = doc.DocumentElement;
                            root.AppendChild(PRINTER_BILL);

                            #endregion
                        }
                        else
                        {
                            #region add/update Name
                            if (PRINTER_BILL.Attributes["PrinterName"] == null)
                            {
                                XmlAttribute Name = doc.CreateAttribute("PrinterName");
                                Name.Value = glkPrinterBill.Text;
                                PRINTER_BILL.Attributes.Append(Name);
                            }
                            else
                            {
                                PRINTER_BILL.Attributes["PrinterName"].Value = glkPrinterBill.Text;
                            }
                            #endregion
                        }
                        #endregion

                        #region node PRINTER_STICKER

                        XmlNode PRINTER_STICKER = doc.SelectSingleNode(@"Root/PRINTER_STICKER");
                        if (PRINTER_STICKER == null)
                        {
                            #region new node PRINTER_STICKER

                            PRINTER_STICKER = doc.CreateNode(XmlNodeType.Element, "PRINTER_STICKER", "");

                            XmlAttribute Name = doc.CreateAttribute("PrinterName");
                            Name.Value = glkPrinterSticker.Text;
                            PRINTER_STICKER.Attributes.Append(Name);

                            XmlElement root = doc.DocumentElement;
                            root.AppendChild(PRINTER_STICKER);

                            #endregion
                        }
                        else
                        {
                            #region add/update Name
                            if (PRINTER_STICKER.Attributes["PrinterName"] == null)
                            {
                                XmlAttribute Name = doc.CreateAttribute("PrinterName");
                                Name.Value = glkPrinterSticker.Text;
                                PRINTER_STICKER.Attributes.Append(Name);
                            }
                            else
                            {
                                PRINTER_STICKER.Attributes["PrinterName"].Value = glkPrinterSticker.Text;
                            }
                            #endregion
                        }
                        #endregion
                    }
                    doc.Save(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                    #endregion

                    gvDefinition.OptionsBehavior.Editable = false;
                    gvDefinition.OptionsBehavior.ReadOnly = true;
                    colValue.AppearanceCell.BackColor = Color.White;

                    pageSystem_groupConfiguration_UserConfiguration_Load(null, null);
                    this.Tag = Utilities.Parameters.Permission_SAVE;
                    frmMain.EnableAction(false, false, true, false, false, true, false, false, false, arrIndex);

                    result = Utilities.Multi.LoadDefinition(dtDefinition);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> LoadDefinition:\n" + result);
                        MessageBox.Show(result + "\n" + callFrom + " -> LoadDefinition", Utilities.Parameters.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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

                EnableControl(callFrom, false);

                gvDefinition.OptionsBehavior.Editable = false;
                gvDefinition.OptionsBehavior.ReadOnly = true;
                colValue.AppearanceCell.BackColor = Color.White;

                pageSystem_groupConfiguration_UserConfiguration_Load(null, null);

                this.Tag = Utilities.Parameters.Permission_CANCEL;
                frmMain.EnableAction(false, false, true, false, false, true, false, false, false, arrIndex);
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
                pageSystem_groupConfiguration_UserConfiguration_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListPrinters()
        {
            DataTable dtPrinters = new DataTable();
            dtPrinters.Columns.Add("PrinterName", typeof(string));
            dtPrinters.Columns.Add("Status", typeof(string));
            dtPrinters.Columns.Add("Default", typeof(bool));
            dtPrinters.Columns.Add("Network", typeof(bool));

            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                DataRow dr = dtPrinters.NewRow();

                dr["PrinterName"] = printer.GetPropertyValue("Name");
                dr["Status"] = printer.GetPropertyValue("Status");
                dr["Default"] = printer.GetPropertyValue("Default");
                dr["Network"] = printer.GetPropertyValue("Network");

                dtPrinters.Rows.Add(dr);
            }

            glkPrinterBill.Properties.ValueMember = "PrinterName";
            glkPrinterBill.Properties.DisplayMember = "PrinterName";
            glkPrinterBill.Properties.DataSource = dtPrinters;

            glkPrinterSticker.Properties.ValueMember = "PrinterName";
            glkPrinterSticker.Properties.DisplayMember = "PrinterName";
            glkPrinterSticker.Properties.DataSource = dtPrinters;
        }

        private void EnableControl(string CallBy, bool value)
        {
            glkPrinterBill.ReadOnly = !value;
            glkPrinterSticker.ReadOnly = !value;
        }

        #endregion

        #region Events

        public pageSystem_groupConfiguration_UserConfiguration()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Cấu hình thông số.");
                this.Close();
            }
        }

        private void pageSystem_groupConfiguration_UserConfiguration_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageSystem_groupConfiguration_UserConfiguration_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageSystem_groupConfiguration_UserConfiguration_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                EnableControl(callFrom, false);

                #region Printer

                GetListPrinters();
                if (File.Exists(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath))) 
                {
                    //load config
                    XmlDocument doc = new XmlDocument();
                    doc.Load(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                    #region Read config for PRINTER_BILL

                    XmlNode PRINTER_BILL = doc.SelectSingleNode(@"Root/PRINTER_BILL");
                    if (PRINTER_BILL != null)
                    {
                        if (PRINTER_BILL.Attributes["PrinterName"] != null)
                            glkPrinterBill.EditValue = PRINTER_BILL.Attributes["PrinterName"].Value;
                        else
                            glkPrinterBill.EditValue = null;
                    }
                    else
                    {
                        glkPrinterBill.EditValue = null;
                    }

                    #endregion

                    #region Read config for PRINTER_STICKER

                    XmlNode PRINTER_STICKER = doc.SelectSingleNode(@"Root/PRINTER_STICKER");
                    if (PRINTER_STICKER != null)
                    {
                        if (PRINTER_STICKER.Attributes["PrinterName"] != null)
                            glkPrinterSticker.EditValue = PRINTER_STICKER.Attributes["PrinterName"].Value;
                        else
                            glkPrinterSticker.EditValue = null;
                    }
                    else
                    {
                        glkPrinterSticker.EditValue = null;
                    }

                    #endregion
                }

                #endregion

                busGeneralFunctions bGeneral = new busGeneralFunctions();

                #region Definition group

                DataTable dtDefinitionGroup = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtDefinitionGroup, "DefinitionGroup", "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> DefinitionGroup -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> DefinitionGroup -> GetAll");
                }

                Utilities.Multi.Populate_LookUpEdit(colDefinitionGroupID_rlkDefinitionGroup, dtDefinitionGroup, "ID", "Name");

                #endregion

                dtDefinition = new DataTable();
                string[] _FieldName = new string[] { "IsEdit" };
                string[] _Value = new string[] { "1" };

                result = bGeneral.GetByCondition(callFrom, ref dtDefinition, "Definition", _FieldName, _Value, "Name ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Definition -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Definition -> GetByCondition");
                    frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
                    return;
                }

                foreach (DataRow dr in dtDefinition.Rows)
                    if (dr["IsEncrypt"].ToString() == "1")
                        if (dr["Value"].ToString() != "")
                            dr["Value"] = Utilities.Functions.DecryptByRC2(dr["Value"].ToString(), Utilities.Parameters.KEY_Definition, Utilities.Parameters.IV_Definition);

                gcDefinition.DataSource = dtDefinition;
                gvDefinition.ExpandAllGroups();

                this.Tag = Utilities.Parameters.Permission_LOAD;

                if (dtDefinition == null || dtDefinition.Rows.Count == 0)
                    frmMain.EnableAction(false, false, true, false, false, true, false, false, false, arrIndex);
                gvDefinition_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvDefinition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                SetData(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvDefinition_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvDefinition_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                SetData(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageSystem_groupConfiguration_UserConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.Tag != null && (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT))
                {
                    if (Utilities.Functions.MessageBoxYesNo("Cấu hình người dùng chưa được lưu.\nBạn muốn đóng giao diện này?") != DialogResult.Yes)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void glkPrinterBill_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        #endregion

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (Utilities.Parameters.Definition.SMTP_GG_ENABLE == "ON")
            {
                MainForm frmMain = (MainForm)Application.OpenForms[0];
                frmMain.AutoReport();
            }
        }
    }
}