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
    public partial class pageManagement_groupFunctions_CollectAndSpend : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        DataTable dtData_CollectAndSpend = new DataTable();

        int arrIndex = -1;
        int selectedID = 0;

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

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_CollectAndSpend_Load(null, null);
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
                this.Tag = Utilities.Parameters.Permission_NEW;

                ClearData(callFrom);
                EnableControl(callFrom, true);

                CollectAndSpend_CollectAndSpendGroupID.EditValue = (int)Utilities.CategoriesEnum.CollectAndSpendGroup.Tiền_chi;

                if (dtData_CollectAndSpend.Rows.Count > 0)
                    dtData_CollectAndSpend.Rows.Clear();
                DataRow drCollectAndSpend = dtData_CollectAndSpend.NewRow();
                dtData_CollectAndSpend.Rows.Add(drCollectAndSpend);

                if (chkAction.Checked && dateAction.Text != "")
                    CollectAndSpend_ActionDate.DateTime = dateAction.DateTime;
                else
                    CollectAndSpend_ActionDate.DateTime = DateTime.Now;

                CollectAndSpend_ActionBy.EditValue = 2;
                CollectAndSpend_CollectAndSpendGroupID.Focus();

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
                if (gvCollectAndSpend.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần cập nhật.", 5000);
                    return;
                }

                this.Tag = Utilities.Parameters.Permission_EDIT;
                EnableControl(callFrom, true);
                CollectAndSpend_Name.SelectAll();
                CollectAndSpend_Name.Focus();
                CollectAndSpend_CollectAndSpendGroupID.ReadOnly = true;
                selectedID = int.Parse(gvCollectAndSpend.GetFocusedRowCellValue(gvCollectAndSpend_colID).ToString());

                frmMain.EnableAction(false, true, false, false, true, false, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
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

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                Utilities.Multi.AssignData_FormToRow(dtData_CollectAndSpend.Rows[0], this, callFrom);

                if (int.Parse(CollectAndSpend_CollectAndSpendGroupID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.CollectAndSpendGroup.Tiền_chi)
                    dtData_CollectAndSpend.Rows[0]["Amount"] = Math.Abs(decimal.Parse(CollectAndSpend_Amount.Text)) * -1;
                else
                    dtData_CollectAndSpend.Rows[0]["Amount"] = Math.Abs(decimal.Parse(CollectAndSpend_Amount.Text));

                dtData_CollectAndSpend.AcceptChanges();

                string result = "";
                if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                {
                    dtData_CollectAndSpend.Rows[0]["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    dtData_CollectAndSpend.Rows[0]["CreatedDate"] = DateTime.Now;

                    result = bGeneral.Insert(callFrom, ref dtData_CollectAndSpend, true);
                }
                else if (this.Tag.ToString() == Utilities.Parameters.Permission_EDIT)
                {
                    dtData_CollectAndSpend.Rows[0]["UpdatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    dtData_CollectAndSpend.Rows[0]["UpdatedDate"] = DateTime.Now;

                    result = bGeneral.UpdateByID(callFrom, dtData_CollectAndSpend);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (this.Tag.ToString() == Utilities.Parameters.Permission_NEW)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> CollectAndSpend_Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> CollectAndSpend_Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> CollectAndSpend_Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> CollectAndSpend_Update");
                    }
                    return;
                }
                else
                {
                    string employeeID = dtData_CollectAndSpend.Rows[0]["ID"].ToString();

                    pageManagement_groupFunctions_CollectAndSpend_Load(null, null);

                    for (int i = 0; i < gvCollectAndSpend.RowCount; i++)
                    {
                        if (gvCollectAndSpend.GetRowCellValue(i, gvCollectAndSpend_colID) != null && gvCollectAndSpend.GetRowCellValue(i, gvCollectAndSpend_colID).ToString() == employeeID)
                        {
                            gvCollectAndSpend.SelectRow(i);
                            gvCollectAndSpend.FocusedRowHandle = i;
                            break;
                        }
                    }

                    gvCollectAndSpend_FocusedRowChanged(null, null);
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

                ClearData(callFrom);
                EnableControl(callFrom, false);
                gvCollectAndSpend_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Delete(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvCollectAndSpend.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần xóa.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa '" + gvCollectAndSpend.GetFocusedRowCellValue(gvCollectAndSpend_colName).ToString() + "'?") != DialogResult.Yes)
                    return;

                this.Tag = Utilities.Parameters.Permission_DELETE;
                selectedID = int.Parse(gvCollectAndSpend.GetFocusedRowCellValue(gvCollectAndSpend_colID).ToString());

                string result = bGeneral.DeleteByID(callFrom, "CollectAndSpend", selectedID.ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Role_Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Role_Delete");
                    return;
                }

                pageManagement_groupFunctions_CollectAndSpend_Load(null, null);
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
                gcCollectAndSpend.Enabled = !IsEnable;
                chkExpand.ReadOnly = IsEnable;
                grSearch.Enabled= !IsEnable;

                CollectAndSpend_CollectAndSpendGroupID.ReadOnly = !IsEnable;
                CollectAndSpend_Name.ReadOnly = !IsEnable;
                CollectAndSpend_ActionDate.ReadOnly = !IsEnable;
                CollectAndSpend_ActionBy.ReadOnly = !IsEnable;
                CollectAndSpend_Amount.ReadOnly = !IsEnable;
                CollectAndSpend_Note.ReadOnly = !IsEnable;

                if (IsEnable)
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
                else
                    Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", CollectAndSpend_Note.BackColor);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void ClearData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CollectAndSpend_CollectAndSpendGroupID.EditValue = DBNull.Value;
                CollectAndSpend_Name.Text = string.Empty;
                CollectAndSpend_ActionDate.Text = string.Empty;
                CollectAndSpend_ActionBy.EditValue = DBNull.Value;
                CollectAndSpend_Amount.Text = string.Empty;
                CollectAndSpend_Note.Text = string.Empty;

                if (dtData_CollectAndSpend.Rows.Count > 0)
                    dtData_CollectAndSpend.Rows.Clear();

                selectedID = 0;
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

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        private void LoadCollectAndSpend(string CallBy, string CollectAndSpendID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dtData_CollectAndSpend = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtData_CollectAndSpend, "CollectAndSpend", new string[] { "ID" }, new string[] { CollectAndSpendID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> CollectAndSpend_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> CollectAndSpend_GetByCondition");
                }
                else
                {
                    Utilities.Multi.AssignData_RowToForm(dtData_CollectAndSpend.Rows[0], this, callFrom);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListCollectAndSpend(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime from = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);

                DataTable dtListCollectAndSpend = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtListCollectAndSpend, "CollectAndSpend",
                                                            new string[] { "ActionDate" }, 
                                                            new string[] { "BETWEEN" }, 
                                                            new string[] { "'" + from.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'" },
                                                            "ActionDate ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll");
                }

                gcCollectAndSpend.DataSource = dtListCollectAndSpend;
                chkExpand_CheckedChanged(null, null);
                gvCollectAndSpend_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageManagement_groupFunctions_CollectAndSpend()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Danh mục vật tư.");
                this.Close();
            }

            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
        }

        private void pageManagement_groupFunctions_CollectAndSpend_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Populate_LookUpEdit(CollectAndSpend_CollectAndSpendGroupID, "CollectAndSpendGroup");
                Populate_LookUpEdit(gvCollectAndSpend_colCollectAndSpendGroupID_rlk, "CollectAndSpendGroup");

                #region ActionBy

                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtEmployees, "Employees", "FullName ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll");
                }
                Utilities.Multi.Populate_LookUpEdit(CollectAndSpend_ActionBy, dtEmployees, "ID", "FullName");
                Utilities.Multi.Populate_LookUpEdit(gvCollectAndSpend_colActionBy_rlk, dtEmployees, "ID", "FullName");

                #endregion

                #region CreatedBy - UpdatedBy

                DataTable dtCreatedBy = new DataTable();
                BusinessLogicLayer.busUsers bUsers = new BusinessLogicLayer.busUsers();
                result = bUsers.GetAll(callFrom, ref dtCreatedBy);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> busUsers -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> busUsers -> GetAll");
                }

                gvCollectAndSpend_colCreatedBy_rlk.ValueMember = "ID";
                gvCollectAndSpend_colCreatedBy_rlk.DisplayMember = "Name";
                gvCollectAndSpend_colCreatedBy_rlk.DataSource = dtCreatedBy;

                #endregion

                #region CollectAndSpend_Name

                BusinessLogicLayer.busReport bReport = new BusinessLogicLayer.busReport();

                DataTable dtName = new DataTable();
                result = bReport.CollectAndSpend_GetName(callFrom, ref dtName);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> busReport -> CollectAndSpend_GetName:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> busReport -> CollectAndSpend_GetName");
                }

                CollectAndSpend_Name.Properties.Items.Clear();
                foreach (DataRow dr in dtName.Rows)
                    CollectAndSpend_Name.Properties.Items.Add(dr["Name"]);

                #endregion

                dtData_CollectAndSpend = new DataTable();
                dtData_CollectAndSpend.TableName = "CollectAndSpend";
                result = bGeneral.GetByCondition(callFrom, ref dtData_CollectAndSpend, "CollectAndSpend", new string[] { "ID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                }

                GetListCollectAndSpend(callFrom);

                this.Tag = Utilities.Parameters.Permission_LOAD;
                EnableControl(callFrom, false);

                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void pageManagement_groupFunctions_CollectAndSpend_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageManagement_groupFunctions_CollectAndSpend_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void gvCollectAndSpend_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvCollectAndSpend_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ClearData(callFrom);
                if (gvCollectAndSpend.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                selectedID = int.Parse(gvCollectAndSpend.GetFocusedRowCellValue(gvCollectAndSpend_colID).ToString());

                LoadCollectAndSpend(callFrom, selectedID.ToString());

                frmMain.EnableAction(true, false, true, true, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void CollectAndSpend_CollectAndSpendGroupID_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (CollectAndSpend_CollectAndSpendGroupID.EditValue == null ||
                    CollectAndSpend_CollectAndSpendGroupID.EditValue.ToString() == "")
                    return;

                if (int.Parse(CollectAndSpend_CollectAndSpendGroupID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.CollectAndSpendGroup.Tiền_chi)
                {
                    CtrlCollectAndSpend_Name.Text = "Nội dung chi";
                    CtrlCollectAndSpend_ActionDate.Text = "Ngày chi";
                    CtrlCollectAndSpend_ActionBy.Text = "Người chi";
                    CtrlCollectAndSpend_Amount.Text = "Số tiền chi";
                }
                else
                {
                    CtrlCollectAndSpend_Name.Text = "Nội dung thu";
                    CtrlCollectAndSpend_ActionDate.Text = "Ngày thu";
                    CtrlCollectAndSpend_ActionBy.Text = "Người thu";
                    CtrlCollectAndSpend_Amount.Text = "Số tiền thu";
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void CollectAndSpend_ActionBy_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        #endregion

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
                gvCollectAndSpend.CollapseAllGroups();
            else
                gvCollectAndSpend.ExpandAllGroups();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                GetListCollectAndSpend(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ClearData(callFrom);
                gcCollectAndSpend.DataSource = null;
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
                ClearData(callFrom);
                gcCollectAndSpend.DataSource = null;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void chkAction_CheckedChanged(object sender, EventArgs e)
        {
            dateAction.Text = "";
            if (chkAction.Checked)
                dateAction.ReadOnly = false;
            else
                dateAction.ReadOnly = true;
        }
    }
}