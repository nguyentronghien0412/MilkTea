using BusinessLogicLayer;
using DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Utilities;

namespace PresentationLayer
{
    public partial class pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_rpt rptSummaryOfRevenue = new pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_rpt();
        DataTable dtData = new DataTable();

        public pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Báo cáo Doanh thu theo nhân viên.");
                this.Close();
            }
        }

        private void pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void LoadEmployees(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtEmplpoyee = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.Revenue_Employee_GetListEmployees(callFrom, ref dtEmplpoyee, dateFrom.DateTime, dateTo.DateTime);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_Employee_GetListEmployees:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_Employee_GetListEmployees");
                }

                if (dtEmplpoyee.Rows.Count > 0)
                {
                    if (Utilities.Multi.CheckRight_PermissionByCode("pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay", Utilities.Parameters.Permission_VIEW_ALL))
                    {
                        DataRow dr = dtEmplpoyee.NewRow();
                        dr["ActionBy"] = -1;
                        dr["ActionByName"] = "Tất cả";
                        dtEmplpoyee.Rows.InsertAt(dr, 0);
                    }
                    else
                    {
                        for (int i = 0; i < dtEmplpoyee.Rows.Count; i++)
                        {
                            if (dtEmplpoyee.Rows[i]["ActionBy"].ToString() != Utilities.Parameters.UserLogin.UserID)
                            {
                                dtEmplpoyee.Rows.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                    }
                }

                Utilities.Multi.Populate_LookUpEdit(slkEmployees, dtEmplpoyee, "ActionBy", "ActionByName");

                if (dtEmplpoyee == null || dtEmplpoyee.Rows.Count == 0)
                    slkEmployees.EditValue = null;
                else
                    slkEmployees.EditValue = int.Parse(Utilities.Parameters.UserLogin.UserID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dateFrom.DateTime = DateTime.Now;
                dateTo.DateTime = DateTime.Now;

                LoadEmployees(callFrom);

                frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcData.DataSource = null;
                documentViewer1.PrintingSystem = null;
                LoadEmployees(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcData.DataSource = null;
                documentViewer1.PrintingSystem = null;
                LoadEmployees(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void slkEmployees_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcData.DataSource = null;
                documentViewer1.PrintingSystem = null;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (slkEmployees.EditValue == null || slkEmployees.EditValue.ToString() == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Nhân viên.");
                    return;
                }

                string _PaymentBy = "";
                if (int.Parse(slkEmployees.EditValue.ToString()) > 0)
                    _PaymentBy = slkEmployees.EditValue.ToString();

                busReport bReport = new busReport();
                dtData = new DataTable();

                splashScreenManager1.ShowWaitForm();
                string result = bReport.Revenue_SummaryOfRevenueByEmployee(callFrom, ref dtData, _PaymentBy, dateFrom.DateTime, dateTo.DateTime);
                splashScreenManager1.CloseWaitForm();

                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_SummaryOfRevenueByEmployee:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_SummaryOfRevenueByEmployee");
                    return;
                }

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtData.Rows)
                        dr["Total"] = decimal.Parse(dr["Cash"].ToString()) + decimal.Parse(dr["Bank"].ToString()) + decimal.Parse(dr["Grab"].ToString()) + decimal.Parse(dr["Shopee"].ToString());
                }

                gcData.DataSource = dtData;

                #region dtoSummaryOfRevenueByEmployee

                splashScreenManager1.ShowWaitForm();

                dtoSummaryOfRevenueByEmployee PrintBill = new dtoSummaryOfRevenueByEmployee();
                PrintBill.DateFrom = dateFrom.DateTime.ToString("dd/MM/yyyy");
                PrintBill.DateTo = dateTo.DateTime.ToString("dd/MM/yyyy");
                PrintBill.DateAction = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                PrintBill.EmployeeAction = Utilities.Parameters.UserLogin.EmployeesName;

                decimal vTotalCash = 0;
                decimal vTotalBank = 0;
                decimal vTotalGrab = 0;
                decimal vTotalShopee = 0;
                foreach (DataRow dr in dtData.Rows)
                {
                    vTotalCash = vTotalCash + decimal.Parse(dr["Cash"].ToString());
                    vTotalBank = vTotalBank + decimal.Parse(dr["Bank"].ToString());
                    vTotalGrab = vTotalGrab + decimal.Parse(dr["Grab"].ToString());
                    vTotalShopee = vTotalShopee + decimal.Parse(dr["Shopee"].ToString());
                }

                PrintBill.TotalCash = vTotalCash.ToString("n0");
                PrintBill.TotalBank = vTotalBank.ToString("n0");
                PrintBill.TotalGrab = vTotalGrab.ToString("n0");
                PrintBill.TotalShopee = vTotalShopee.ToString("n0");
                PrintBill.TotalAmount = (vTotalCash + vTotalBank + vTotalGrab + vTotalShopee).ToString("n0");

                rptSummaryOfRevenue.DataSource = dtData;
                rptSummaryOfRevenue.BindData();
                rptSummaryOfRevenue.BindData_Information(PrintBill);
                documentViewer1.PrintingSystem = rptSummaryOfRevenue.PrintingSystem;
                rptSummaryOfRevenue.CreateDocument();

                rptSummaryOfRevenue.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                rptSummaryOfRevenue.ShowPrintStatusDialog = false;

                splashScreenManager1.CloseWaitForm();

                #endregion

                if (dtData == null || dtData.Rows.Count == 0)
                    frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(false, false, false, false, false, false, false, true, true, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string GetPrinterName(string PrinterCode)
        {
            string PrinterName = "";

            if (File.Exists(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath)))
            {
                //load config
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                XmlNode PRINTER_GUIDE_DRUG = doc.SelectSingleNode(@"Root/" + PrinterCode);
                if (PRINTER_GUIDE_DRUG != null)
                    if (PRINTER_GUIDE_DRUG.Attributes["PrinterName"] != null)
                        PrinterName = PRINTER_GUIDE_DRUG.Attributes["PrinterName"].Value;
            }

            return PrinterName;
        }

        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        public void Print(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string PrinterName = GetPrinterName("PRINTER_BILL");
                if (PrinterName == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng cấu hình máy in.");
                    return;
                }

                splashScreenManager1.ShowWaitForm();
                SendMail(callFrom);
                splashScreenManager1.CloseWaitForm();

                using (ReportPrintTool printTool = new ReportPrintTool(rptSummaryOfRevenue))
                {
                    if (PrinterName != "")
                        printTool.PrinterSettings.PrinterName = PrinterName;

                    printTool.Print();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void SendMail(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtData == null || dtData.Rows.Count == 0)
                    return;

                frmMain.LoadDefinition(callFrom);
                if (Utilities.Parameters.Definition.SMTP_GG_ENABLE != "ON")
                    return;

                #region Load Email to

                string vEmailAddress = Parameters.Definition.SUMMARY_OF_REVENUE;
                string[] vArrEmail = vEmailAddress.Split(';');

                #endregion

                #region Subject

                string vSubject;

                if (dateFrom.DateTime.Year == dateTo.DateTime.Year &&
                    dateFrom.DateTime.Month == dateTo.DateTime.Month &&
                    dateFrom.DateTime.Day == dateTo.DateTime.Day)
                    vSubject = "Tổng hợp doanh thu - " + Parameters.Definition.BRANCH_NAME + " (" + dateFrom.DateTime.ToString("dd/MM/yyyy") + ")";
                else
                    vSubject = "Tổng hợp doanh thu - " + Parameters.Definition.BRANCH_NAME + " (" + dateFrom.DateTime.ToString("dd/MM/yyyy") + " -> " + dateTo.DateTime.ToString("dd/MM/yyyy") + ")";

                #endregion

                #region Body

                string vDateFrom = dateFrom.DateTime.ToString("dd/MM/yyyy");
                string vDateTo = dateTo.DateTime.ToString("dd/MM/yyyy");
                string vDateAction = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                string vEmployeeAction = Utilities.Parameters.UserLogin.EmployeesName;

                string vBody_Content = "";

                vBody_Content = "<body>";

                vBody_Content = vBody_Content + "<table class=\"table2\">";
                
                vBody_Content = vBody_Content + "<tr>";
                vBody_Content = vBody_Content + "   <td>Từ ngày:</td>";
                vBody_Content = vBody_Content + "   <td><b>" + vDateFrom + "</b></td>";
                vBody_Content = vBody_Content + "   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                vBody_Content = vBody_Content + "   <td>Giờ tổng hợp:</td>";
                vBody_Content = vBody_Content + "   <td><b>" + vDateAction + "</b></td>";
                vBody_Content = vBody_Content + "</tr>";

                vBody_Content = vBody_Content + "<tr>";
                vBody_Content = vBody_Content + "   <td>Đến ngày:</td>";
                vBody_Content = vBody_Content + "   <td><b>" + vDateFrom + "</b></td>";
                vBody_Content = vBody_Content + "   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                vBody_Content = vBody_Content + "   <td>Nhân viên tổng hợp:</td>";
                vBody_Content = vBody_Content + "   <td><b>" + vEmployeeAction + "</b></td>";
                vBody_Content = vBody_Content + "</tr>";

                vBody_Content = vBody_Content + "</table><br>";

                vBody_Content = vBody_Content + @" <table class=""table2"">
                                                        <tr  class=""table2"">
                                                            <td class=""table2""><center><b>Mã nhân viên</b></center></td>
                                                            <td class=""table2""><center><b>Tên nhân viên</b></center></td>
                                                            <td class=""table2""><center><b>Tiền mặt</b></center></td>
                                                            <td class=""table2""><center><b>Chuyển khoản</b></center></td>
                                                            <td class=""table2""><center><b>Grab</b></center></td>
                                                            <td class=""table2""><center><b>Shopee</b></center></td>
                                                            <td class=""table2""><center><b>Tổng tiền</b></center></td>
                                                        </tr>";

                decimal vTotalCash = 0;
                decimal vTotalBank = 0;
                decimal vTotalGrab = 0;
                decimal vTotalShopee = 0;

                foreach (DataRow dr in dtData.Rows)
                {
                    vBody_Content = vBody_Content + @"   <tr  class=""table2"">
                                                            <td class=""table2""><center>" + dr["PaymentedByID"].ToString() + @"</center></td>
                                                            <td class=""td1"">" + dr["PaymentedByName"].ToString() + @"</td>
                                                            <td class=""td2"">" + decimal.Parse(dr["Cash"].ToString()).ToString("n0") + @"</td>
                                                            <td class=""td2"">" + decimal.Parse(dr["Bank"].ToString()).ToString("n0") + @"</td>
                                                            <td class=""td2"">" + decimal.Parse(dr["Grab"].ToString()).ToString("n0") + @"</td>
                                                            <td class=""td2"">" + decimal.Parse(dr["Shopee"].ToString()).ToString("n0") + @"</td>
                                                            <td class=""td2"">" + decimal.Parse(dr["Total"].ToString()).ToString("n0") + @"</td>
                                                        </tr>";

                    vTotalCash = vTotalCash + decimal.Parse(dr["Cash"].ToString());
                    vTotalBank = vTotalBank + decimal.Parse(dr["Bank"].ToString());
                    vTotalGrab = vTotalGrab + decimal.Parse(dr["Grab"].ToString());
                    vTotalShopee = vTotalShopee + decimal.Parse(dr["Shopee"].ToString());
                }

                decimal vTotalAmount = vTotalCash + vTotalBank + vTotalGrab + vTotalShopee;

                vBody_Content = vBody_Content + @"      <tr>
                                                            <td colspan=2 class=""td3""><b>Tổng cộng</b></td>
                                                            <td class=""td4""><b>" + vTotalCash.ToString("n0") + @"</b></td>
                                                            <td class=""td4""><b>" + vTotalBank.ToString("n0") + @"</b></td>
                                                            <td class=""td4""><b>" + vTotalGrab.ToString("n0") + @"</b></td>
                                                            <td class=""td4""><b>" + vTotalShopee.ToString("n0") + @"</b></td>
                                                            <td class=""td4""><b>" + vTotalAmount.ToString("n0") + @"</b></td>
                                                        </tr>";

                vBody_Content = vBody_Content + "   </table>";
                vBody_Content = vBody_Content + "</body>";

                string vBody_Begin = @"<html>
                                            <head>
                                                <style>
                                                    .table1{
                                                                border: 0px;
                                                                border-collapse: collapse;
                                                           }
                                                    .table2{
                                                                border: 1px solid black;
                                                                border-collapse: collapse;
                                                           }
                                                    .td1{
                                                                border: 1px solid black;
                                                                border-collapse: collapse;
                                                                text-align:left;
                                                           }
                                                    .td2{
                                                                border: 1px solid black;
                                                                border-collapse: collapse;
                                                                text-align:right;
                                                           }
                                                    .td3{
                                                                border: 1px solid black;
                                                                border-collapse: collapse;
                                                                text-align:right;color:blue
                                                           }
                                                    .td4{
                                                                border: 1px solid black;
                                                                border-collapse: collapse;
                                                                text-align:right;color:red
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
                if (vResult != "@@SUCCESS@@")
                {
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

        public void Export(string CallBy, string Type)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dateFrom.DateTime.Year == dateTo.DateTime.Year &&
                    dateFrom.DateTime.Month == dateTo.DateTime.Month &&
                    dateFrom.DateTime.Day == dateTo.DateTime.Day)
                    xtraSaveFileDialog1.FileName = "TongHopDoanhThuTheoNhanVien_" + dateFrom.DateTime.ToString("dd_MM_yyyy");
                else
                    xtraSaveFileDialog1.FileName = "TongHopDoanhThuTheoNhanVien_" + dateFrom.DateTime.ToString("dd_MM_yyyy") + "_" + dateTo.DateTime.ToString("dd_MM_yyyy");

                if (Type.ToUpper() == "PDF")
                    xtraSaveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
                else if (Type.ToUpper() == "DOCX")
                    xtraSaveFileDialog1.Filter = "Word files (*.docx)|*.docx";
                else if (Type.ToUpper() == "XLSX")
                    xtraSaveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    splashScreenManager1.ShowWaitForm();

                    if (Type.ToUpper() == "PDF")
                        rptSummaryOfRevenue.ExportToPdf(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "DOCX")
                        rptSummaryOfRevenue.ExportToDocx(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "XLSX")
                        rptSummaryOfRevenue.ExportToXlsx(xtraSaveFileDialog1.FileName);

                    splashScreenManager1.CloseWaitForm();
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