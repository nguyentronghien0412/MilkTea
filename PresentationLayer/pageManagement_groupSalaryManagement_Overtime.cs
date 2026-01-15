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
    public partial class pageManagement_groupSalaryManagement_Overtime : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busPayroll bPayroll = new BusinessLogicLayer.busPayroll();

        int arrIndex = -1;
        int selectedID = 0;

        #region Functions     

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                GetListOfEmployees(callFrom);
                GetListOfCreatedBy(callFrom);
                GetListOfApprovedBy(callFrom);
                btnGetData_Click(null, null);
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
                pageManagement_groupSalaryManagement_Overtime_Edit frmEdit = new pageManagement_groupSalaryManagement_Overtime_Edit();
                frmEdit._OvertimeID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit._OvertimeID);

                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);
                    GetListOfApprovedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
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
                if (gvOvertime.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần cập nhật.", 5000);
                    return;
                }

                selectedID = int.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colID).ToString());

                pageManagement_groupSalaryManagement_Overtime_Edit frmEdit = new pageManagement_groupSalaryManagement_Overtime_Edit();
                frmEdit._OvertimeID = selectedID.ToString();
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);
                    GetListOfApprovedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
                }
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
                if (gvOvertime.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần xóa.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn XÓA dữ liệu của " + gvOvertime.GetFocusedRowCellDisplayText(gvOvertime_colEmployeeID).ToString() + "?") != DialogResult.Yes)
                    return;

                selectedID = int.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colID).ToString());

                string result = bPayroll.Overtime_Delete(callFrom, selectedID.ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Delete");
                    return;
                }
                else
                {
                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);
                    GetListOfApprovedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
                }
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

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ dữ liệu cần tra cứu.";

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }

        }

        private void GetListOfEmployees(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                slkEmployee.Properties.DataSource = null;

                DataTable vdtEmployees = new DataTable();
                string vResult = bPayroll.Overtime_GetListOfEmployees(callFrom, ref vdtEmployees, dateWorkingDateFrom.DateTime, dateWorkingDateTo.DateTime);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetListOfEmployees:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetListOfEmployees");
                }
                else
                {
                    DataTable vdtEmployees2 = vdtEmployees.Copy();
                    gvOvertime_colEmployeeID_lk.ValueMember = "ID";
                    gvOvertime_colEmployeeID_lk.DisplayMember = "FullName";
                    gvOvertime_colEmployeeID_lk.DataSource = vdtEmployees2;

                    DataRow dr = vdtEmployees.NewRow();
                    dr["ID"] = -1;
                    dr["FullName"] = "Tất cả";
                    vdtEmployees.Rows.InsertAt(dr, 0);

                    slkEmployee.Properties.ValueMember = "ID";
                    slkEmployee.Properties.DisplayMember = "FullName";
                    slkEmployee.Properties.DataSource = vdtEmployees;
                    slkEmployee.EditValue = int.Parse(Utilities.Parameters.UserLogin.EmployeesID);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListOfCreatedBy(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gvOvertime_colCreatedBy_lk.DataSource = null;

                DataTable vdtUser = new DataTable();
                string vResult = bPayroll.Overtime_GetListOfCreatedBy(callFrom, ref vdtUser, dateWorkingDateFrom.DateTime, dateWorkingDateTo.DateTime);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Overtime_GetListOfCreatedBy:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Overtime_GetListOfCreatedBy");
                }
                else
                {
                    gvOvertime_colCreatedBy_lk.ValueMember = "ID";
                    gvOvertime_colCreatedBy_lk.DisplayMember = "FullName";
                    gvOvertime_colCreatedBy_lk.DataSource = vdtUser;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListOfApprovedBy(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gvOvertime_colApprovedBy_lk.DataSource = null;

                DataTable vdtUser = new DataTable();
                string vResult = bPayroll.Overtime_GetListOfApprovedBy(callFrom, ref vdtUser, dateWorkingDateFrom.DateTime, dateWorkingDateTo.DateTime);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Overtime_GetListOfApprovedBy:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Overtime_GetListOfApprovedBy");
                }
                else
                {
                    gvOvertime_colApprovedBy_lk.ValueMember = "ID";
                    gvOvertime_colApprovedBy_lk.DisplayMember = "FullName";
                    gvOvertime_colApprovedBy_lk.DataSource = vdtUser;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageManagement_groupSalaryManagement_Overtime()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Dữ liệu tăng ca.");
                this.Close();
            }
        }

        private void pageManagement_groupSalaryManagement_Overtime_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageManagement_groupSalaryManagement_Overtime_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageManagement_groupSalaryManagement_Overtime_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                dateWorkingDateFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

                DateTime vDateTemp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 23, 59, 59);
                vDateTemp = vDateTemp.AddMonths(1);
                dateWorkingDateTo.DateTime = vDateTemp.AddDays(-1);

                Populate_LookUpEdit(lkStatus, "Overtime_Status");
                Populate_LookUpEdit(gvOvertime_colStatusID_lk, "Overtime_Status");

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Overtime", Utilities.Parameters.Permission_VIEW_ALL))
                    slkEmployee.ReadOnly = false;
                else
                    slkEmployee.ReadOnly = true;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Overtime", Utilities.Parameters.Permission_APPROVED))
                    btnApproved.Visible = true;
                else
                    btnApproved.Visible = false;

                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvOvertime_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvOvertime_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnApproved.Enabled = false;
                if (gvOvertime.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                int vStatusID = int.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colStatusID).ToString());
                if (vStatusID == (int)Utilities.CategoriesEnum.Overtime_Status.Chưa_duyệt)
                {
                    if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Overtime", Utilities.Parameters.Permission_APPROVED))
                        btnApproved.Enabled = true;

                    frmMain.EnableAction(true, false, true, true, false, true, false, false, false, arrIndex);
                }
                else if (vStatusID == (int)Utilities.CategoriesEnum.Overtime_Status.Đã_duyệt)
                    frmMain.EnableAction(true, false, false, true, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void dateWorkingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GetListOfEmployees(callFrom);
            GetListOfCreatedBy(callFrom);
            GetListOfApprovedBy(callFrom);
            gcOvertime.DataSource = null;
        }

        private void dateWorkingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GetListOfEmployees(callFrom);
            GetListOfCreatedBy(callFrom);
            GetListOfApprovedBy(callFrom);
            gcOvertime.DataSource = null;
        }

        private void lkStatus_EditValueChanged(object sender, EventArgs e)
        {
            gcOvertime.DataSource = null;
        }

        private void slkEmployee_EditValueChanged(object sender, EventArgs e)
        {
            gcOvertime.DataSource = null;
        }

        private void btnGetData_Click(object sender, EventArgs e)
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

                DateTime vFrom = new DateTime(dateWorkingDateFrom.DateTime.Year, dateWorkingDateFrom.DateTime.Month, dateWorkingDateFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(dateWorkingDateTo.DateTime.Year, dateWorkingDateTo.DateTime.Month, dateWorkingDateTo.DateTime.Day, 23, 59, 59);
                string vStatus = lkStatus.EditValue.ToString();
                string vEmployeeID = slkEmployee.EditValue.ToString();

                DataTable vdtOvertime = new DataTable();
                string[] varrFields = new string[] { "WorkingDate", "WorkingDate", "StatusID" };
                string[] varrOpers = new string[] { ">=", "<=", "=" };
                string[] varrValue = new string[] { "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    vStatus };

                if (int.Parse(vEmployeeID) > 0)
                {
                    Array.Resize(ref varrFields, varrFields.Length + 1);
                    varrFields[varrFields.Length - 1] = "EmployeeID";

                    Array.Resize(ref varrOpers, varrOpers.Length + 1);
                    varrOpers[varrOpers.Length - 1] = "=";

                    Array.Resize(ref varrValue, varrValue.Length + 1);
                    varrValue[varrValue.Length - 1] = vEmployeeID;
                }

                string result = bGeneral.GetByCondition(callFrom, ref vdtOvertime, "Overtime", varrFields, varrOpers, varrValue, "EmployeeID ASC, WorkingDate_In ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Overtime:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition Overtime");
                }

                gcOvertime.DataSource = vdtOvertime;

                if (selectedID > 0)
                    for (int i = 0; i < gvOvertime.RowCount; i++)
                    {
                        if (gvOvertime.GetRowCellValue(i, gvOvertime_colID) != null && gvOvertime.GetRowCellValue(i, gvOvertime_colID).ToString() == selectedID.ToString())
                        {
                            gvOvertime.SelectRow(i);
                            gvOvertime.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (gvOvertime.RowCount == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvOvertime_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void slkEmployee_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            string callFrom = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOvertime.FocusedRowHandle < 0)
                {
                    btnApproved.Enabled = false;
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần duyệt.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn DUYỆT dữ liệu của " + gvOvertime.GetFocusedRowCellDisplayText(gvOvertime_colEmployeeID).ToString() + "?") != DialogResult.Yes)
                    return;

                selectedID = int.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colID).ToString());

                DataTable _dtOvertime = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref _dtOvertime, "Overtime", new string[] { "ID" }, new string[] { selectedID.ToString() }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Overtime:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Overtime");
                    return;
                }

                _dtOvertime.Rows[0]["ApprovedBy"] = Utilities.Parameters.UserLogin.UserID;
                _dtOvertime.Rows[0]["ApprovedDate"] = DateTime.Now;
                _dtOvertime.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.Overtime_Status.Đã_duyệt;
                _dtOvertime.AcceptChanges();

                string result = bGeneral.UpdateByID(callFrom, _dtOvertime);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Delete");
                    return;
                }
                else
                {
                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);
                    GetListOfApprovedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion
    }
}