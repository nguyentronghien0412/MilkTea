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
    public partial class pageManagement_groupSalaryManagement_TimekeepingOther : DevExpress.XtraEditors.XtraForm
    {
        public DataTable _dtAttendanceData = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageManagement_groupSalaryManagement_TimekeepingOther()
        {
            InitializeComponent();
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

        private void LoadChangeShift(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                slkChangeShift.Properties.DataSource = null;
                if (AttendanceData_EmployeeID.EditValue == null || AttendanceData_EmployeeID.EditValue.ToString() == "")
                    return;

                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees",
                                                        new string[] { "StatusID", "ID", "TimekeepingOther" },
                                                        new string[] { "=", "NOT IN", "=" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(),
                                                                       "(" + ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() + "," + AttendanceData_EmployeeID.EditValue.ToString() + ")",
                                                                       "1"
                                                                     },
                                                        "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                else
                {
                    slkChangeShift.Properties.ValueMember = "ID";
                    slkChangeShift.Properties.DisplayMember = "FullName";
                    slkChangeShift.Properties.DataSource = dtEmployees;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }           
        }

        private void pageManagement_groupSalaryManagement_TimekeepingOther_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ",
                                                        new string[] { "StatusID", "ID", "TimekeepingOther" },
                                                        new string[] { "=", "<>", "=" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(), ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString(), "1" },
                                                        "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                else
                {
                    AttendanceData_EmployeeID.Properties.ValueMember = "ID";
                    AttendanceData_EmployeeID.Properties.DisplayMember = "FullName";
                    AttendanceData_EmployeeID.Properties.DataSource = dtEmployees;
                }

                Populate_LookUpEdit(AttendanceData_RecordTypeID, "AttendanceData_RecordType");
                LoadChangeShift(callFrom);

                _dtAttendanceData = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref _dtAttendanceData, "AttendanceData", new string[] { "ID" }, new string[] { "0" }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                DataRow _drMaterials = _dtAttendanceData.NewRow();
                _drMaterials["StatusID"] = (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương;
                _dtAttendanceData.Rows.Add(_drMaterials);

                Utilities.Multi.AssignData_RowToForm(_dtAttendanceData.Rows[0], this, callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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

                if (chkChangeShift.Checked)
                    if (slkChangeShift.EditValue == null || slkChangeShift.EditValue.ToString() == "")
                        return "Vui lòng nhập nhân viên đổi ca.";

                if (AttendanceData_AttendanceTime.DateTime.Year != DateTime.Now.Year ||
                    AttendanceData_AttendanceTime.DateTime.Month != DateTime.Now.Month ||
                    AttendanceData_AttendanceTime.DateTime.Day != DateTime.Now.Day)
                    return "Chỉ được chấm công hộ trong ngày hiện tại (" + DateTime.Now.ToString("dd/MM/yyyy") + ")!!!";

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        private bool CheckRecordExistToInsert(string CallBy, DateTime DateToCheck, string EmployeeID, string RecordTypeID, ref bool IsConfirm)
        {
            IsConfirm = false;

            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            DateTime vFrom = new DateTime(DateToCheck.Year, DateToCheck.Month, DateToCheck.Day, 0, 0, 0);
            DateTime vTo = new DateTime(DateToCheck.Year, DateToCheck.Month, DateToCheck.Day, 23, 59, 59);

            DataTable vdtAttendanceData = new DataTable();
            string vResult = bGeneral.GetByCondition(callFrom, ref vdtAttendanceData, "AttendanceData",
                                                    new string[] { "EmployeeID", "AttendanceTime", "AttendanceTime", "RecordTypeID", "StatusID" },
                                                    new string[] { "=", ">=", "<=", "=", "<>" },
                                                    new string[] { EmployeeID,
                                                                   "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                   "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                   RecordTypeID.ToString(),
                                                                   ((int)Utilities.CategoriesEnum.AttendanceData_Status.Đã_hủy).ToString()},
                                                    "");
            if (vResult != Utilities.Parameters.ResultMessage)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n GetByCondition -> " + vResult);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult);
                return false;
            }

            if (vdtAttendanceData == null || vdtAttendanceData.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                string msg = "Đã có dữ liệu chấm công GIỜ VÀO ngày " + DateToCheck.ToString("dd/MM/yyyy") + ".\nBạn vẫn muốn thêm dữ liệu chấm công?";
                if (int.Parse(RecordTypeID) == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_ra)
                    msg = "Đã có dữ liệu chấm công GIỜ RA ngày " + DateToCheck.ToString("dd/MM/yyyy") + ".\nBạn vẫn muốn thêm dữ liệu chấm công?";

                IsConfirm = true;
                if (Utilities.Functions.MessageBoxYesNo(msg) == DialogResult.Yes)
                    return true;
                else
                    return false;

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

                bool IsConfirm = false;
                if (!CheckRecordExistToInsert(callFrom, 
                                              AttendanceData_AttendanceTime.DateTime,
                                              AttendanceData_EmployeeID.EditValue.ToString(),
                                              AttendanceData_RecordTypeID.EditValue.ToString(),
                                              ref IsConfirm))
                    return;

                if (!IsConfirm)
                    if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                        return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(_dtAttendanceData.Rows[0], this, callFrom);

                _dtAttendanceData.Rows[0]["CreatedDate"] = DateTime.Now;
                _dtAttendanceData.Rows[0]["CreatedBy"] = Utilities.Parameters.UserLogin.UserID;
                _dtAttendanceData.Rows[0]["AttendanceTime"] = new DateTime(AttendanceData_AttendanceTime.DateTime.Year,
                                                                           AttendanceData_AttendanceTime.DateTime.Month,
                                                                           AttendanceData_AttendanceTime.DateTime.Day,
                                                                           AttendanceData_AttendanceTime.DateTime.Hour,
                                                                           AttendanceData_AttendanceTime.DateTime.Minute,
                                                                           0);
                _dtAttendanceData.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương;

                _dtAttendanceData.Rows[0]["EmployeeID_ChangeShift"] = DBNull.Value;
                if (chkChangeShift.Checked)
                    if (slkChangeShift.EditValue != null && slkChangeShift.EditValue.ToString() != "")
                        _dtAttendanceData.Rows[0]["EmployeeID_ChangeShift"] = slkChangeShift.EditValue;

                _dtAttendanceData.AcceptChanges();

                string result = bGeneral.Insert(callFrom, ref _dtAttendanceData, true);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    return;
                }
                else
                {
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

        private void slkEmployee_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void AttendanceData_EmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            LoadChangeShift(callFrom);
        }

        private void chkChangeShift_CheckedChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            LoadChangeShift(callFrom);

            slkChangeShift.EditValue = null;
            if (chkChangeShift.Checked)
                slkChangeShift.ReadOnly = false;
            else
                slkChangeShift.ReadOnly = true;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void AttendanceData_RecordTypeID_EditValueChanged(object sender, EventArgs e)
        {
            if (AttendanceData_RecordTypeID.EditValue == null || AttendanceData_RecordTypeID.EditValue.ToString() == "")
                return;

            if (int.Parse(AttendanceData_RecordTypeID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào)
            {
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                chkChangeShift.Checked = false;
                slkChangeShift.EditValue = null;
            }
        }
    }
}