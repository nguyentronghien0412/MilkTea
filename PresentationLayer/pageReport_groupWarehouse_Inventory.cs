using BusinessLogicLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
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
    public partial class pageReport_groupWarehouse_Inventory : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;

        public pageReport_groupWarehouse_Inventory()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex.");
                this.Close();
            }
        }

        private void pageReport_groupWarehouse_Inventory_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtInventory = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.Inventory(callFrom, ref dtInventory);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Inventory:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Inventory");
                    return;
                }

                gcInventory.DataSource = dtInventory;
                chkExpand_CheckedChanged(null, null);

                if (dtInventory == null || dtInventory.Rows.Count == 0)
                    frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(false, false, false, false, false, true, true, true, true, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvInventory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void pageReport_groupWarehouse_Inventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageReport_groupWarehouse_Inventory_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
            {
                for (int i = 0; i < bgvInventory.RowCount; i++)
                    bgvInventory.CollapseMasterRow(i);
                bgvInventory.CollapseAllGroups();
            }
            else
            {
                bgvInventory.ExpandAllGroups();
                for (int i = 0; i < bgvInventory.RowCount; i++)
                    bgvInventory.ExpandMasterRow(i);
            }
        }

        public void Print(string CallBy, bool IsPrint)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (IsPrint)
                    gcInventory.PrintDialog();
                else
                    gcInventory.ShowPrintPreview();
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
                xtraSaveFileDialog1.FileName = "BaoCaoTonKho_" + DateTime.Now.ToString("dd_MM_yyyy");

                if (Type.ToUpper() == "PDF")
                    xtraSaveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
                else if (Type.ToUpper() == "DOCX")
                    xtraSaveFileDialog1.Filter = "Word files (*.docx)|*.docx";
                else if (Type.ToUpper() == "XLSX")
                    xtraSaveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Type.ToUpper() == "PDF")
                        gcInventory.ExportToPdf(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "DOCX")
                        gcInventory.ExportToDocx(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "XLSX")
                        gcInventory.ExportToXlsx(xtraSaveFileDialog1.FileName);
                }
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
                pageReport_groupWarehouse_Inventory_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void bgvInventory_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.RightMargin = 5;
        }

        private void bgvInventory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvInventoryDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}