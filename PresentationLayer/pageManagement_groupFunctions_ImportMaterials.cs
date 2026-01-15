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
    public partial class pageManagement_groupFunctions_ImportMaterials : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        int selectedID = 0;


        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busImportFromSuppliers bImport = new BusinessLogicLayer.busImportFromSuppliers();

        #region Functions

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtTemp, TableName, "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> " + TableName);
                    this.Close();
                }

                DataView dv = dtTemp.DefaultView;
                dv.Sort = "Name ASC";
                dtTemp = dv.ToTable();

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private void LoadData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime dateFrom = new DateTime(dateImportFrom.DateTime.Year, dateImportFrom.DateTime.Month, dateImportFrom.DateTime.Day, 0, 0, 0);
                DateTime dateTo = new DateTime(dateImportTo.DateTime.Year, dateImportTo.DateTime.Month, dateImportTo.DateTime.Day, 23, 59, 59);

                string from = dateFrom.ToString("yyyy-MM-dd HH:mm:ss");
                string to = dateTo.ToString("yyyy-MM-dd HH:mm:ss");

                DataTable dtImportFromSuppliers = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtImportFromSuppliers, " ImportFromSuppliers",
                                                        new string[] { "ImportedDate" },
                                                        new string[] { "BETWEEN" },
                                                        new string[] { "'" + from + "' AND '" + to + "'" },
                                                        "ImportedDate ASC"
                                                        );
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition ImportFromSuppliers:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition ImportFromSuppliers");
                }

                dtImportFromSuppliers.TableName = "Main";

                DataTable dtWarehouse = new DataTable();
                result = bImport.GetWarehouse(callFrom, ref dtWarehouse, dateFrom, dateTo);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetWarehouse:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetWarehouse");
                }

                dtWarehouse.TableName = "Detail";

                DataSet ds = new DataSet();
                ds.Tables.Add(dtImportFromSuppliers);
                ds.Tables.Add(dtWarehouse);

                //Set up a master-detail relationship between the DataTables 
                DataColumn keyColumn = ds.Tables["Main"].Columns["ID"];
                DataColumn foreignKeyColumn = ds.Tables["Detail"].Columns["ImportFromSuppliersID"];
                ds.Relations.Add("Main_Detail", keyColumn, foreignKeyColumn);

                //Bind the grid control to the data source 
                gcImportFromSuppliers.DataSource = ds.Tables["Main"];
                gcImportFromSuppliers.ForceInitialize();

                gvImportFromSuppliers.Columns["ID"].VisibleIndex = -1;

                gcImportFromSuppliers.LevelTree.Nodes.Add("Main_Detail", gvImportFromSuppliersDetail);
                gvImportFromSuppliersDetail.Columns["ImportFromSuppliersID"].VisibleIndex = -1;

                gvImportFromSuppliersDetail.ViewCaption = "Category Products";

                chkExpand.Checked = false;
                chkExpand_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void New(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_ImportMaterials_Edit frmEdit = new pageManagement_groupFunctions_ImportMaterials_Edit();
                frmEdit.vImportFromSuppliersID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit.vImportFromSuppliersID);
                    pageManagement_groupFunctions_ImportMaterials_Load(null, null);
                }
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
                if (gvImportFromSuppliers.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn đơn hàng cần cập nhật.", 5000);
                    return;
                }

                selectedID = int.Parse(gvImportFromSuppliers.GetFocusedRowCellValue(gvImportFromSuppliersDetail_colID).ToString());

                pageManagement_groupFunctions_ImportMaterials_Edit frmEdit = new pageManagement_groupFunctions_ImportMaterials_Edit();
                frmEdit.vImportFromSuppliersID = selectedID.ToString();
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit.vImportFromSuppliersID);
                    pageManagement_groupFunctions_ImportMaterials_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        public pageManagement_groupFunctions_ImportMaterials()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex.");
                this.Close();
            }
        }

        private void pageManagement_groupFunctions_ImportMaterials_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dateImportFrom.DateTime = DateTime.Now;
                dateImportTo.DateTime = DateTime.Now;

                Populate_LookUpEdit(gvImportFromSuppliers_colSuppliersID_lk, "Suppliers");
                Populate_LookUpEdit(gvImportFromSuppliers_colStatusID_lk, "ImportFromSuppliersStatus");
                Populate_LookUpEdit(gvImportFromSuppliersDetail_colMaterialsID_lk, "Materials");
                Populate_LookUpEdit(gvImportFromSuppliersDetail_colUnitID_lk, "Unit");
                
                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ", new string[] { "StatusID" }, new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString() }, "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }

                Utilities.Multi.Populate_LookUpEdit(gvImportFromSuppliers_colImportedBy_lk, dtEmployees, "ID", "FullName");

                LoadData(callFrom);

                chkExpand.Checked = false;
                chkExpand_CheckedChanged(null, null);
                if (selectedID > 0)
                    for (int i = 0; i < gvImportFromSuppliers.RowCount; i++)
                    {
                        if (gvImportFromSuppliers.GetRowCellValue(i, gvImportFromSuppliersDetail_colID) != null && gvImportFromSuppliers.GetRowCellValue(i, gvImportFromSuppliersDetail_colID).ToString() == selectedID.ToString())
                        {
                            gvImportFromSuppliers.SelectRow(i);
                            gvImportFromSuppliers.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (gvImportFromSuppliers.RowCount == 0)
                    frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
                gvImportFromSuppliers_RowClick(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
            }
        }

        private void gvImportFromSuppliers_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvImportFromSuppliersDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvImportFromSuppliers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnApproved.Enabled = false;
                if (gvImportFromSuppliers.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
                    return;
                }

                string statusID = gvImportFromSuppliers.GetFocusedRowCellValue(gvImportFromSuppliers_colStatusID).ToString();
                if (int.Parse(statusID) == (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Chờ_duyệt)
                {
                    if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_ImportMaterials", Utilities.Parameters.Permission_APPROVED))
                        btnApproved.Enabled = true;

                    frmMain.EnableAction(true, false, true, false, false, false, false, false, false, arrIndex);
                }
                else
                    frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvImportFromSuppliers_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gvImportFromSuppliers_FocusedRowChanged(null, null);
        }

        private void pageManagement_groupFunctions_ImportMaterials_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageManagement_groupFunctions_ImportMaterials_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
            {
                for (int i = 0; i < gvImportFromSuppliers.RowCount; i++)
                    gvImportFromSuppliers.CollapseMasterRow(i);
                gvImportFromSuppliers.CollapseAllGroups();
            }
            else
            {
                gvImportFromSuppliers.ExpandAllGroups();
                for (int i = 0; i < gvImportFromSuppliers.RowCount; i++)
                    gvImportFromSuppliers.ExpandMasterRow(i);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                LoadData(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void dateImportFrom_EditValueChanged(object sender, EventArgs e)
        {
            gcImportFromSuppliers.DataSource = null;
        }

        private void dateImportTo_EditValueChanged(object sender, EventArgs e)
        {
            gcImportFromSuppliers.DataSource = null;
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvImportFromSuppliers.FocusedRowHandle < 0)
                {
                    btnApproved.Enabled = false;
                    return;
                }

                string Supplier = gvImportFromSuppliers.GetFocusedRowCellDisplayText(gvImportFromSuppliers_colSuppliersID);
                string BillNo = gvImportFromSuppliers.GetFocusedRowCellDisplayText(gvImportFromSuppliers_colCode);
                if (BillNo !="")
                    Supplier = Supplier + " (" + BillNo + ")";

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn duyệt đơn hàng của\n'" + Supplier + @"' ?") != DialogResult.Yes)
                    return;

                string ID = gvImportFromSuppliers.GetFocusedRowCellDisplayText(gvImportFromSuppliers_colID);

                DataTable vdtImportFromSuppliers = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtImportFromSuppliers, "ImportFromSuppliers", new string[] { "ID" }, new string[] { ID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition ImportFromSuppliers:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition ImportFromSuppliers");
                    return;
                }

                vdtImportFromSuppliers.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho;
                vdtImportFromSuppliers.Rows[0]["ApprovedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                vdtImportFromSuppliers.Rows[0]["ApprovedDate"] = DateTime.Now;

                DataTable vdtWarehouse = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref vdtWarehouse, "Warehouse", new string[] { "ImportFromSuppliersID" }, new string[] { ID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Warehouse:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Warehouse");
                    return;
                }

                foreach (DataRow dr in vdtWarehouse.Rows)
                    dr["StatusID"] = (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho;

                string result = bImport.Approved(callFrom, vdtImportFromSuppliers, vdtWarehouse);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> UpdateByID:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> UpdateByID");
                    return;
                }
                else
                {
                    Utilities.Functions.MessageBoxOK("N", Utilities.Parameters.Result, "Nguyên liệu đã được nhập kho.");
                    selectedID = int.Parse(ID);
                    pageManagement_groupFunctions_ImportMaterials_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gcImportFromSuppliers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvImportFromSuppliers.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, false, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn đơn hàng cần xem.", 5000);
                    return;
                }

                selectedID = int.Parse(gvImportFromSuppliers.GetFocusedRowCellValue(gvImportFromSuppliersDetail_colID).ToString());

                pageManagement_groupFunctions_ImportMaterials_Edit frmEdit = new pageManagement_groupFunctions_ImportMaterials_Edit();
                frmEdit.vImportFromSuppliersID = selectedID.ToString();
                frmEdit.vType = "VIEW";
                frmEdit.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}