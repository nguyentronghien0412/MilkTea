using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_TableAdd : DevExpress.XtraEditors.XtraForm
    {
        public string vOrderID = null;
        public DataTable vdtDinnerTable = null;

        public DataTable vdtOrder = null;
        public DataTable vdtOrderDetail = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();
        BusinessLogicLayer.busPriceList bPriceList = new BusinessLogicLayer.busPriceList();
        BusinessLogicLayer.busMenu bMenu = new BusinessLogicLayer.busMenu();

        #region Functions

        private void Populate_LookUpEdit(object lk, string TableName, bool AddEmptyRow)
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

                if (AddEmptyRow)
                {
                    if (dtTemp.Rows.Count >0)
                    {
                        DataRow drAdd = dtTemp.NewRow();
                        dtTemp.Rows.InsertAt(drAdd, 0);
                    }
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

        private void CalcTotal(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                decimal _Quantity = 0, _Price = 0, _Total = 0;

                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity) != null &&
                    gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString() != "")
                    _Quantity = decimal.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString());

                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colPrice) != null &&
                   gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colPrice).ToString() != "")
                    _Price = decimal.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colPrice).ToString());

                _Total = _Quantity * _Price;

                gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colTotal, _Total);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void CalcTotal_All(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                for (int i = 0; i < gvOrderDetail.RowCount; i++)
                {
                    if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID) != null && 
                        gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID).ToString() != "")
                    {
                        decimal _Quantity = 0, _Price = 0, _Total = 0;

                        if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colQuantity) != null &&
                            gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colQuantity).ToString() != "")
                            _Quantity = decimal.Parse(gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colQuantity).ToString());

                        if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colPrice) != null &&
                           gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colPrice).ToString() != "")
                            _Price = decimal.Parse(gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colPrice).ToString());

                        _Total = _Quantity * _Price;

                        gvOrderDetail.SetRowCellValue(i, gvOrderDetail_colTotal, _Total);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void SetGridview(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colMenuGroupID) == null)
                    return;

                if (gvOrderDetail.FocusedColumn == gvOrderDetail_colKindOfHotpot1ID || gvOrderDetail.FocusedColumn == gvOrderDetail_colKindOfHotpot2ID)
                {
                    int MenuGroup = int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colMenuGroupID).ToString());
                    if (MenuGroup == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                    {
                        gvOrderDetail.OptionsBehavior.Editable = true;
                        gvOrderDetail.OptionsBehavior.ReadOnly = false;
                    }
                    else
                    {
                        gvOrderDetail.OptionsBehavior.Editable = false;
                        gvOrderDetail.OptionsBehavior.ReadOnly = true;
                    }
                }
                else
                {
                    gvOrderDetail.OptionsBehavior.Editable = true;
                    gvOrderDetail.OptionsBehavior.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        public pageManagement_groupFunctions_TableAndDish_TableAdd()
        {
            InitializeComponent();

            vdtOrderDetail = new DataTable();
            vdtOrderDetail.Columns.Add("MenuID", typeof(int));
            vdtOrderDetail.Columns.Add("SizeID", typeof(int));
            vdtOrderDetail.Columns.Add("Quantity", typeof(int));
            vdtOrderDetail.Columns.Add("Price", typeof(decimal));
            vdtOrderDetail.Columns.Add("PriceListID", typeof(int));
            vdtOrderDetail.Columns.Add("MenuGroupID", typeof(int));
            vdtOrderDetail.Columns.Add("UnitID", typeof(int));
            vdtOrderDetail.Columns.Add("Total", typeof(decimal));
            vdtOrderDetail.Columns.Add("Note", typeof(string));
            vdtOrderDetail.Columns.Add("KindOfHotpot1ID", typeof(int));
            vdtOrderDetail.Columns.Add("KindOfHotpot2ID", typeof(int));

            gcOrderDetail.DataSource = vdtOrderDetail;
        }

        private void pageManagement_groupFunctions_TableAndDish_TableAdd_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                Populate_LookUpEdit(Order_OrderBy_slk_colGenderID_rlk, "Gender", false);
                Populate_LookUpEdit(Order_OrderBy_slk_colPositionID_rlk, "Position", false);
                Populate_LookUpEdit(gvOrderDetail_colMenuID_rslk_view_colUnitID_rlk, "Unit", false);
                Populate_LookUpEdit(gvOrderDetail_colUnitID_rlk, "Unit", false);
                Populate_LookUpEdit(gvOrderDetail_colMenuID_rslk_view_colMenuGroupID_rlk, "MenuGroup", false);
                Populate_LookUpEdit(gvOrderDetail_colMenuGroupID_rlk, "MenuGroup", false);
                Populate_LookUpEdit(gvOrderDetail_colKindOfHotpot1ID_lke, "KindOfHotpot", true);
                Populate_LookUpEdit(gvOrderDetail_colSizeID_lk, "Size", false);
                
                #region Order_DinnerTableID

                vdtDinnerTable = new DataTable();
                string _Result = bOrder.GetDinnerTable(callFrom, ref vdtDinnerTable, true);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> DinnerTable_GetIsEmpty:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> DinnerTable_GetIsEmpty");
                }

                Orders_DinnerTableID.Properties.ValueMember = "ID";
                Orders_DinnerTableID.Properties.DisplayMember = "Name";
                Orders_DinnerTableID.Properties.DataSource = vdtDinnerTable;

                if (vdtDinnerTable.Rows.Count > 0)
                    Orders_DinnerTableID.EditValue = vdtDinnerTable.Rows[0]["ID"];

                #endregion

                Orders_OrderDate.DateTime = DateTime.Now;

                #region Order_OrderBy

                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ",
                                                        new string[] { "StatusID", "ID" },
                                                        new string[] { "=", "<>" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(), ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() },
                                                        "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }

                Orders_OrderBy.Properties.ValueMember = "ID";
                Orders_OrderBy.Properties.DisplayMember = "FullName";
                Orders_OrderBy.Properties.DataSource = dtEmployees;
                Orders_OrderBy.EditValue = int.Parse(Parameters.UserLogin.EmployeesID);

                #endregion

                #region gvOrderDetail_colMenuID_rslk

                DataTable dtMenu = new DataTable();
                result = bMenu.GetAll_IsActive(callFrom, ref dtMenu);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Menu GetAll_IsActive:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Menu GetAll_IsActive");
                }

                gvOrderDetail_colMenuID_rslk.ValueMember = "ID";
                gvOrderDetail_colMenuID_rslk.DisplayMember = "Name";
                gvOrderDetail_colMenuID_rslk.DataSource = dtMenu;

                #endregion

                #region Load group menu

                DataTable dtGroupMenu = new DataTable();
                result = bMenu.GetListGroups(callFrom, ref dtGroupMenu);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetListGroups:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetListGroups");
                }

                gcListMenuGroups.DataSource = dtGroupMenu;

                #endregion

                vdtOrder = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref vdtOrder, "Orders", new string[] { "ID" }, new string[] { "0" }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                DataRow _drOrder = vdtOrder.NewRow();
                vdtOrder.Rows.Add(_drOrder);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Order_DinnerTableID_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Order_OrderBy_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvOrderDetail_colMenuID_rslk_view_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvOrderDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetail.FocusedColumn == gvOrderDetail_colMenuID)
                    ValidatingEditor_MenuID_SizeID(e, true);
                else if (gvOrderDetail.FocusedColumn == gvOrderDetail_colSizeID)
                    ValidatingEditor_MenuID_SizeID(e, false);
                else if (gvOrderDetail.FocusedColumn == gvOrderDetail_colQuantity)
                {
                    if (e.Value == null || e.Value.ToString() == "")
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Error, "Vui lòng nhập số lượng");
                        e.Valid = false;
                        return;
                    }

                    if (e.Value.ToString() == "0")
                        gvOrderDetail_colDecrease_btn_ButtonClick(null, null);
                }

                CalcTotal(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ValidatingEditor_MenuID_SizeID(DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e, bool IsMenuID)
        {
            if (e.Value == null || e.Value.ToString() == "")
                return;

            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            string vMenuID = "";
            string vSizeID = "";

            if (IsMenuID)
            {
                vMenuID = e.Value.ToString();

                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colSizeID) != null &&
                    gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colSizeID).ToString() != "")
                    vSizeID = gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colSizeID).ToString();
            }
            else
            {
                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colMenuID) != null &&
                    gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colMenuID).ToString() != "")
                    vMenuID = gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colMenuID).ToString();

                vSizeID = e.Value.ToString();
            }

            for (int i = 0; i < gvOrderDetail.RowCount; i++)
            {
                if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID) != null &&
                    gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID).ToString() != "" &&
                    gvOrderDetail.FocusedRowHandle != i)
                {
                    if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID).ToString() == vMenuID &&
                        gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colSizeID).ToString() == vSizeID)
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Kích cỡ này đã được nhập.\nVui lòng điều chỉnh số lượng trong danh sách bên dưới.");
                        e.Valid = false;
                        return;
                    }
                }
            }

            DataTable dtMenu = new DataTable();
            string result = bGeneral.GetByCondition(vCallFrom, ref dtMenu, "Menu ", new string[] { "ID" }, new string[] { vMenuID }, null);
            if (result != Utilities.Parameters.ResultMessage)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + " -> Menu -> GetByCondition:\n" + result);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + vCallFrom + " -> Menu -> GetByCondition");
                e.Valid = false;
                return;
            }

            int MenuGroupID = int.Parse(dtMenu.Rows[0]["MenuGroupID"].ToString());
            int TasteQTy = 0;
            if (MenuGroupID == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                TasteQTy = int.Parse(dtMenu.Rows[0]["TasteQTy"].ToString());

            gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colUnitID, dtMenu.Rows[0]["UnitID"]);
            gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colMenuGroupID, dtMenu.Rows[0]["MenuGroupID"]);
            gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colQuantity, 1);

            dtMenu = new DataTable();
            result = bPriceList.IsUsing_GetMenu(vCallFrom, ref dtMenu, vMenuID, vSizeID);
            if (result != Utilities.Parameters.ResultMessage)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + " -> IsUsing_GetMenu:\n" + result);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + vCallFrom + " -> IsUsing_GetMenu");
                e.Valid = false;
                return;
            }
            else
            {
                if (dtMenu == null || dtMenu.Rows.Count == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Kích cỡ này chưa có Giá bán !!!");
                    e.Valid = false;
                    return;
                }
                else if (dtMenu.Rows.Count > 1)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Giá bán của Kích cỡ này không hợp lệ.\nVì Kích cỡ này có " + dtMenu.Rows.Count + @" giá bán !!!");
                    e.Valid = false;
                    return;
                }
                else
                {
                    gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colPrice, dtMenu.Rows[0]["Price"]);
                    gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colPriceListID, dtMenu.Rows[0]["PriceListID"]);

                }
            }

            if (MenuGroupID == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
            {
                pageManagement_groupFunctions_TableAndDish_KindOfHotpot frmKindOfHotpot = new pageManagement_groupFunctions_TableAndDish_KindOfHotpot();

                frmKindOfHotpot.lstID = new List<int>();

                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID) != null &&
                    gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID).ToString() != "")
                    frmKindOfHotpot.lstID.Add(int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID).ToString()));

                if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot2ID) != null &&
                    gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot2ID).ToString() != "")
                    frmKindOfHotpot.lstID.Add(int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot2ID).ToString()));

                frmKindOfHotpot.vTasteQTy = TasteQTy;
                DialogResult dlg = frmKindOfHotpot.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID, null);
                    gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot2ID, null);

                    if (frmKindOfHotpot.lstID.Count == 1)
                    {
                        gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID, frmKindOfHotpot.lstID[0]);
                    }
                    else if (frmKindOfHotpot.lstID.Count == 2)
                    {
                        gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot1ID, frmKindOfHotpot.lstID[0]);
                        gvOrderDetail.SetFocusedRowCellValue(gvOrderDetail_colKindOfHotpot2ID, frmKindOfHotpot.lstID[1]);
                    }
                }
                else
                {
                    e.Valid = false;
                }
            }
        }

        private void gvOrderDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvOrderDetail_colIncrease_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetail.FocusedColumn == gvOrderDetail_colIncrease)
                {
                    if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity) != null &&
                        gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString() != "")
                    {
                        int _Quantity = int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString());
                        gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colQuantity, _Quantity + 1);
                    }
                    CalcTotal(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_colIncrease_btn_KeyUp(object sender, KeyEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (gvOrderDetail.FocusedColumn == gvOrderDetail_colIncrease)
                    {
                        if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity) != null &&
                            gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString() != "")
                        {
                            int _Quantity = int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString());
                            gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colQuantity, _Quantity + 1);
                        }
                        CalcTotal(callFrom);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_colDecrease_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetail.FocusedColumn == gvOrderDetail_colDecrease || gvOrderDetail.FocusedColumn == gvOrderDetail_colQuantity)
                {
                    if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity) != null &&
                        gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString() != "")
                    {
                        int _Quantity = int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString());
                        if (_Quantity > 0)
                            _Quantity = _Quantity - 1;

                        if (_Quantity == 0)
                        {
                            if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa món này?") == DialogResult.Yes)
                            {
                                gvOrderDetail.DeleteRow(gvOrderDetail.FocusedRowHandle);
                                gvOrderDetail.PostEditor();
                            }
                        }
                        else
                        {
                            gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colQuantity, _Quantity);
                        }
                    }

                    CalcTotal(callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_colDecrease_btn_KeyUp(object sender, KeyEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (gvOrderDetail.FocusedColumn == gvOrderDetail_colDecrease)
                    {
                        if (gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity) != null &&
                            gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString() != "")
                        {
                            int _Quantity = int.Parse(gvOrderDetail.GetFocusedRowCellValue(gvOrderDetail_colQuantity).ToString());
                            _Quantity = _Quantity - 1;

                            if (_Quantity == 0)
                            {
                                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa món này?") == DialogResult.Yes)
                                {
                                    gvOrderDetail.DeleteRow(gvOrderDetail.FocusedRowHandle);
                                    gvOrderDetail.PostEditor();
                                }
                            }
                            else
                            {
                                gvOrderDetail.SetRowCellValue(gvOrderDetail.FocusedRowHandle, gvOrderDetail_colQuantity, _Quantity);
                            }
                        }

                        CalcTotal(callFrom);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void DeleteRowIsEmpty(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                vdtOrderDetail.AcceptChanges();
                for (int i = 0; i < vdtOrderDetail.Rows.Count; i++)
                {
                    if (vdtOrderDetail.Rows[i]["MenuID"] == null ||
                        vdtOrderDetail.Rows[i]["MenuID"].ToString() == "")
                    {
                        vdtOrderDetail.Rows.RemoveAt(i);
                        i = i - 1;
                    }
                }

                gvOrderDetail.PostEditor();
                vdtOrderDetail.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                DataTable dtOrders = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtOrders, "Orders",
                                                        new string[] { "StatusOfOrderID", "DinnerTableID" },
                                                        new string[] { "=", "=" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán).ToString(), Orders_DinnerTableID.EditValue.ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    return result + "\n" + callFrom + " -> GetByCondition";
                }

                if (dtOrders != null && dtOrders.Rows.Count > 0)
                    return "Bàn này đang có khách !!!";
                
                if (vdtOrderDetail == null || vdtOrderDetail.Rows.Count == 0)
                    return "Vui lòng nhập danh sách đặt món !!!";

                foreach (DataRow dr in vdtOrderDetail.Rows)
                {
                    if (dr["MenuID"] == null || dr["MenuID"].ToString() == "")
                        return "Vui lòng nhập Tên món !!!";
                    if (dr["SizeID"] == null || dr["SizeID"].ToString() == "")
                        return "Vui lòng nhập Kích cỡ !!!";
                    if (dr["Price"] == null || dr["Price"].ToString() == "")
                        return "Vui lòng nhập Đơn giá !!!";
                    if (dr["Quantity"] == null || dr["Quantity"].ToString() == "")
                        return "Vui lòng nhập Số lượng !!!";
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
                DeleteRowIsEmpty(callFrom);
                CalcTotal_All(callFrom);

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

                Utilities.Multi.AssignData_FormToRow(vdtOrder.Rows[0], this, callFrom);
                vdtOrder.AcceptChanges();

                gvOrderDetail.PostEditor();
                vdtOrderDetail.AcceptChanges();

                string result = bOrder.Insert(callFrom, ref vdtOrder, ref vdtOrderDetail);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    return;
                }
                else
                {
                    vOrderID = vdtOrder.Rows[0]["ID"].ToString();
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

        private void gvOrderDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                SetGridview(callFrom);
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                SetGridview(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                SetGridview(callFrom);

                CalcTotal(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_RowCountChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Orders_DinnerTableID_Enter(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Orders_OrderDate_Enter(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Orders_OrderBy_Enter(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Orders_Note_Enter(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CalcTotal_All(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvListMenuGroups_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvListMenuGroups_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.RowHandle == gvListMenuGroups.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.FromArgb(192, 255, 192);
                    e.Appearance.BackColor2 = Color.White;

                    if (gvListMenuGroups.GetRowCellValue(e.RowHandle, e.Column) != null)
                        grMenu.Text = "Danh sách - " + gvListMenuGroups.GetRowCellValue(e.RowHandle, e.Column).ToString();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvListMenuGroups_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.FocusedRowHandle < 0)
                {
                    gcListMenu.DataSource = null;
                    return;
                }

                #region Load menu

                DataTable dtMenu = new DataTable();
                string result = bMenu.GetByGroup(callFrom, ref dtMenu, gvListMenuGroups.GetRowCellValue(e.FocusedRowHandle, gvListMenuGroups_colID).ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByGroup:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByGroup");
                }

                gcListMenu.DataSource = dtMenu;

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvListMenu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvListMenu_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvListMenu.FocusedRowHandle < 0)
                    return;

                if (gvListMenu.FocusedColumn == gvListMenu_colChoose)
                {
                    object menuID = gvListMenu.GetRowCellValue(gvListMenu.FocusedRowHandle, gvListMenu_colID);
                    if (menuID == null || menuID.ToString() == "")
                        return;                    

                    DataTable dtMenu = new DataTable();
                    string result = bGeneral.GetByCondition(callFrom, ref dtMenu, "Menu ", new string[] { "ID" }, new string[] { menuID.ToString() }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Menu -> GetByCondition:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Menu -> GetByCondition");
                        return;
                    }

                    #region Get Size

                    string vSizeID = GeneralFunctions.GetSizeOfMenu(menuID.ToString());
                    if (vSizeID == "")
                        return;

                    #endregion

                    for (int i = 0; i < gvOrderDetail.RowCount; i++)
                    {
                        if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID) != null &&
                            gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID).ToString() != "")
                        {
                            if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colMenuID).ToString() == menuID.ToString() &&
                                gvOrderDetail.GetRowCellValue(i, gvListMenu_colMenuGroupID).ToString() != ((int)CategoriesEnum.MenuGroup.Lẩu).ToString())
                            {
                                string vSizeCurrent = "";
                                if (gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colSizeID) != null &&
                                    gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colSizeID).ToString() != "")
                                    vSizeCurrent = gvOrderDetail.GetRowCellValue(i, gvOrderDetail_colSizeID).ToString();

                                if (vSizeID == vSizeCurrent)
                                {
                                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Kích cỡ này đã được nhập.\nVui lòng điều chỉnh số lượng trong danh sách bên phải.");
                                    return;
                                }
                            }
                        }
                    }

                    int MenuGroupID = int.Parse(dtMenu.Rows[0]["MenuGroupID"].ToString());

                    int TasteQTy = 0;
                    if (MenuGroupID == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                        TasteQTy = int.Parse(dtMenu.Rows[0]["TasteQTy"].ToString());

                    object unitID = dtMenu.Rows[0]["UnitID"];
                    object menuGroupID = dtMenu.Rows[0]["MenuGroupID"];
                    object price, priceListID;                    
                    object hotpot1ID, hotpot2ID;
                    hotpot1ID = DBNull.Value;
                    hotpot2ID = DBNull.Value;

                    dtMenu = new DataTable();
                    result = bPriceList.IsUsing_GetMenu(callFrom, ref dtMenu, menuID.ToString(), vSizeID);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> IsUsing_GetMenu:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> IsUsing_GetMenu");
                        return;
                    }
                    else
                    {
                        if (dtMenu == null || dtMenu.Rows.Count == 0)
                        {
                            Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Kích cỡ này chưa có Giá bán !!!");
                            return;
                        }
                        else if (dtMenu.Rows.Count > 1)
                        {
                            Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Giá bán của Kích cỡ này không hợp lệ.\nVì Kích cỡ này có " + dtMenu.Rows.Count + @" giá bán !!!");
                            return;
                        }
                        else
                        {
                            price = dtMenu.Rows[0]["Price"];
                            priceListID = dtMenu.Rows[0]["PriceListID"];
                        }
                    }

                    if (MenuGroupID == (int)Utilities.CategoriesEnum.MenuGroup.Lẩu)
                    {
                        pageManagement_groupFunctions_TableAndDish_KindOfHotpot frmKindOfHotpot = new pageManagement_groupFunctions_TableAndDish_KindOfHotpot();

                        frmKindOfHotpot.lstID = new List<int>();
                        frmKindOfHotpot.vTasteQTy = TasteQTy;
                        DialogResult dlg = frmKindOfHotpot.ShowDialog();
                        if (dlg == DialogResult.OK)
                        {
                            if (frmKindOfHotpot.lstID.Count == 1)
                            {
                                hotpot1ID = frmKindOfHotpot.lstID[0];
                            }
                            else if (frmKindOfHotpot.lstID.Count == 2)
                            {
                                hotpot1ID = frmKindOfHotpot.lstID[0];
                                hotpot2ID = frmKindOfHotpot.lstID[1];
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    DataRow drAdd = vdtOrderDetail.NewRow();
                    drAdd["MenuID"] = menuID;
                    drAdd["UnitID"] = unitID;
                    drAdd["SizeID"] = int.Parse(vSizeID);
                    drAdd["MenuGroupID"] = menuGroupID;
                    drAdd["Quantity"] = 1;
                    drAdd["Price"] = price;
                    drAdd["PriceListID"] = priceListID;
                    drAdd["KindOfHotpot1ID"] = hotpot1ID;
                    drAdd["KindOfHotpot2ID"] = hotpot2ID;
                    vdtOrderDetail.Rows.Add(drAdd);
                    vdtOrderDetail.AcceptChanges();

                    CalcTotal(callFrom);
                    gvOrderDetail.PostEditor();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetail_colQuantity_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void gvOrderDetail_colPrice_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}