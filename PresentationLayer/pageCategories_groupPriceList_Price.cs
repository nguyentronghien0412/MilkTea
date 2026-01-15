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
    public partial class pageCategories_groupPriceList_Price : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        int selectedID = 0;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busMenu bMenu = new BusinessLogicLayer.busMenu();
        BusinessLogicLayer.busPriceList bPriceList = new BusinessLogicLayer.busPriceList();

        DataTable dtData_PriceList = new DataTable();
        DataTable dtData_PriceListDetail = new DataTable();

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

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private void ClearData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                PriceList_Code.Text = string.Empty;
                PriceList_Name.Text = string.Empty;
                PriceList_StartDate.Text = string.Empty;
                PriceList_StopDate.Text = string.Empty;
                PriceList_CurrencyID.EditValue = DBNull.Value;
                PriceList_StatusOfPriceListID.EditValue = DBNull.Value;

                if (dtData_PriceList != null && dtData_PriceList.Rows.Count > 0)
                    dtData_PriceList.Rows.Clear();

                if (dtData_PriceListDetail != null && dtData_PriceListDetail.Rows.Count > 0)
                    dtData_PriceListDetail.Rows.Clear();
                gcPriceListDetail.DataSource = dtData_PriceListDetail;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void EnableControl(string CallBy, bool IsEnable)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                PriceList_Code.ReadOnly = !IsEnable;
                PriceList_Name.ReadOnly = !IsEnable;
                PriceList_StartDate.ReadOnly = !IsEnable;
                PriceList_StopDate.ReadOnly = !IsEnable;
                PriceList_CurrencyID.ReadOnly = !IsEnable;
                PriceList_StatusOfPriceListID.ReadOnly = !IsEnable;

                gvPriceListDetail.OptionsBehavior.Editable = IsEnable;
                gvPriceListDetail.OptionsBehavior.ReadOnly = !IsEnable;

                gcPriceList.Enabled = !IsEnable;
                btnExportExcel.Enabled = false;

                if (IsEnable)
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
                else
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", PriceList_Code.BackColor);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private DataTable CreateColumn_PriceList(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtReturn = new DataTable();
                dtReturn.TableName = "PriceList";

                string result = bGeneral.GetByCondition(callFrom, ref dtReturn, "PriceList", new string[] { "ID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return null;
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return null;
            }
        }

        public void New(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                this.Tag = Utilities.Parameters.Permission_NEW;

                ClearData(callFrom);
                EnableControl(callFrom, true);

                PriceList_CurrencyID.EditValue = (int)Utilities.CategoriesEnum.Currency.Việt_nam_đồng;
                PriceList_StatusOfPriceListID.EditValue = (int)Utilities.CategoriesEnum.StatusOfPriceList.Chưa_phát_hành;
                PriceList_StatusOfPriceListID.ReadOnly = true;

                dtData_PriceList = CreateColumn_PriceList(callFrom);
                DataRow drPriceList = dtData_PriceList.NewRow();
                dtData_PriceList.Rows.Add(drPriceList);

                dtData_PriceListDetail = new DataTable();
                string result = bMenu.PriceList_GetIsActive(callFrom, ref dtData_PriceListDetail);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> PriceList_GetIsActive:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> PriceList_GetIsActive");
                }

                gcPriceListDetail.DataSource = dtData_PriceListDetail;
                gvPriceListDetail.ExpandAllGroups();

                PriceList_Code.Focus();

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
                this.Tag = Utilities.Parameters.Permission_EDIT;

                EnableControl(callFrom, true);
                PriceList_Code.SelectAll();
                PriceList_Code.Focus();

                frmMain.EnableAction(false, true, false, false, true, false, false, false, false, arrIndex);
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
                gvPriceListDetail.PostEditor();
                dtData_PriceListDetail.AcceptChanges();
                PriceList_Code.Focus();

                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                DataTable dtCheck = new DataTable();
                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", new string[] { "Name" }, new string[] { "'" + PriceList_Name.Text.Trim() + "'" }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên bảng giá đã có trong danh mục.";
                }
                else if (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + PriceList_Name.Text.Trim() + "'", selectedID.ToString() }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên bảng giá đã có trong danh mục.";

                    dtCheck = new DataTable();
                    result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", new string[] { "ID" }, new string[] { selectedID.ToString() }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }

                    int _Status = int.Parse(dtCheck.Rows[0]["StatusOfPriceListID"].ToString());
                    if (_Status == (int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành)
                    {
                        if (int.Parse(PriceList_StatusOfPriceListID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Chưa_phát_hành)
                            return "Trạng thái chưa hợp lệ. Chỉ được cập nhật HẾT HẠN";
                    }

                    string msg = CheckToChangeStatus(callFrom, selectedID.ToString(), PriceList_StatusOfPriceListID.EditValue.ToString());
                    if (msg != Utilities.Parameters.ResultMessage)
                        return msg;
                }

                DateTime dtFrom = new DateTime(PriceList_StartDate.DateTime.Year, PriceList_StartDate.DateTime.Month, PriceList_StartDate.DateTime.Day, 0, 0, 0);
                DateTime dtTo = new DateTime(PriceList_StopDate.DateTime.Year, PriceList_StopDate.DateTime.Month, PriceList_StopDate.DateTime.Day, 0, 0, 0);
                if (dtFrom > dtTo)
                    return "Ngày kết thúc phải lớn hơn ngày áp dụng.";

                //for (int i = 0; i < gvPriceListDetail.RowCount; i++)
                //{
                //    if (gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colMenuGroupID) != null && 
                //        (gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colPrice) == null ||
                //         gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colPrice).ToString() == ""))
                //        return "Vui lòng nhập Giá bán";
                //}

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        public void Save(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                string vMessage = "Bạn muốn lưu dữ liệu?";
                for (int i = 0; i < gvPriceListDetail.RowCount; i++)
                {
                    if (gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colMenuGroupID) != null &&
                        (gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colPrice) == null ||
                         gvPriceListDetail.GetRowCellValue(i, gvPriceListDetail_colPrice).ToString() == ""))
                    {
                        vMessage = "Giá bán chưa được nhập đầy đủ.\n" + vMessage;
                        break;
                    }
                }

                if (Utilities.Functions.MessageBoxYesNo(vMessage) != DialogResult.Yes)
                    return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                #region Prepare data

                Utilities.Multi.AssignData_FormToRow(dtData_PriceList.Rows[0], this, callFrom);
                dtData_PriceList.AcceptChanges();

                dtData_PriceListDetail.TableName = "PriceListDetail";
                #endregion

                string result = "";
                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                    result = bPriceList.Insert(callFrom, ref dtData_PriceList, ref dtData_PriceListDetail);
                else if (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                    result = bPriceList.Update(callFrom, dtData_PriceList, dtData_PriceListDetail);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> PriceList_Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> PriceList_Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> PriceList_Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> PriceList_Update");
                    }
                    return;
                }
                else
                {
                    string _PriceListID = dtData_PriceList.Rows[0]["ID"].ToString();

                    pageCategories_groupPriceList_Price_Load(null, null);

                    for (int i = 0; i < gvPriceList.RowCount; i++)
                    {
                        if (gvPriceList.GetRowCellValue(i, gvPriceList_colID) != null && gvPriceList.GetRowCellValue(i, gvPriceList_colID).ToString() == _PriceListID)
                        {
                            gvPriceList.SelectRow(i);
                            gvPriceList.FocusedRowHandle = i;
                            break;
                        }
                    }

                    gvPriceList_FocusedRowChanged(null, null);
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

                this.Tag = Utilities.Parameters.Permission_CANCEL;

                EnableControl(callFrom, false);
                gvPriceList_FocusedRowChanged(null, null);
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
                pageCategories_groupPriceList_Price_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void LoadPriceList(string CallBy, string PriceListID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region PriceList

                string result = bGeneral.GetByCondition(callFrom, ref dtData_PriceList, "PriceList", new string[] { "ID" }, new string[] { PriceListID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return;
                }
                else
                {
                    if (dtData_PriceList.Rows.Count > 0)
                    {
                        Utilities.Multi.AssignData_RowToForm(dtData_PriceList.Rows[0], this, callFrom);
                    }
                    else
                    {
                        DataRow drPriceList = dtData_PriceList.NewRow();
                        dtData_PriceList.Rows.Add(drPriceList);
                        return;
                    }
                }

                #endregion

                #region PriceListDetail

                dtData_PriceListDetail = new DataTable();

                if (int.Parse(dtData_PriceList.Rows[0]["StatusOfPriceListID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Hết_hạn)
                    result = bPriceList.GetByID(callFrom, ref dtData_PriceListDetail, PriceListID, true);
                else
                    result = bPriceList.GetByID(callFrom, ref dtData_PriceListDetail, PriceListID, false);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByID:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByID");
                }

                gcPriceListDetail.DataSource = dtData_PriceListDetail;
                gvPriceListDetail.ExpandAllGroups();

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckToChangeStatus(string CallBy, string PriceListID, string StatusOfPriceListID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.Tag != null && this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    DataTable dtCheck = new DataTable();
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", new string[] { "ID" }, new string[] { PriceListID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }

                    if (int.Parse(dtCheck.Rows[0]["StatusOfPriceListID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành)
                        if (int.Parse(StatusOfPriceListID) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Chưa_phát_hành)
                            return "Trạng thái chưa hợp lệ. Chỉ được cập nhật HẾT HẠN";

                    if (int.Parse(StatusOfPriceListID) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành)
                    {
                        dtCheck = new DataTable();
                        string[] arrFieldName = new string[] { "StatusOfPriceListID", "ID" };
                        string[] arrOperator = new string[] { "=", "<>" };
                        string[] arrValue = new string[] { ((int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành).ToString(), PriceListID };
                        result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", arrFieldName, arrOperator, arrValue, null);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                            return result + "\n" + callFrom + " -> GetByCondition";
                        }

                        if (dtCheck.Rows.Count > 0)
                            return "Không thể đổi trạng thái. Vì '" + dtCheck.Rows[0]["Name"].ToString() + "' đang được sử dụng.";
                    }
                }

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                return ex.Message + "\n" + callFrom;
            }
        }

        #endregion

        #region Events

        public pageCategories_groupPriceList_Price()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Bảng giá.");
                this.Close();
            }
        }

        private void pageCategories_groupPriceList_Price_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageCategories_groupPriceList_Price_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageCategories_groupPriceList_Price_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region Init data

                if (Utilities.Multi.CheckRight_PermissionByCode("pageCategories_groupPriceList_Price", Utilities.Parameters.Permission_COST_PRICE))
                {
                    gvPriceListDetail.OptionsMenu.EnableColumnMenu = true;
                }
                else
                {
                    gvPriceListDetail_colCostPrice.Visible = false;
                    gvPriceListDetail_colDeviated.Visible = false;
                    gvPriceListDetail.OptionsMenu.EnableColumnMenu = false;
                }

                this.Tag = Utilities.Parameters.Permission_LOAD;

                Populate_LookUpEdit(PriceList_CurrencyID, "Currency");
                Populate_LookUpEdit(gvPriceList_colCurrencyID_rlk, "Currency");

                Populate_LookUpEdit(PriceList_StatusOfPriceListID, "StatusOfPriceList");
                Populate_LookUpEdit(gvPriceList_colStatusOfPriceListID_rlk, "StatusOfPriceList");

                Populate_LookUpEdit(gvPriceListDetail_colMenuID_rlk, "Menu");
                Populate_LookUpEdit(gvPriceListDetail_colMenuGroupID_rlk, "MenuGroup");
                Populate_LookUpEdit(gvPriceListDetail_colUnitID_rlk, "Unit");
                Populate_LookUpEdit(gvPriceListDetail_colSizeID_lk, "Size");

                PriceList_Code.Focus();
                EnableControl(callFrom, false);

                gvPriceListDetail_colPrice.AppearanceCell.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;

                #endregion

                DataTable dtPriceList = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtPriceList, "PriceList", null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> PriceList_GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> PriceList_GetAll");
                }

                gcPriceList.DataSource = dtPriceList;

                if (selectedID > 0)
                    for (int i = 0; i < gvPriceList.RowCount; i++)
                    {
                        if (gvPriceList.GetRowCellValue(i, gvPriceList_colID) != null && gvPriceList.GetRowCellValue(i, gvPriceList_colID).ToString() == selectedID.ToString())
                        {
                            gvPriceList.SelectRow(i);
                            gvPriceList.FocusedRowHandle = i;
                            break;
                        }
                    }
                gvPriceList.ExpandAllGroups();

                if (dtData_PriceList == null || dtData_PriceList.Rows.Count == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvPriceListDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvPriceList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnExportExcel.Enabled = false;
                ClearData(callFrom);
                if (gvPriceList.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                selectedID = int.Parse(gvPriceList.GetFocusedRowCellValue(gvPriceList_colID).ToString());

                LoadPriceList(callFrom, selectedID.ToString());

                DataTable dtCheck = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PriceList", new string[] { "ID" }, new string[] { selectedID.ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                }
                else
                {
                    if (int.Parse(dtCheck.Rows[0]["StatusOfPriceListID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfPriceList.Hết_hạn)
                        frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    else
                        frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);
                }

                btnExportExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void PriceList_StatusOfPriceListID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (PriceList_StatusOfPriceListID.EditValue == null)
                    return;

                if (this.Tag != null && this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    string msg = CheckToChangeStatus(callFrom, selectedID.ToString(), e.NewValue.ToString());
                    if (msg != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, msg);
                        e.Cancel = true;
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

        private void gvPriceList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void pageCategories_groupPriceList_Price_FormClosing(object sender, FormClosingEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (this.Tag != null && (this.Tag.ToString() == Utilities.Parameters.Permission_NEW || this.Tag.ToString() == Utilities.Parameters.Permission_EDIT))
                {
                    if (Utilities.Functions.MessageBoxYesNo("Bảng giá chưa được lưu.\nBạn muốn đóng giao diện này?") != DialogResult.Yes)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void gvPriceListDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvPriceListDetail.FocusedRowHandle < 0)
                    return;

                decimal cost = 0, price = 0, deviated = 0;

                if (gvPriceListDetail.GetFocusedRowCellValue(gvPriceListDetail_colCostPrice) != null &&
                    gvPriceListDetail.GetFocusedRowCellValue(gvPriceListDetail_colCostPrice).ToString() != "")
                    cost = decimal.Parse(gvPriceListDetail.GetFocusedRowCellValue(gvPriceListDetail_colCostPrice).ToString());

                if (e.Value != null && e.Value.ToString() != "")
                    price = decimal.Parse(e.Value.ToString());
                
                deviated = price - cost;

                gvPriceListDetail.SetFocusedRowCellValue(gvPriceListDetail_colDeviated, deviated);
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
                gvPriceListDetail.CollapseAllGroups();
            else
                gvPriceListDetail.ExpandAllGroups();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DevExpress.XtraEditors.XtraSaveFileDialog dlgSaveContract = new DevExpress.XtraEditors.XtraSaveFileDialog();
                dlgSaveContract.Title = "Xuất tập tin Excel";
                dlgSaveContract.FileName = Utilities.Functions.ConvertToUnSign(PriceList_Name.Text.Replace("/", "_").Replace("\\", "_"));
                dlgSaveContract.Filter = "Excel Files (*.xlsx)|*.xlsx";
                dlgSaveContract.OverwritePrompt = true;
                if (dlgSaveContract.ShowDialog() != DialogResult.OK)
                    return;

                gvPriceListDetail.ExportToXlsx(dlgSaveContract.FileName);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }
    }
}