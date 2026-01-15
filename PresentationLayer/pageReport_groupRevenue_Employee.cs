using BusinessLogicLayer;
using DevExpress.XtraPrinting;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class pageReport_groupRevenue_Employee : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;

        public pageReport_groupRevenue_Employee()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Báo cáo Doanh thu theo nhân viên.");
                this.Close();
            }
        }

        private void bgvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void pageReport_groupRevenue_Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageReport_groupRevenue_Employee_Activated(object sender, EventArgs e)
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
                    if (Utilities.Multi.CheckRight_PermissionByCode("pageReport_groupRevenue_Employee", Utilities.Parameters.Permission_VIEW_ALL))
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

        private void LoadPaymentedType(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtPaymentedType = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.Revenue_GetListPaymentedType(callFrom, ref dtPaymentedType, dateFrom.DateTime, dateTo.DateTime);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_GetListPaymentedType:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_GetListPaymentedType");
                }

                Utilities.Multi.Populate_LookUpEdit(lkPaymentedType, dtPaymentedType, "ID", "Name");

                if (dtPaymentedType == null || dtPaymentedType.Rows.Count == 0)
                    lkPaymentedType.SetEditValue(null);
                else
                {
                    string vValue = "";
                    foreach (DataRow dr in dtPaymentedType.Rows)
                        vValue = vValue + dr["ID"].ToString() + ",";

                    vValue= vValue.Substring(0, vValue.Length - 1);

                    lkPaymentedType.SetEditValue(vValue);
                }

                lkPaymentedType.Properties.DropDownRows = 7;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
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

        private void pageReport_groupRevenue_Employee_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dateFrom.DateTime = DateTime.Now;
                dateTo.DateTime = DateTime.Now;

                LoadEmployees(callFrom);
                LoadPaymentedType(callFrom);

                Populate_LookUpEdit(gvDetail_colMenuID_lk, "Menu");
                Populate_LookUpEdit(gvDetail_colSizeID_lk, "Size");
                Populate_LookUpEdit(gvDetail_colMaterialsID_lk, "Materials");
                Populate_LookUpEdit(gvDetail_colUnitID_lk, "Unit");
                
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
                LoadEmployees(callFrom);
                LoadPaymentedType(callFrom);
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
                LoadEmployees(callFrom);
                LoadPaymentedType(callFrom);
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
                if (slkEmployees.EditValue == null || slkEmployees.EditValue.ToString() =="")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Nhân viên thu.");
                    return;
                }

                if (lkPaymentedType.EditValue == null || lkPaymentedType.EditValue.ToString() == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Loại thanh toán.");
                    return;
                }

                string _PaymentBy = "";
                if (int.Parse(slkEmployees.EditValue.ToString()) > 0)
                    _PaymentBy = slkEmployees.EditValue.ToString();

                string vPaymentType = "";
                string[] vArrType = lkPaymentedType.EditValue.ToString().Split(',');

                foreach (string type in vArrType)
                    vPaymentType = vPaymentType + "'" + type.Trim() + "',";

                vPaymentType= vPaymentType.Substring(0, vPaymentType.Length - 1);

                DataTable dtOrder = new DataTable();
                busReport bReport = new busReport();
                string result = bReport.Revenue_Employee(callFrom, ref dtOrder, _PaymentBy, dateFrom.DateTime, dateTo.DateTime, vPaymentType);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_Employee:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_Employee");
                    return;
                }

                if (chkDetail.Checked || chkExportActual.Checked)
                {
                    #region Visible columns

                    if (chkDetail.Checked && chkExportActual.Checked) 
                    {
                        gvDetail_colMenuID.Visible = true;
                        gvDetail_colMenuID.VisibleIndex = 0;

                        gvDetail_colSizeID.Visible = true;
                        gvDetail_colSizeID.VisibleIndex = 1;

                        gvDetail_colQuantity.Visible = true;
                        gvDetail_colQuantity.VisibleIndex = 2;

                        gvDetail_colPrice.Visible = true;
                        gvDetail_colPrice.VisibleIndex = 3;

                        gvDetail_colTotal.Visible = true;
                        gvDetail_colTotal.VisibleIndex = 4;

                        gvDetail_colMaterialsID.Visible = true;
                        gvDetail_colMaterialsID.VisibleIndex = 5;

                        gvDetail_colQuantitySubtract.Visible = true;
                        gvDetail_colQuantitySubtract.VisibleIndex = 6;

                        gvDetail_colUnitID.Visible = true;
                        gvDetail_colUnitID.VisibleIndex = 7;
                        
                    }
                    else if (chkDetail.Checked && !chkExportActual.Checked)
                    {
                        gvDetail_colMenuID.Visible = true;
                        gvDetail_colMenuID.VisibleIndex = 0;

                        gvDetail_colSizeID.Visible = true;
                        gvDetail_colSizeID.VisibleIndex = 1;

                        gvDetail_colQuantity.Visible = true;
                        gvDetail_colQuantity.VisibleIndex = 2;

                        gvDetail_colPrice.Visible = true;
                        gvDetail_colPrice.VisibleIndex = 3;

                        gvDetail_colTotal.Visible = true;
                        gvDetail_colTotal.VisibleIndex = 4;

                        gvDetail_colMaterialsID.Visible = false;
                        gvDetail_colQuantitySubtract.Visible = false;

                        gvDetail_colUnitID.Visible = true;
                        gvDetail_colUnitID.VisibleIndex = 5;
                    }
                    else if (!chkDetail.Checked && chkExportActual.Checked)
                    {
                        gvDetail_colMenuID.Visible = false;
                        gvDetail_colSizeID.Visible = false;
                        gvDetail_colQuantity.Visible = false;
                        gvDetail_colPrice.Visible = false;
                        gvDetail_colTotal.Visible = false;

                        gvDetail_colMaterialsID.Visible = true;
                        gvDetail_colMaterialsID.VisibleIndex = 0;

                        gvDetail_colQuantitySubtract.Visible = true;
                        gvDetail_colQuantitySubtract.VisibleIndex = 1;

                        gvDetail_colUnitID.Visible = true;
                        gvDetail_colUnitID.VisibleIndex = 2;
                    }

                    #endregion

                    dtOrder.TableName = "Main";

                    DataTable dtOrderDetail = new DataTable();

                    if (chkDetail.Checked)
                    {
                        result = bReport.Revenue_Employee_Detail(callFrom, ref dtOrderDetail, _PaymentBy, dateFrom.DateTime, dateTo.DateTime, vPaymentType);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_Employee_Detail:\n" + result);
                            Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_Employee_Detail");
                            return;
                        }
                    }

                    if (chkExportActual.Checked)
                    {
                        DataTable vdtActual = new DataTable();
                        result = bReport.Revenue_Employee_ActualExport(callFrom, ref vdtActual, _PaymentBy, dateFrom.DateTime, dateTo.DateTime, vPaymentType);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Revenue_Employee_Detail:\n" + result);
                            Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Revenue_Employee_Detail");
                            return;
                        }

                        if (chkDetail.Checked)
                        {
                            dtOrderDetail.Columns.Add("TypeData", typeof(string));
                            dtOrderDetail.Columns.Add("MaterialsID", typeof(int));
                            dtOrderDetail.Columns.Add("QuantitySubtract", typeof(decimal));

                            foreach (DataRow dr in dtOrderDetail.Rows)
                                dr["TypeData"] = "Detail";

                            foreach (DataRow dr in vdtActual.Rows)
                            {
                                DataRow drAdd = dtOrderDetail.NewRow();

                                drAdd["OrderID"] = dr["OrderID"];
                                drAdd["MaterialsID"] = dr["MaterialsID"];
                                drAdd["QuantitySubtract"] = dr["QuantitySubtract"];
                                drAdd["UnitID"] = dr["UnitID"];
                                drAdd["TypeData"] = "Actual";

                                dtOrderDetail.Rows.Add(drAdd);
                            }    
                        }
                        else
                        {
                            dtOrderDetail = vdtActual;
                        }
                    }

                    dtOrderDetail.TableName = "Detail";


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtOrder);
                    ds.Tables.Add(dtOrderDetail);

                    //Set up a master-detail relationship between the DataTables 
                    DataColumn keyColumn = ds.Tables["Main"].Columns["ID"];
                    DataColumn foreignKeyColumn = ds.Tables["Detail"].Columns["OrderID"];
                    ds.Relations.Add("Main_Detail", keyColumn, foreignKeyColumn);

                    //Bind the grid control to the data source 
                    gcData.DataSource = ds.Tables["Main"];
                    gcData.ForceInitialize();

                    bgvData.Columns["ID"].VisibleIndex = -1;

                    gcData.LevelTree.Nodes.Add("Main_Detail", gvDetail);
                    gvDetail.Columns["OrderID"].VisibleIndex = -1;

                    gvDetail.ViewCaption = "Order";
                }
                else
                {
                    gcData.DataSource = dtOrder;
                }

                chkExpand.Checked = true;
                chkExpand_CheckedChanged(null, null);

                if (dtOrder == null || dtOrder.Rows.Count == 0)
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

        private void slkEmployees_EditValueChanged(object sender, EventArgs e)
        {
            gcData.DataSource = null;
        }

        public void Print(string CallBy, bool IsPrint)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (IsPrint)
                    gcData.PrintDialog();
                else
                    gcData.ShowPrintPreview();
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
                    xtraSaveFileDialog1.FileName = "BaoCaoDoanhThuTheoNhanVien_" + dateFrom.DateTime.ToString("dd_MM_yyyy");
                else
                    xtraSaveFileDialog1.FileName = "BaoCaoDoanhThuTheoNhanVien_" + dateFrom.DateTime.ToString("dd_MM_yyyy") + "_" + dateTo.DateTime.ToString("dd_MM_yyyy");

                if (Type.ToUpper() == "PDF")
                    xtraSaveFileDialog1.Filter= "Pdf files (*.pdf)|*.pdf";
                else if (Type.ToUpper() == "DOCX")
                    xtraSaveFileDialog1.Filter= "Word files (*.docx)|*.docx";
                else if (Type.ToUpper() == "XLSX")
                    xtraSaveFileDialog1.Filter= "Excel files (*.xlsx)|*.xlsx";

                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Type.ToUpper() == "PDF")
                        gcData.ExportToPdf(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "DOCX")
                        gcData.ExportToDocx(xtraSaveFileDialog1.FileName);
                    else if (Type.ToUpper() == "XLSX")
                        gcData.ExportToXlsx(xtraSaveFileDialog1.FileName);
                }    
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void bgvData_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.RightMargin = 5;
        }

        private void lkPaymentedType_EditValueChanged(object sender, EventArgs e)
        {
            gcData.DataSource = null;
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
            {
                bgvData.CollapseAllDetails();
                bgvData.CollapseAllGroups();
            }
            else
            {
                bgvData.ExpandAllGroups();
            }
        }

        private void chkDetail_CheckedChanged(object sender, EventArgs e)
        {
            gcData.DataSource = null;
        }

        private void gvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void chkExportActual_CheckedChanged(object sender, EventArgs e)
        {
            gcData.DataSource = null;
        }
    }
}