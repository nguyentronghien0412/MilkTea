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
    public partial class pageReport_groupRevenue_BestSeller : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;

        public pageReport_groupRevenue_BestSeller()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Báo cáo.");
                this.Close();
            }
        }

        private void bgvReport_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void pageReport_groupRevenue_BestSeller_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageReport_groupRevenue_BestSeller_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
                BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
                string result = bGeneral.GetAll(callFrom, ref dtTemp, TableName, "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> " + TableName);
                    this.Close();
                }

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private void pageReport_groupRevenue_BestSeller_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Multi.CheckRight_PermissionByCode("pageReport_groupRevenue_BestSeller", Utilities.Parameters.Permission_VIEW_ALL))
                    bgvReport_colTotalAmount.Visible = true;
                else
                    bgvReport_colTotalAmount.Visible = false;

                Populate_LookUpEdit(bgvReport_colSizeID_lk, "Size");

                dateFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                dateTo.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1);

                bgvReport_colActionDate.Visible = false;

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
                gcReport.DataSource = null;
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
                gcReport.DataSource = null;
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
                if (chkViewByDate.Checked)
                    bgvReport_colActionDate.GroupIndex = 0;
                else
                    bgvReport_colActionDate.GroupIndex = -1;

                DataTable dtData = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.BestSeller(callFrom, ref dtData, dateFrom.DateTime, dateTo.DateTime, chkViewByDate.Checked);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> BestSeller:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> BestSeller");
                    return;
                }
                gcReport.DataSource = dtData;
                chkExpand.Checked = true;
                chkExpand_CheckedChanged(null, null);

                if (dtData == null || dtData.Rows.Count == 0)
                    frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(false, false, false, false, false, false, true, true, true, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Print(string CallBy, bool IsPrint)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (IsPrint)
                    gcReport.PrintDialog();
                else
                    gcReport.ShowPrintPreview();
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
                    xtraSaveFileDialog1.FileName = "DanhSachCacMonDaBan_" + dateFrom.DateTime.ToString("dd_MM_yyyy");
                else
                    xtraSaveFileDialog1.FileName = "DanhSachCacMonDaBan_" + dateFrom.DateTime.ToString("dd_MM_yyyy") + "_" + dateTo.DateTime.ToString("dd_MM_yyyy");

                if (Type.ToUpper() == "PDF")
                    xtraSaveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
                else if (Type.ToUpper() == "DOCX")
                    xtraSaveFileDialog1.Filter = "Word files (*.docx)|*.docx";
                else if (Type.ToUpper() == "XLSX")
                    xtraSaveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Type.ToUpper() == "PDF")
                        gcReport.ExportToPdf(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "DOCX")
                        gcReport.ExportToDocx(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "XLSX")
                        gcReport.ExportToXlsx(xtraSaveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void chkViewByDate_CheckedChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcReport.DataSource = null;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
                bgvReport.CollapseAllGroups();
            else
                bgvReport.ExpandAllGroups();
        }
    }
}