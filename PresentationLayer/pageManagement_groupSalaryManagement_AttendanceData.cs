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
    public partial class pageManagement_groupSalaryManagement_AttendanceData : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        int arrIndex = -1;
        int selectedID = 0;

        #region Functions     

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
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
                pageManagement_groupSalaryManagement_AttendanceData_Edit frmEdit = new pageManagement_groupSalaryManagement_AttendanceData_Edit();
                frmEdit._AttendanceDataID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit._AttendanceDataID);
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
                if (gvAttendanceData.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Dữ liệu chấm công cần hủy.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn hủy dữ liệu chấm công của " + gvAttendanceData.GetFocusedRowCellDisplayText(gvAttendanceData_colEmployeeID).ToString() + "?") != DialogResult.Yes)
                    return;

                selectedID = int.Parse(gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colID).ToString());
                DataTable _dtAttendanceData = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref _dtAttendanceData, "AttendanceData", new string[] { "ID" }, new string[] { selectedID.ToString() }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                    return;
                }

                _dtAttendanceData.Rows[0]["CancelDate"] = DateTime.Now;
                _dtAttendanceData.Rows[0]["CancelBy"] = Utilities.Parameters.UserLogin.UserID;
                _dtAttendanceData.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.AttendanceData_Status.Đã_hủy;

                string result = bGeneral.UpdateByID(callFrom, _dtAttendanceData);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Update:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Update");
                    return;
                }
                else
                {
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

        #endregion

        #region Events

        public pageManagement_groupSalaryManagement_AttendanceData()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Dữ liệu chấm công.");
                this.Close();
            }
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
                gvAttendanceData.CollapseAllGroups();
            else
                gvAttendanceData.ExpandAllGroups();
        }

        private void pageManagement_groupSalaryManagement_AttendanceData_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageManagement_groupSalaryManagement_AttendanceData_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageManagement_groupSalaryManagement_AttendanceData_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_AttendanceData", Utilities.Parameters.Permission_VIEW_ALL))
                {
                    slkEmployee.ReadOnly = false;
                    gvAttendanceData_colCreatedBy.Visible = true;
                    gvAttendanceData_colCreatedDate.Visible = true;
                    gvAttendanceData_colCancelBy.Visible = true;
                    gvAttendanceData_colCancelDate.Visible = true;
                }
                else
                {
                    slkEmployee.ReadOnly = true;
                    gvAttendanceData_colCreatedBy.Visible = false;
                    gvAttendanceData_colCreatedDate.Visible = false;
                    gvAttendanceData_colCancelBy.Visible = false;
                    gvAttendanceData_colCancelDate.Visible = false;
                }

                Populate_LookUpEdit(lkStatus, "AttendanceData_Status");
                Populate_LookUpEdit(gvAttendanceData_colStatusID_lk, "AttendanceData_Status");
                Populate_LookUpEdit(gvAttendanceData_colRecordTypeID_lk, "AttendanceData_RecordType");

                #region Employees

                DataTable dtEmployees = new DataTable();
                string vResult = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ",
                                                        new string[] { "StatusID", "ID" },
                                                        new string[] { "=", "<>" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(), ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() },
                                                        "FullName asc");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                else
                {
                    DataTable dtEmployees2 = dtEmployees.Copy();
                    gvAttendanceData_colEmployeeID_lk.ValueMember = "ID";
                    gvAttendanceData_colEmployeeID_lk.DisplayMember = "FullName";
                    gvAttendanceData_colEmployeeID_lk.DataSource = dtEmployees2;

                    DataRow dr = dtEmployees.NewRow();
                    dr["ID"] = -1;
                    dr["FullName"] = "Tất cả";
                    dtEmployees.Rows.InsertAt(dr, 0);

                    slkEmployee.Properties.ValueMember = "ID";
                    slkEmployee.Properties.DisplayMember = "FullName";
                    slkEmployee.Properties.DataSource = dtEmployees;
                }

                #endregion

                #region User

                BusinessLogicLayer.busEmployees bEmployees = new BusinessLogicLayer.busEmployees();
                DataTable dtUsers = new DataTable();
                vResult = bEmployees.GetAll(callFrom, ref dtUsers);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetAll:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Employees -> GetAll");
                }
                else
                {
                    for (int i = 0; i < dtUsers.Rows.Count; i++)
                    {
                        if (int.Parse( dtUsers.Rows[i]["StatusID"].ToString()) ==(int)Utilities.CategoriesEnum.Status.Tạm_ngưng)
                        {
                            dtUsers.Rows.RemoveAt(i);
                            i = i - 1;
                        }
                    }

                    gvAttendanceData_colCreatedBy_lk.ValueMember = "User_ID";
                    gvAttendanceData_colCreatedBy_lk.DisplayMember = "FullName";
                    gvAttendanceData_colCreatedBy_lk.DataSource = dtUsers;
                }

                #endregion

                //dateAttendanceTimeFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                dateAttendanceTimeFrom.DateTime = DateTime.Now;
                dateAttendanceTimeTo.DateTime = DateTime.Now;
                lkStatus.EditValue = (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương;
                slkEmployee.EditValue = int.Parse(Utilities.Parameters.UserLogin.UserID);

                btnGetData_Click(null, null);

                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvAttendanceData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void slkEmployee_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvAttendanceData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvAttendanceData.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                int vStatusID = int.Parse(gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colStatusID).ToString());
                if (vStatusID == (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương)
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

        private void lkStatus_EditValueChanged(object sender, EventArgs e)
        {
            gcAttendanceData.DataSource = null;
        }

        private void dateAttendanceTimeFrom_EditValueChanged(object sender, EventArgs e)
        {
            gcAttendanceData.DataSource = null;
        }

        private void dateAttendanceTimeTo_EditValueChanged(object sender, EventArgs e)
        {
            gcAttendanceData.DataSource = null;
        }

        private void slkEmployee_EditValueChanged(object sender, EventArgs e)
        {
            gcAttendanceData.DataSource = null;
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

                DateTime vFrom = new DateTime(dateAttendanceTimeFrom.DateTime.Year, dateAttendanceTimeFrom.DateTime.Month, dateAttendanceTimeFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(dateAttendanceTimeTo.DateTime.Year, dateAttendanceTimeTo.DateTime.Month, dateAttendanceTimeTo.DateTime.Day, 23, 59, 59);
                string vStatus = lkStatus.EditValue.ToString();
                string vEmployeeID = slkEmployee.EditValue.ToString();

                DataTable vdtAttendanceData = new DataTable();
                string[] varrFields= new string[] { "AttendanceTime", "AttendanceTime", "StatusID" };
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

                string result = bGeneral.GetByCondition(callFrom, ref vdtAttendanceData, "AttendanceData", varrFields, varrOpers, varrValue, "EmployeeID ASC, AttendanceTime ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                }

                gcAttendanceData.DataSource = vdtAttendanceData;
                chkExpand_CheckedChanged(null, null);

                if (selectedID > 0)
                    for (int i = 0; i < gvAttendanceData.RowCount; i++)
                    {
                        if (gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colID) != null && gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colID).ToString() == selectedID.ToString())
                        {
                            gvAttendanceData.SelectRow(i);
                            gvAttendanceData.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (vdtAttendanceData == null || vdtAttendanceData.Rows.Count == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvAttendanceData_FocusedRowChanged(null, null);
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