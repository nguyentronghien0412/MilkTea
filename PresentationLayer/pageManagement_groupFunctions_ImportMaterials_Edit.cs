using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
    public partial class pageManagement_groupFunctions_ImportMaterials_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vImportFromSuppliersID = "";
        public string vType = "";
        public DataTable vdtImport = null;
        public DataTable vdtWarehouse = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busImportFromSuppliers bImport = new BusinessLogicLayer.busImportFromSuppliers();

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

        public pageManagement_groupFunctions_ImportMaterials_Edit()
        {
            InitializeComponent();
        }

        private void pageManagement_groupFunctions_ImportMaterials_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vImportFromSuppliersID == "")
                    vImportFromSuppliersID = "0";

                Populate_LookUpEdit(ImportFromSuppliers_SuppliersID, "Suppliers");
                Populate_LookUpEdit(ImportFromSuppliers_StatusID, "ImportFromSuppliersStatus");
                Populate_LookUpEdit(gvWarehouse_colStatusID_lk, "ImportFromSuppliersStatus");
                Populate_LookUpEdit(gvWarehouse_colMaterialsID_slk_View_colMaterialsGroupID_lk, "MaterialsGroup");
                Populate_LookUpEdit(gvWarehouse_colMaterialsID_slk_View_colUnitID_lk, "Unit");

                DataTable dtMaterials = new DataTable();
                string result = bImport.GetMaterials(callFrom, ref dtMaterials);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                Utilities.Multi.Populate_LookUpEdit(gvWarehouse_colMaterialsID_slk, dtMaterials, "ID", "Name");
                
                #region ImportFromSuppliers_ImportedBy

                DataTable dtEmployees = new DataTable();
                result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ", new string[] { "StatusID" }, new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString() }, "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }

                ImportFromSuppliers_ImportedBy.Properties.ValueMember = "ID";
                ImportFromSuppliers_ImportedBy.Properties.DisplayMember = "FullName";
                ImportFromSuppliers_ImportedBy.Properties.DataSource = dtEmployees;

                #endregion

                vdtImport = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtImport, "ImportFromSuppliers", new string[] { "ID" }, new string[] { vImportFromSuppliersID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition ImportFromSuppliers:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition ImportFromSuppliers");
                }

                vdtWarehouse = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref vdtWarehouse, "Warehouse", new string[] { "ImportFromSuppliersID" }, new string[] { vImportFromSuppliersID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Warehouse:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Warehouse");
                    return;
                }

                vdtWarehouse.Columns.Add("QuantityStyle", typeof(decimal));
                vdtWarehouse.Columns.Add("QuantityImport_UnitMax", typeof(decimal));
                vdtWarehouse.Columns.Add("PriceImportOld", typeof(decimal));

                if (int.Parse(vImportFromSuppliersID) == 0)
                {
                    this.Text = "Nhập hàng - Tạo mới";

                    DataRow _drImport = vdtImport.NewRow();
                    _drImport["SuppliersID"] = (int)Utilities.CategoriesEnum.Suppliers.Mua_lẻ;
                    _drImport["ImportedBy"] = int.Parse(Utilities.Parameters.UserLogin.EmployeesID);
                    _drImport["ImportedDate"] = DateTime.Now;
                    _drImport["StatusID"] = (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Chờ_duyệt;
                    vdtImport.Rows.Add(_drImport);

                    gvWarehouse_colStatusID.Visible = false;
                    gvWarehouse_colQuantityCurrent.Visible = false;
                }
                else
                {
                    this.Text = "Nhập hàng - Cập nhật";

                    gvWarehouse_colStatusID.Visible = true;
                    gvWarehouse_colQuantityCurrent.Visible = true;

                    DataTable dtMaterialsTemp = dtMaterials.Copy();
                    DataView dv = dtMaterialsTemp.DefaultView;
                    foreach (DataRow dr in vdtWarehouse.Rows)
                    {
                        dv.RowFilter = "ID = " + dr["MaterialsID"].ToString();
                        if (dv.Count == 1)
                        {
                            dr["QuantityStyle"] = dv[0].Row["StyleQuantity"];

                            decimal QuantityStyle = 0, QuantityImport = 0;

                            if (dr["QuantityStyle"].ToString() != "")
                                QuantityStyle = decimal.Parse(dr["QuantityStyle"].ToString());

                            if (dr["QuantityImport"].ToString() != "")
                                QuantityImport = decimal.Parse(dr["QuantityImport"].ToString());

                            if (QuantityStyle > 0)
                                dr["QuantityImport_UnitMax"] = QuantityImport / QuantityStyle;
                            else
                                dr["QuantityImport_UnitMax"] = 0;

                            DataTable dtPriceNearest = new DataTable();
                            result = bImport.GetPriceNearest(callFrom, ref dtPriceNearest, dr["MaterialsID"].ToString(), vImportFromSuppliersID);
                            if (result != Utilities.Parameters.ResultMessage)
                            {
                                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetPriceNearest:\n" + result);
                                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetPriceNearest");
                            }
                            else
                            {
                                if (dtPriceNearest != null && dtPriceNearest.Rows.Count > 0)
                                    dr["PriceImportOld"] = dtPriceNearest.Rows[0]["PriceImport"];
                            }
                        }
                    }
                }

                Utilities.Multi.AssignData_RowToForm(vdtImport.Rows[0], this, callFrom);
                gcWarehouse.DataSource = vdtWarehouse;

                if (vType == "VIEW")
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    gvWarehouse.OptionsBehavior.Editable = false;
                    gvWarehouse.OptionsBehavior.ReadOnly = true;
                    gvWarehouse.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    ImportFromSuppliers_SuppliersID.ReadOnly = true;
                    ImportFromSuppliers_BillNo.ReadOnly = true;
                    ImportFromSuppliers_BillDate.ReadOnly = true;
                    ImportFromSuppliers_ImportedBy.ReadOnly = true;
                    ImportFromSuppliers_ImportedDate.ReadOnly = true;
                    ImportFromSuppliers_Note.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ImportFromSuppliers_SuppliersID_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void ImportFromSuppliers_ImportedBy_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (vType != "VIEW")
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa hủy thao tác này?") != DialogResult.Yes)
                    return;

            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                if (gvWarehouse.RowCount == 0)
                    return "Vui lòng nhập nguyên liệu.";

                for (int i = 0; i < gvWarehouse.RowCount; i++)
                {
                    if (gvWarehouse.GetRowCellValue(i,gvWarehouse_colMaterialsID) == null || gvWarehouse.GetRowCellValue(i, gvWarehouse_colMaterialsID).ToString() == "")
                    {
                        gvWarehouse.SelectRow(i);
                        gvWarehouse.FocusedRowHandle = i;
                        gvWarehouse.FocusedColumn = gvWarehouse_colMaterialsID;
                        return "Dữ liệu chưa hợp lệ tại dòng thứ " + (i + 1) + ".\nVui lòng kiểm tra lại danh sách nguyên liệu.";
                    }
                    if (gvWarehouse.GetRowCellValue(i, gvWarehouse_colQuantityImport) == null || gvWarehouse.GetRowCellValue(i, gvWarehouse_colQuantityImport).ToString() == "")
                    {
                        gvWarehouse.SelectRow(i);
                        gvWarehouse.FocusedRowHandle = i;
                        gvWarehouse.FocusedColumn = gvWarehouse_colQuantityImport;
                        return "Vui lòng nhập Số lượng tại dòng thứ " + (i + 1);
                    }
                    if (gvWarehouse.GetRowCellValue(i, gvWarehouse_colPriceImport) == null || gvWarehouse.GetRowCellValue(i, gvWarehouse_colPriceImport).ToString() == "")
                    {
                        gvWarehouse.SelectRow(i);
                        gvWarehouse.FocusedRowHandle = i;
                        gvWarehouse.FocusedColumn = gvWarehouse_colPriceImport;
                        return "Vui lòng nhập Đơn giá tại dòng thứ " + (i + 1);
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(vdtImport.Rows[0], this, callFrom);
                vdtWarehouse.AcceptChanges();

                string result = "";
                if (int.Parse(vImportFromSuppliersID) == 0)
                    result = bImport.Insert(callFrom, ref vdtImport, ref vdtWarehouse);
                else
                    result = bImport.Update(callFrom, vdtImport, vdtWarehouse);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vImportFromSuppliersID) == 0)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Update");
                    }

                    return;
                }
                else
                {
                    vImportFromSuppliersID = vdtImport.Rows[0]["ID"].ToString();
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

        private void gvWarehouse_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvWarehouse_colMaterialsID_slk_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvWarehouse_txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            const char key1 = (char)44;
            const char key2 = (char)46;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != key1 && e.KeyChar != key2;
        }

        private void gvWarehouse_txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            const char key1 = (char)44;
            const char key2 = (char)46;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != key1 && e.KeyChar != key2;
        }

        private void gvWarehouse_colMaterialsID_slk_Popup(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit slk = (DevExpress.XtraEditors.SearchLookUpEdit)sender;
            slk.Properties.View.ExpandAllGroups();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa '"+ gvWarehouse.GetFocusedRowCellDisplayText(gvWarehouse_colMaterialsID).ToString() + "'?") != DialogResult.Yes)
                    return;

                gvWarehouse.DeleteRow(gvWarehouse.FocusedRowHandle);
                gvWarehouse.RefreshData();
                vdtWarehouse.AcceptChanges();

                if (gvWarehouse.RowCount == 0)
                    btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvWarehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvWarehouse.FocusedRowHandle < 0)
                {
                    gvWarehouse_colQuantityStyle.Caption = "Quy cách";
                    gvWarehouse_colQuantityImport_UnitMax.Caption = "SL thùng nhập";
                    gvWarehouse_colQuantityImport.Caption = "Số lượng nhập";
                    btnDelete.Enabled = false;
                    return;
                }

                DataRowView dr = (DataRowView)gvWarehouse_colMaterialsID_slk.GetRowByKeyValue(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colMaterialsID));
                if (dr == null)
                {
                    gvWarehouse_colQuantityStyle.Caption = "Quy cách";
                    gvWarehouse_colQuantityImport_UnitMax.Caption = "SL thùng nhập";
                    gvWarehouse_colQuantityImport.Caption = "Số lượng nhập";
                    btnDelete.Enabled = false;
                    return;
                }

                gvWarehouse_colQuantityStyle.Caption = dr["UnitID_Name"].ToString() + "/" + dr["UnitID_Max_Name"].ToString();
                gvWarehouse_colQuantityImport_UnitMax.Caption = "SL " + dr["UnitID_Max_Name"].ToString() + " nhập";
                gvWarehouse_colQuantityImport.Caption = "SL " + dr["UnitID_Name"].ToString() + " nhập";

                btnDelete.Enabled = false;
                if (int.Parse(ImportFromSuppliers_StatusID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Chờ_duyệt)
                    if (vType != "VIEW")
                        btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvWarehouse_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (ImportFromSuppliers_ImportedDate.Text == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập 'Ngày nhập'.");
                    return;
                }

                if (gvWarehouse.FocusedColumn == gvWarehouse_colMaterialsID)
                {
                    if (e.Value == null || e.Value.ToString() == "")
                        return;

                    DataRowView dr = (DataRowView)gvWarehouse_colMaterialsID_slk.GetRowByKeyValue(e.Value);
                    if (dr["StyleQuantity"] == null || dr["StyleQuantity"].ToString() == "" || dr["StyleQuantity"].ToString() == "0")
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Nguyên liệu này chưa có quy cách.");
                        e.Valid = false;
                    }

                    gvWarehouse.FocusedColumn = gvWarehouse_colQuantityCurrent;
                    gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityStyle, dr["StyleQuantity"]);
                    gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colStatusID, (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Chờ_duyệt);

                    DataTable dtPriceNearest = new DataTable();

                    string result = "";
                    if (int.Parse(vImportFromSuppliersID) == 0)
                        result = bImport.GetPriceNearest(callFrom, ref dtPriceNearest, e.Value.ToString());
                    else
                        result = bImport.GetPriceNearest(callFrom, ref dtPriceNearest, e.Value.ToString(), vImportFromSuppliersID);
                    
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetPriceNearest:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetPriceNearest");
                    }

                    if (dtPriceNearest != null && dtPriceNearest.Rows.Count > 0)
                        gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colPriceImportOld, dtPriceNearest.Rows[0]["PriceImport"]);
                    else
                        gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colPriceImportOld, DBNull.Value);

                    gvWarehouse.FocusedColumn = gvWarehouse_colMaterialsID;
                }
                else if (gvWarehouse.FocusedColumn == gvWarehouse_colQuantityStyle)
                {
                    if (e.Value == null || e.Value.ToString() == "" || e.Value.ToString() == "0")
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Nguyên liệu này chưa có quy cách.");
                        e.Valid = false;
                    }
                }
                else if (gvWarehouse.FocusedColumn == gvWarehouse_colAmountTotal)
                {
                    if (e.Value == null || e.Value.ToString() == "" || e.Value.ToString() == "0")
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập số tiền.");
                        e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void CalcAmount_ByPriceImport()
        {
            decimal _Qty = 0, _Price = 0;

            if (gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityImport) != null && gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityImport).ToString() != "")
                _Qty = decimal.Parse(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityImport).ToString());

            if (gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport) != null && gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport).ToString() != "")
                _Price = decimal.Parse(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport).ToString());

            gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colAmountTotal, _Price * _Qty);
        }

        private void gvWarehouse_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvWarehouse.FocusedColumn == gvWarehouse_colQuantityStyle ||
                    gvWarehouse.FocusedColumn == gvWarehouse_colQuantityImport_UnitMax ||
                    gvWarehouse.FocusedColumn == gvWarehouse_colQuantityImport ||
                    gvWarehouse.FocusedColumn == gvWarehouse_colPriceImport ||
                    gvWarehouse.FocusedColumn == gvWarehouse_colAmountTotal)
                {
                    #region

                    GridColumn colCurrent = gvWarehouse.FocusedColumn;
                    gvWarehouse.FocusedColumn = gvWarehouse_colQuantityCurrent;

                    object _colQuantityStyle = gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityStyle);
                    object _colQuantityImport_UnitMax = gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityImport_UnitMax);
                    object _colQuantityImport = gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colQuantityImport);
                    object _colPriceImport = gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport);
                    object _colAmountTotal = gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colAmountTotal);

                    if (colCurrent == gvWarehouse_colQuantityStyle)
                    {
                        #region gvWarehouse_colQuantityStyle

                        decimal _style = 0, _quantityBox = 0, _quantity = 0;

                        if (_colQuantityStyle != null && _colQuantityStyle.ToString() != "")
                            _style = decimal.Parse(_colQuantityStyle.ToString());

                        if (_colQuantityImport_UnitMax != null && _colQuantityImport_UnitMax.ToString() != "")
                            _quantityBox = decimal.Parse(_colQuantityImport_UnitMax.ToString());

                        if (_colQuantityImport != null && _colQuantityImport.ToString() != "")
                            _quantity = decimal.Parse(_colQuantityImport.ToString());

                        if (_quantityBox == 0)
                        {
                            if (_quantity == 0)
                            {
                                gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport_UnitMax, 0);
                                gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport, 0);
                            }
                            else
                            {
                                gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport, _quantity / _style);
                            }
                        }
                        else
                        {
                            gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport, _quantityBox * _style);
                        }

                        CalcAmount_ByPriceImport();

                        #endregion
                    }
                    else if (colCurrent == gvWarehouse_colQuantityImport_UnitMax)
                    {
                        #region gvWarehouse_colQuantityImport_UnitMax

                        decimal _style = 0, _quantityBox = 0;

                        if (_colQuantityStyle != null && _colQuantityStyle.ToString() != "")
                            _style = decimal.Parse(_colQuantityStyle.ToString());

                        if (_colQuantityImport_UnitMax != null && _colQuantityImport_UnitMax.ToString() != "")
                            _quantityBox = decimal.Parse(_colQuantityImport_UnitMax.ToString());

                        gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport, _quantityBox * _style);

                        CalcAmount_ByPriceImport();

                        #endregion
                    }
                    else if (colCurrent == gvWarehouse_colQuantityImport)
                    {
                        #region gvWarehouse_colQuantityImport

                        decimal _style = 0, _quantity = 0;

                        if (_colQuantityStyle != null && _colQuantityStyle.ToString() != "")
                            _style = decimal.Parse(_colQuantityStyle.ToString());

                        if (_colQuantityImport != null && _colQuantityImport.ToString() != "")
                            _quantity = decimal.Parse(_colQuantityImport.ToString());

                        gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colQuantityImport_UnitMax, _quantity / _style);
                        CalcAmount_ByPriceImport();

                        #endregion
                    }
                    else if (colCurrent == gvWarehouse_colPriceImport)
                    {
                        CalcAmount_ByPriceImport();
                    }
                    else if (colCurrent == gvWarehouse_colAmountTotal)
                    {
                        #region gvWarehouse_colAmountTotal

                        decimal _quantity = 0;
                        if (_colQuantityImport != null && _colQuantityImport.ToString() != "")
                            _quantity = decimal.Parse(_colQuantityImport.ToString());

                        if (_quantity == 0)
                        {
                            gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colPriceImport, 0);
                        }
                        else
                        {
                            decimal _totalPrice = 0;
                            if (_colAmountTotal != null && _colAmountTotal.ToString() != "")
                                _totalPrice = decimal.Parse(_colAmountTotal.ToString());

                            gvWarehouse.SetRowCellValue(gvWarehouse.FocusedRowHandle, gvWarehouse_colPriceImport, _totalPrice / _quantity);
                        }
                        CalcAmount_ByPriceImport();

                        #endregion
                    }

                    decimal _priceOld = 0, _price = 0;
                    if (gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImportOld) != null && gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImportOld).ToString() != "")
                        _priceOld = decimal.Parse(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImportOld).ToString());

                    if (gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport) != null && gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport).ToString() != "")
                        _price = decimal.Parse(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colPriceImport).ToString());

                    if (_priceOld > 0 && _price > 0 && Math.Round(_priceOld) != Math.Round(_price))
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Đơn giá có thay đổi. Giá cũ: " + _priceOld.ToString("n2") + "\n                                 Giá mới: " + _price.ToString("n2"));

                    gvWarehouse.FocusedColumn = colCurrent;

                    #endregion
                }
                else if (gvWarehouse.FocusedColumn == gvWarehouse_colMaterialsID)
                {
                    DataRowView dr = (DataRowView)gvWarehouse_colMaterialsID_slk.GetRowByKeyValue(gvWarehouse.GetFocusedRowCellValue(gvWarehouse_colMaterialsID));
                    gvWarehouse_colQuantityStyle.Caption = dr["UnitID_Name"].ToString() + "/" + dr["UnitID_Max_Name"].ToString();
                    gvWarehouse_colQuantityImport_UnitMax.Caption = "SL " + dr["UnitID_Max_Name"].ToString() + " nhập";
                    gvWarehouse_colQuantityImport.Caption = "SL " + dr["UnitID_Name"].ToString() + " nhập";
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