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
    public partial class pageManagement_groupSalaryManagement_Payroll_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string _PayrollID = "";
        public DataTable _dtPayroll = null;
        public DataTable _dtAttendanceData = null;
        public DataTable _dtPayrollDetail = null;
        public DataTable _dtOvertime = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busPayroll bPayroll = new BusinessLogicLayer.busPayroll();

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

        private void CalcTotalDays()
        {
            txtTotalDays.Text = "";
            if (Payroll_DateFrom.Text != "" && Payroll_DateTo.Text != "")
            {
                DateTime vFrom = new DateTime(Payroll_DateFrom.DateTime.Year, Payroll_DateFrom.DateTime.Month, Payroll_DateFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(Payroll_DateTo.DateTime.Year, Payroll_DateTo.DateTime.Month, Payroll_DateTo.DateTime.Day, 0, 0, 0);
                TimeSpan vTS = vTo - vFrom;
                txtTotalDays.Text = (vTS.TotalDays + 1).ToString("n0");
            }
        }

        private void GetListOfEmployees(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Payroll_EmployeeID.Properties.DataSource = null;

                DataTable vdtEmployees = new DataTable();
                string vResult = bPayroll.AttendanceData_GetListOfEmployees(callFrom, ref vdtEmployees,
                                                                                 Payroll_DateFrom.DateTime,
                                                                                 Payroll_DateTo.DateTime,
                                                                                 (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> AttendanceData_GetListOfEmployees:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> AttendanceData_GetListOfEmployees");
                }
                else
                {
                    Payroll_EmployeeID.Properties.ValueMember = "ID";
                    Payroll_EmployeeID.Properties.DisplayMember = "FullName";
                    Payroll_EmployeeID.Properties.DataSource = vdtEmployees;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListOfEmployees_View(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Payroll_EmployeeID.Properties.DataSource = null;

                BusinessLogicLayer.busEmployees bEmployees = new BusinessLogicLayer.busEmployees();
                DataTable vdtEmployees = new DataTable();
                string vResult = bEmployees.GetAll(callFrom, ref vdtEmployees);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition");
                }
                else
                {
                    Payroll_EmployeeID.Properties.ValueMember = "ID";
                    Payroll_EmployeeID.Properties.DisplayMember = "FullName";
                    Payroll_EmployeeID.Properties.DataSource = vdtEmployees;
                }
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

                if (bgvPayrollDetail.RowCount == 0)
                    return "Không có dữ liệu chi tiết của Bảng lương";

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        private void LoadAttendanceData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcAttendanceData.DataSource = null;

                if (Payroll_DateFrom.Text == "" || Payroll_DateTo.Text == "" || 
                    Payroll_EmployeeID.EditValue == null || Payroll_EmployeeID.EditValue.ToString() == "")
                    return;

                DateTime vFrom = new DateTime(Payroll_DateFrom.DateTime.Year, Payroll_DateFrom.DateTime.Month, Payroll_DateFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(Payroll_DateTo.DateTime.Year, Payroll_DateTo.DateTime.Month, Payroll_DateTo.DateTime.Day, 23, 59, 59);
                string vStatus = ((int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương).ToString();
                string vEmployeeID = Payroll_EmployeeID.EditValue.ToString();

                _dtAttendanceData = new DataTable();
                string[] varrFields = new string[] { "AttendanceTime", "AttendanceTime", "StatusID", "EmployeeID" };
                string[] varrOpers = new string[] { ">=", "<=", "=", "=" };
                string[] varrValue = new string[] { "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    vStatus, vEmployeeID };

                string result = bGeneral.GetByCondition(callFrom, ref _dtAttendanceData, "AttendanceData", varrFields, varrOpers, varrValue, "EmployeeID ASC, AttendanceTime ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return;
                }

                gcAttendanceData.DataSource = _dtAttendanceData;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckValidAttendanceData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvAttendanceData.RowCount == 0)
                    return "Không thể tạo Bảng lương. Vì không có dữ liệu chấm công.";

                for (int i = 0; i < gvAttendanceData.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (int.Parse(gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colRecordTypeID).ToString()) != (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào)
                        {
                            gvAttendanceData.FocusedRowHandle = i;
                            gvAttendanceData.SelectRow(i);
                            return "Dữ liệu chấm công không hợp lệ tại dòng thứ " + (i + 1);
                        }
                    }
                    else
                    {
                        if (int.Parse(gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colRecordTypeID).ToString()) != (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_ra)
                        {
                            gvAttendanceData.FocusedRowHandle = i;
                            gvAttendanceData.SelectRow(i);
                            return "Dữ liệu chấm công không hợp lệ tại dòng thứ " + (i + 1);
                        }
                    }
                }

                if (int.Parse(gvAttendanceData.GetRowCellValue(gvAttendanceData.RowCount - 1, gvAttendanceData_colRecordTypeID).ToString()) != (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_ra)
                {
                    gvAttendanceData.FocusedRowHandle = gvAttendanceData.RowCount - 1;
                    gvAttendanceData.SelectRow(gvAttendanceData.RowCount - 1);
                    return "Dữ liệu chấm công không hợp lệ tại dòng thứ " + (gvAttendanceData.RowCount);
                }

                for (int i = 0; i < gvAttendanceData.RowCount; i += 2)
                {
                    DateTime vFrom = DateTime.Parse(gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colAttendanceTime).ToString());
                    DateTime vTo = DateTime.Parse(gvAttendanceData.GetRowCellValue(i + 1, gvAttendanceData_colAttendanceTime).ToString());
                    if (vFrom.Year != vTo.Year || vFrom.Month != vTo.Month || vFrom.Day != vTo.Day)
                    {
                        gvAttendanceData.FocusedRowHandle = i;
                        gvAttendanceData.SelectRow(i);
                        return "Dữ liệu chấm công không hợp lệ tại dòng thứ " + (i + 2) + "\nGiờ vào và giờ ra phải cùng 1 ngày.";
                    }

                    if (gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift) == null ||
                        gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift).ToString() == "")
                    {
                        DateTime vShiftFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, Payroll_ShiftFrom.DateTime.Hour, Payroll_ShiftFrom.DateTime.Minute, 0);
                        DateTime vShiftTo = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, Payroll_ShiftTo.DateTime.Hour, Payroll_ShiftTo.DateTime.Minute, 0);
                        if (vFrom >= vShiftTo || vTo <= vShiftFrom)
                        {
                            gvAttendanceData.FocusedRowHandle = i;
                            gvAttendanceData.SelectRow(i);
                            return "Giờ chấm công tại dòng thứ " + (i + 1) + "(" + vFrom.ToString("dd/MM/yyyy") + ") \nkhông nằm trong khung giờ của ca làm việc.";
                        }

                        TimeSpan vTS = vShiftTo - vFrom;
                        TimeSpan vTS2 = vTo - vShiftFrom;
                        if (vTS.TotalMinutes < 30 || vTS2.TotalMinutes < 30)
                        {
                            gvAttendanceData.FocusedRowHandle = i;
                            gvAttendanceData.SelectRow(i);
                            return "Giờ chấm công tại dòng thứ " + (i + 1) + "(" + vFrom.ToString("dd/MM/yyyy") + ") \nkhông nằm trong khung giờ của ca làm việc.";
                        }
                    }
                    else
                    {
                        DataTable vdtEmployees = new DataTable();
                        string vResult = bGeneral.GetByCondition(callFrom, ref vdtEmployees, "Employees",
                                                                 new string[] { "ID" }, 
                                                                 new string[] { gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift).ToString() }, "");
                        if (vResult != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Employees:\n" + vResult);
                            return vResult;
                        }
                        else
                        {
                            if (vdtEmployees.Rows[0]["ShiftFrom"].ToString() == "" || vdtEmployees.Rows[0]["ShiftTo"].ToString() == "")
                            {
                                gvAttendanceData.FocusedRowHandle = i;
                                gvAttendanceData.SelectRow(i);
                                return "Dữ liệu chấm công không hợp lệ tại dòng thứ " + (i + 1) + "\nNhân viên đổi ca không có giờ làm việc.";
                            }
                            else
                            {
                                DateTime vDateFrom = DateTime.Parse(vdtEmployees.Rows[0]["ShiftFrom"].ToString());
                                DateTime vDateTo = DateTime.Parse(vdtEmployees.Rows[0]["ShiftTo"].ToString());

                                DateTime vShiftFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vDateFrom.Hour, vDateFrom.Minute, 0);
                                DateTime vShiftTo = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vDateTo.Hour, vDateTo.Minute, 0);
                                if (vFrom >= vShiftTo || vTo <= vShiftFrom)
                                {
                                    gvAttendanceData.FocusedRowHandle = i;
                                    gvAttendanceData.SelectRow(i);
                                    return "Giờ chấm công tại dòng thứ " + (i + 1) + "(" + vFrom.ToString("dd/MM/yyyy") + ") \nkhông nằm trong khung giờ ca làm việc của nhân viên được đổi.";
                                }

                                TimeSpan vTS = vShiftTo - vFrom;
                                TimeSpan vTS2 = vTo - vShiftFrom;
                                if (vTS.TotalMinutes <= 60 || vTS2.TotalMinutes <= 60)
                                {
                                    gvAttendanceData.FocusedRowHandle = i;
                                    gvAttendanceData.SelectRow(i);
                                    return "Giờ chấm công tại dòng thứ " + (i + 1) + "(" + vFrom.ToString("dd/MM/yyyy") + ") \nkhông nằm trong khung giờ ca làm việc của nhân viên được đổi.";
                                }
                            }
                        }
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                return ex.Message + "\n" + callFrom;
            }
        }

        private void LoadPayrollDetail(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (_dtPayrollDetail != null && _dtPayrollDetail.Rows.Count > 0)
                    _dtPayrollDetail.Rows.Clear();
                gcPayrollDetail.DataSource = _dtPayrollDetail;

                if (Payroll_DateFrom.Text == "" || Payroll_DateTo.Text == "" || Payroll_EmployeeID.EditValue == null || Payroll_EmployeeID.Text == "")
                    return;

                string vResult = CheckValidAttendanceData(callFrom);
                if (vResult != "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult);
                    return;
                }

                if (Payroll_SalaryByHour.Text == "" || int.Parse(Payroll_SalaryByHour.EditValue.ToString()) == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Nhân viên " + Payroll_EmployeeID.Text + " chưa có MỨC LƯƠNG.");
                    return;
                }

                int vCalcSalaryByMinutes = 0;
                if (Payroll_CalcSalaryByMinutes.Text != "")
                    vCalcSalaryByMinutes = int.Parse(Payroll_CalcSalaryByMinutes.Text);

                bool vFlagDisplayBreakTime = false;
                for (int i = 0; i < gvAttendanceData.RowCount; i += 2)
                {
                    DateTime vFrom = DateTime.Parse(gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colAttendanceTime).ToString());
                    vFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vFrom.Hour, vFrom.Minute, 0);

                    DateTime vTo = DateTime.Parse(gvAttendanceData.GetRowCellValue(i + 1, gvAttendanceData_colAttendanceTime).ToString());
                    vTo = new DateTime(vTo.Year, vTo.Month, vTo.Day, vTo.Hour, vTo.Minute, 0);

                    DateTime vShiftFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, Payroll_ShiftFrom.DateTime.Hour, Payroll_ShiftFrom.DateTime.Minute, 0);
                    DateTime vShiftTo = new DateTime(vTo.Year, vTo.Month, vTo.Day, Payroll_ShiftTo.DateTime.Hour, Payroll_ShiftTo.DateTime.Minute, 0);

                    DateTime vBreakTimeFrom = Payroll_BreakTimeFrom.DateTime;
                    DateTime vBreakTimeTo = Payroll_BreakTimeTo.DateTime;
                    bool vIsBreakTime = Payroll_IsBreakTime.Checked;
                    if (vIsBreakTime)
                    {
                        vBreakTimeFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, Payroll_BreakTimeFrom.DateTime.Hour, Payroll_BreakTimeFrom.DateTime.Minute, 0);
                        vBreakTimeTo = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, Payroll_BreakTimeTo.DateTime.Hour, Payroll_BreakTimeTo.DateTime.Minute, 0);
                        vFlagDisplayBreakTime = true;
                    }

                    if (gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift) != null &&
                        gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift).ToString() != "")
                    {
                        #region

                        DataTable vdtEmployees = new DataTable();
                        vResult = bGeneral.GetByCondition(callFrom, ref vdtEmployees, "Employees",
                                                         new string[] { "ID" },
                                                         new string[] { gvAttendanceData.GetRowCellValue(i, gvAttendanceData_colEmployeeID_ChangeShift).ToString() }, "");
                        if (vResult != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Employees:\n" + vResult);
                            Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult);
                            return;
                        }
                        if (vdtEmployees.Rows[0]["ShiftFrom"].ToString() != "" && vdtEmployees.Rows[0]["ShiftTo"].ToString() != "")
                        {
                            DateTime vShiftFromTemp = DateTime.Parse(vdtEmployees.Rows[0]["ShiftFrom"].ToString());
                            vShiftFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vShiftFromTemp.Hour, vShiftFromTemp.Minute, 0);

                            DateTime vShiftToTemp = DateTime.Parse(vdtEmployees.Rows[0]["ShiftTo"].ToString());
                            vShiftTo = new DateTime(vTo.Year, vTo.Month, vTo.Day, vShiftToTemp.Hour, vShiftToTemp.Minute, 0);
                        }

                        vIsBreakTime = false;
                        if (vdtEmployees.Rows[0]["IsBreakTime"].ToString() != "")
                            vIsBreakTime = bool.Parse(vdtEmployees.Rows[0]["IsBreakTime"].ToString());

                        if (vIsBreakTime)
                        {
                            DateTime vBreakTimeFromTemp = DateTime.Parse(vdtEmployees.Rows[0]["BreakTimeFrom"].ToString());
                            vBreakTimeFrom = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vBreakTimeFromTemp.Hour, vBreakTimeFromTemp.Minute, 0);

                            DateTime vBreakTimeToTemp = DateTime.Parse(vdtEmployees.Rows[0]["BreakTimeTo"].ToString());
                            vBreakTimeTo = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, vBreakTimeToTemp.Hour, vBreakTimeToTemp.Minute, 0);
                        
                            vFlagDisplayBreakTime = true;
                        }

                        #endregion
                    }

                    if (vFrom < vShiftFrom)
                        vFrom = vShiftFrom;

                    if (vTo > vShiftTo)
                        vTo = vShiftTo;

                    TimeSpan ts;

                    if (vIsBreakTime)
                    {
                        if (vBreakTimeFrom <= vFrom)
                        {
                            if (vBreakTimeTo <= vFrom)
                                ts = vTo - vFrom;
                            else if (vBreakTimeTo > vFrom && vBreakTimeTo < vTo)
                                ts = vTo - vBreakTimeTo;
                            else
                                ts = vTo - vTo;
                        }
                        else if (vBreakTimeFrom > vFrom && vBreakTimeFrom < vTo)
                        {
                            if (vBreakTimeTo < vTo)
                                ts = (vBreakTimeFrom - vFrom) + (vTo - vBreakTimeTo);
                            else
                                ts = vBreakTimeFrom - vFrom;
                        }
                        else
                            ts = vTo - vFrom;
                    }
                    else
                        ts = vTo - vFrom;

                    DataRow dr = _dtPayrollDetail.NewRow();

                    dr["WorkingDate"] = new DateTime(vFrom.Year, vFrom.Month, vFrom.Day, 0, 0, 0);
                    dr["WorkingDate_In"] = vFrom;
                    dr["WorkingDate_Out"] = vTo;

                    if (vIsBreakTime)
                    {
                        dr["WorkingDate_BreakTimeFrom"] = vBreakTimeFrom;
                        dr["WorkingDate_BreakTimeTo"] = vBreakTimeTo;
                    }

                    dr["WorkingDate_TotalHours"] = ts.Hours;

                    if (vCalcSalaryByMinutes == 0)
                        dr["WorkingDate_TotalMinutes"] = ts.Minutes;
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            dr["WorkingDate_TotalMinutes"] = 0;
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            dr["WorkingDate_TotalMinutes"] = vTimes * vCalcSalaryByMinutes;
                        }
                    }

                    dr["SalaryByHour"] = Payroll_SalaryByHour.EditValue;

                    decimal vSalaryByMinute = decimal.Parse(dr["SalaryByHour"].ToString()) / 60;
                    decimal vTotalHours = decimal.Parse(dr["WorkingDate_TotalHours"].ToString());
                    decimal vTotalMinutes = decimal.Parse(dr["WorkingDate_TotalMinutes"].ToString());

                    dr["Total"] = ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute;

                    _dtPayrollDetail.Rows.Add(dr);
                }

                gcPayrollDetail.DataSource = _dtPayrollDetail;
                if (vFlagDisplayBreakTime)
                    gbBreakTime.Visible = true;
                else
                    gbBreakTime.Visible = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void LoadOvertime(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gcOvertime.DataSource = null;

                if (Payroll_DateFrom.Text == "" || Payroll_DateTo.Text == "" ||
                    Payroll_EmployeeID.EditValue == null || Payroll_EmployeeID.EditValue.ToString() == "")
                    return;

                DateTime vFrom = new DateTime(Payroll_DateFrom.DateTime.Year, Payroll_DateFrom.DateTime.Month, Payroll_DateFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(Payroll_DateTo.DateTime.Year, Payroll_DateTo.DateTime.Month, Payroll_DateTo.DateTime.Day, 23, 59, 59);
                string vStatus = ((int)Utilities.CategoriesEnum.Overtime_Status.Đã_duyệt).ToString();
                string vEmployeeID = Payroll_EmployeeID.EditValue.ToString();

                _dtOvertime = new DataTable();
                string[] varrFields = new string[] { "WorkingDate", "WorkingDate", "StatusID", "EmployeeID" };
                string[] varrOpers = new string[] { ">=", "<=", "=", "=" };
                string[] varrValue = new string[] { "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    vStatus, vEmployeeID };

                string result = bGeneral.GetByCondition(callFrom, ref _dtOvertime, "Overtime", varrFields, varrOpers, varrValue, "EmployeeID ASC, WorkingDate_In ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Overtime:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition Overtime");
                    return;
                }

                int vCalcSalaryByMinutes = 0;
                if (Payroll_CalcSalaryByMinutes.Text != "")
                    vCalcSalaryByMinutes = int.Parse(Payroll_CalcSalaryByMinutes.Text);

                foreach (DataRow dr in _dtOvertime.Rows)
                {
                    DateTime vWorkingDate_In = DateTime.Parse(dr["WorkingDate_In"].ToString());
                    vWorkingDate_In = new DateTime(vWorkingDate_In.Year, vWorkingDate_In.Month, vWorkingDate_In.Day, vWorkingDate_In.Hour, vWorkingDate_In.Minute, 0);

                    DateTime vWorkingDate_Out = DateTime.Parse(dr["WorkingDate_Out"].ToString());
                    vWorkingDate_Out = new DateTime(vWorkingDate_Out.Year, vWorkingDate_Out.Month, vWorkingDate_Out.Day, vWorkingDate_Out.Hour, vWorkingDate_Out.Minute, 0);

                    TimeSpan ts = vWorkingDate_Out - vWorkingDate_In;

                    dr["WorkingDate_In"] = vWorkingDate_In;
                    dr["WorkingDate_Out"] = vWorkingDate_Out;
                    dr["WorkingDate_TotalHours"] = ts.Hours;

                    if (vCalcSalaryByMinutes == 0)
                        dr["WorkingDate_TotalMinutes"] = ts.Minutes;
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            dr["WorkingDate_TotalMinutes"] = 0;
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            dr["WorkingDate_TotalMinutes"] = vTimes * vCalcSalaryByMinutes;
                        }
                    }

                    dr["SalaryByHour"] = Payroll_SalaryByHour.EditValue;

                    decimal vSalaryByMinute = decimal.Parse(dr["SalaryByHour"].ToString()) / 60;
                    decimal vTotalHours = decimal.Parse(dr["WorkingDate_TotalHours"].ToString());
                    decimal vTotalMinutes = decimal.Parse(dr["WorkingDate_TotalMinutes"].ToString());

                    dr["Total"] = ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute;
                }

                gcOvertime.DataSource = _dtOvertime;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void CalcSalaryAmount(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                decimal vTotalSalary_Overtime = 0;
                decimal vTotalSalary_WokingDay = 0;
                decimal vTotalSalary = 0;

                for (int i = 0; i < bgvPayrollDetail.RowCount; i++)
                    if (bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colTotal) != null &&
                        bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colTotal).ToString() != "")
                        vTotalSalary_WokingDay = vTotalSalary_WokingDay + decimal.Parse(bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colTotal).ToString());

                for (int i = 0; i < gvOvertime.RowCount; i++)
                    if (gvOvertime.GetRowCellValue(i, gvOvertime_colTotal) != null &&
                        gvOvertime.GetRowCellValue(i, gvOvertime_colTotal).ToString() != "")
                        vTotalSalary_Overtime = vTotalSalary_Overtime + decimal.Parse(gvOvertime.GetRowCellValue(i, gvOvertime_colTotal).ToString());

                vTotalSalary = vTotalSalary_Overtime + vTotalSalary_WokingDay;

                Payroll_TotalSalary_WokingDay.Text = vTotalSalary_WokingDay.ToString("n0");
                Payroll_TotalSalary_Overtime.Text = vTotalSalary_Overtime.ToString("n0");
                Payroll_TotalSalary.Text = vTotalSalary.ToString("n0");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageManagement_groupSalaryManagement_Payroll_Edit()
        {
            InitializeComponent();
        }

        private void Payroll_EmployeeID_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvAttendanceData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void Payroll_CreatedBy_slk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void Payroll_DateFrom_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            CalcTotalDays();

            if (int.Parse(_PayrollID) == 0)
            {
                GetListOfEmployees(callFrom);
                LoadAttendanceData(callFrom);
                LoadPayrollDetail(callFrom);
                LoadOvertime(callFrom);
                CalcSalaryAmount(callFrom);
            }
            else
            {
                GetListOfEmployees_View(callFrom);                
            }
        }

        private void Payroll_DateTo_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            CalcTotalDays();

            if (int.Parse(_PayrollID) == 0)
            {
                GetListOfEmployees(callFrom);
                LoadAttendanceData(callFrom);
                LoadPayrollDetail(callFrom);
                LoadOvertime(callFrom);
                CalcSalaryAmount(callFrom);
            }
            else
            {
                GetListOfEmployees_View(callFrom);
            }
        }

        private void Payroll_EmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            Payroll_SalaryByHour.Text = "";
            Payroll_CalcSalaryByMinutes.Text = "";
            lcCalcSalaryByMinutes1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcCalcSalaryByMinutes2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            if (Payroll_EmployeeID.EditValue == null || Payroll_EmployeeID.EditValue.ToString() == "")
                return;

            if (int.Parse(_PayrollID) == 0)
            {
                DataTable vdtEmployees = new DataTable();
                string vResult = bGeneral.GetByCondition(callFrom, ref vdtEmployees, "Employees",
                                                         new string[] { "ID" }, new string[] { Payroll_EmployeeID.EditValue.ToString() }, "");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition");
                }
                else
                {
                    if (vdtEmployees.Rows[0]["SalaryByHour"].ToString() != "")
                    {
                        Payroll_SalaryByHour.EditValue = vdtEmployees.Rows[0]["SalaryByHour"];
                        Payroll_ShiftFrom.EditValue = vdtEmployees.Rows[0]["ShiftFrom"];
                        Payroll_ShiftTo.EditValue = vdtEmployees.Rows[0]["ShiftTo"];
                        Payroll_CalcSalaryByMinutes.EditValue = vdtEmployees.Rows[0]["CalcSalaryByMinutes"];

                        if (vdtEmployees.Rows[0]["IsBreakTime"].ToString() != "")
                            Payroll_IsBreakTime.EditValue = vdtEmployees.Rows[0]["IsBreakTime"];
                        else
                            Payroll_IsBreakTime.EditValue = false;

                        if (Payroll_IsBreakTime.Checked)
                        {
                            Payroll_BreakTimeFrom.EditValue = vdtEmployees.Rows[0]["BreakTimeFrom"];
                            Payroll_BreakTimeTo.EditValue = vdtEmployees.Rows[0]["BreakTimeTo"];
                        }
                        else
                        {
                            Payroll_BreakTimeFrom.EditValue = null;
                            Payroll_BreakTimeTo.EditValue = null;
                        }

                        if (vdtEmployees.Rows[0]["CalcSalaryByMinutes"].ToString() != "" &&
                            int.Parse(vdtEmployees.Rows[0]["CalcSalaryByMinutes"].ToString()) > 0)
                        {
                            lcCalcSalaryByMinutes1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            lcCalcSalaryByMinutes2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }
                    }
                }

                LoadAttendanceData(callFrom);
                LoadPayrollDetail(callFrom);
                LoadOvertime(callFrom);
                CalcSalaryAmount(callFrom);
            }
        }
        
        private void pageManagement_groupSalaryManagement_Payroll_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (_PayrollID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Bảng lương.");
                    return;
                }

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
                    gvAttendanceData_colEmployeeID_ChangeShift_lk.ValueMember = "ID";
                    gvAttendanceData_colEmployeeID_ChangeShift_lk.DisplayMember = "FullName";
                    gvAttendanceData_colEmployeeID_ChangeShift_lk.DataSource = dtEmployees;
                }

                #endregion

                #region User

                DataTable dtUsers = new DataTable();
                BusinessLogicLayer.busUsers bUsers = new BusinessLogicLayer.busUsers();
                vResult = bUsers.GetAll(callFrom, ref dtUsers);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> bUsers -> GetAll:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> bUsers -> GetAll");
                }
                else
                {
                    Payroll_CreatedBy.Properties.ValueMember = "ID";
                    Payroll_CreatedBy.Properties.DisplayMember = "Name";
                    Payroll_CreatedBy.Properties.DataSource = dtUsers;

                    gvAttendanceData_colCreatedBy_lk.ValueMember = "ID";
                    gvAttendanceData_colCreatedBy_lk.DisplayMember = "Name";
                    gvAttendanceData_colCreatedBy_lk.DataSource = dtUsers;
                }

                #endregion

                #region _dtPayroll

                _dtPayroll = new DataTable();
                vResult = bGeneral.GetByCondition(callFrom, ref _dtPayroll, "Payroll", new string[] { "ID" }, new string[] { _PayrollID }, null);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Payroll:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition Payroll");
                    this.Close();
                }

                #endregion

                #region _dtPayrollDetail

                _dtPayrollDetail = new DataTable();
                vResult = bGeneral.GetByCondition(callFrom, ref _dtPayrollDetail, "PayrollDetail", new string[] { "PayrollID" }, new string[] { _PayrollID }, "WorkingDate ASC, WorkingDate_In ASC");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition PayrollDetail:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition PayrollDetail");
                    this.Close();
                }

                #endregion

                #region _dtAttendanceData

                _dtAttendanceData = new DataTable();
                vResult = bGeneral.GetByCondition(callFrom, ref _dtAttendanceData, "AttendanceData", new string[] { "PayrollID" }, new string[] { _PayrollID }, "AttendanceTime ASC");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition AttendanceData:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition AttendanceData");
                    this.Close();
                }

                #endregion

                #region _dtOvertime

                _dtOvertime = new DataTable();
                vResult = bGeneral.GetByCondition(callFrom, ref _dtOvertime, "Overtime", new string[] { "PayrollID" }, new string[] { _PayrollID }, "WorkingDate ASC, WorkingDate_In ASC");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Overtime:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition Overtime");
                    this.Close();
                }

                #endregion

                layoutControlItem_Payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                if (int.Parse(_PayrollID) == 0)
                {
                    DateTime vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    DateTime vTo = vFrom.AddMonths(1);
                    vTo = vTo.AddDays(-1);

                    DataRow _drPayroll = _dtPayroll.NewRow();
                    _drPayroll["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    _drPayroll["CreatedDate"] = DateTime.Now;
                    _drPayroll["DateFrom"] = vFrom;
                    _drPayroll["DateTo"] = vTo;
                    _drPayroll["StatusID"] = (int)Utilities.CategoriesEnum.Payroll_Status.Chưa_thanh_toán;
                    _dtPayroll.Rows.Add(_drPayroll);

                    this.Text = "Tạo Bảng lương";

                    pnChangeShift.Visible = true;

                    gvPayrollDetail_colWorkingDate_In.OptionsColumn.AllowEdit = true;
                    gvPayrollDetail_colWorkingDate_In.AppearanceCell.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;

                    gvPayrollDetail_colWorkingDate_Out.OptionsColumn.AllowEdit = true;
                    gvPayrollDetail_colWorkingDate_Out.AppearanceCell.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;

                    gvOvertime_colWorkingDate_In.OptionsColumn.AllowEdit = true;
                    gvOvertime_colWorkingDate_In.AppearanceCell.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;

                    gvOvertime_colWorkingDate_Out.OptionsColumn.AllowEdit = true;
                    gvOvertime_colWorkingDate_Out.AppearanceCell.BackColor = Utilities.Parameters.Definition.COLOR_REQUIRED;
                }
                else
                {
                    Payroll_DateFrom.ReadOnly = true;
                    Payroll_DateTo.ReadOnly = true;
                    Payroll_EmployeeID.ReadOnly = true;
                    btnSave.Enabled = false;

                    this.Text = "Xem Bảng lương";

                    layoutControlItem_Save.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    if (int.Parse(_dtPayroll.Rows[0]["StatusID"].ToString()) == (int)Utilities.CategoriesEnum.Payroll_Status.Chưa_thanh_toán)
                        if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Payroll", Utilities.Parameters.Permission_PAYMENTED))
                            layoutControlItem_Payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    
                    pnChangeShift.Visible = false;                   
                }

                Utilities.Multi.AssignData_RowToForm(_dtPayroll.Rows[0], this, callFrom);
                Payroll_SalaryByHour.EditValue = _dtPayroll.Rows[0]["SalaryByHour"];
                Payroll_CalcSalaryByMinutes.EditValue = _dtPayroll.Rows[0]["CalcSalaryByMinutes"];

                gcPayrollDetail.DataSource = _dtPayrollDetail;
                gcAttendanceData.DataSource = _dtAttendanceData;
                gcOvertime.DataSource = _dtOvertime;

                bool vFlagDisplayBreakTime = false;
                for (int i = 0; i < bgvPayrollDetail.RowCount; i++)
                {
                    if (bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colWorkingDate_BreakTimeFrom) != null &&
                        bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colWorkingDate_BreakTimeFrom).ToString() != "" &&
                        bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colWorkingDate_BreakTimeTo) != null &&
                        bgvPayrollDetail.GetRowCellValue(i, gvPayrollDetail_colWorkingDate_BreakTimeTo).ToString() != "")
                            vFlagDisplayBreakTime = true;
                }

                if (vFlagDisplayBreakTime)
                    gbBreakTime.Visible = true;
                else
                    gbBreakTime.Visible = false;
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

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu thông tin Bảng lương của " + Payroll_EmployeeID.Text + "?") != DialogResult.Yes)
                    return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(_dtPayroll.Rows[0], this, callFrom);
                _dtPayroll.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.Payroll_Status.Chưa_thanh_toán;
                _dtPayroll.AcceptChanges();
                _dtPayrollDetail.AcceptChanges();
                _dtAttendanceData.AcceptChanges();
                _dtOvertime.AcceptChanges();

                string result = bPayroll.Insert(callFrom, ref _dtPayroll, ref _dtPayrollDetail, ref _dtAttendanceData, ref _dtOvertime);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    return;
                }
                else
                {
                    _PayrollID = _dtPayroll.Rows[0]["ID"].ToString();
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


        #endregion

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Functions.MessageBoxYesNo("Bạn đã thanh toán tiền lương cho " + Payroll_EmployeeID.Text + "?") != DialogResult.Yes)
                    return;

                _dtPayroll.Rows[0]["PaymentedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                _dtPayroll.Rows[0]["PaymentedDate"] = DateTime.Now;
                _dtPayroll.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.Payroll_Status.Đã_thanh_toán;
                _dtPayroll.AcceptChanges();

                string result = bPayroll.Payment(callFrom, _dtPayroll);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Payment:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Payment");
                    return;
                }
                else
                {
                    _PayrollID = _dtPayroll.Rows[0]["ID"].ToString();
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

        private void gvAttendanceData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnChangeShift.Enabled = false;
                if (gvAttendanceData.FocusedRowHandle < 0)
                    return;

                if (gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colRecordTypeID) != null &&
                    gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colRecordTypeID).ToString() != "" &&
                    int.Parse(gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colRecordTypeID).ToString()) == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào)
                {
                    btnChangeShift.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnChangeShift_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvAttendanceData.FocusedRowHandle < 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn giờ làm việc cần đổi.");
                    return;
                }

                if (Payroll_EmployeeID.EditValue == null || Payroll_EmployeeID.EditValue.ToString() == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn nhân viên đổi ca.");
                    return;
                }

                pageManagement_groupSalaryManagement_Payroll_ChangeShift frmChangeShift = new pageManagement_groupSalaryManagement_Payroll_ChangeShift();
                frmChangeShift._EmployeeID = Payroll_EmployeeID.EditValue.ToString();
                DialogResult vdlg = frmChangeShift.ShowDialog();
                if (vdlg == DialogResult.OK && frmChangeShift._EmployeeID_ChangeShift != "")
                {
                    string vID = gvAttendanceData.GetFocusedRowCellValue(gvAttendanceData_colID).ToString();
                    string vResult = bPayroll.ChangeShift(callFrom, vID, frmChangeShift._EmployeeID_ChangeShift);
                    if (vResult != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> ChangeShift:\n" + vResult);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> ChangeShift");
                        return;
                    }
                    else
                    {
                        Payroll_EmployeeID_EditValueChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOvertime_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvOvertime_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOvertime.FocusedRowHandle < 0)
                    return;

                int vCalcSalaryByMinutes = 0;
                if (Payroll_CalcSalaryByMinutes.Text != "")
                    vCalcSalaryByMinutes = int.Parse(Payroll_CalcSalaryByMinutes.Text);

                if (gvOvertime.FocusedColumn == gvOvertime_colWorkingDate_In)
                {
                    #region gvOvertime_colWorkingDate_In

                    if (e.Value == null || e.Value.ToString() == "")
                        return;

                    DateTime vFrom = DateTime.Parse(e.Value.ToString());
                    vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vFrom.Hour, vFrom.Minute, 0);

                    DateTime vTo = DateTime.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_Out).ToString());
                    vTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vTo.Hour, vTo.Minute, 0);

                    TimeSpan ts = vTo - vFrom;

                    gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalHours, ts.Hours);

                    if (vCalcSalaryByMinutes == 0)
                        gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, ts.Minutes);
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, 0);
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, vTimes * vCalcSalaryByMinutes);
                        }
                    }

                    decimal vSalaryByHour = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colSalaryByHour).ToString());
                    decimal vSalaryByMinute = vSalaryByHour / 60;
                    decimal vTotalHours = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalHours).ToString());
                    decimal vTotalMinutes = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes).ToString());

                    gvOvertime.SetFocusedRowCellValue(gvOvertime_colTotal, ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute);

                    #endregion
                }
                else if (gvOvertime.FocusedColumn == gvOvertime_colWorkingDate_Out)
                {
                    #region gvOvertime_colWorkingDate_Out

                    if (e.Value == null || e.Value.ToString() == "")
                        return;

                    DateTime vFrom = DateTime.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_In).ToString());
                    vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vFrom.Hour, vFrom.Minute, 0);

                    DateTime vTo = DateTime.Parse(e.Value.ToString());
                    vTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vTo.Hour, vTo.Minute, 0);

                    TimeSpan ts = vTo - vFrom;

                    gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalHours, ts.Hours);

                    if (vCalcSalaryByMinutes == 0)
                        gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, ts.Minutes);
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, 0);
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            gvOvertime.SetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes, vTimes * vCalcSalaryByMinutes);
                        }
                    }

                    decimal vSalaryByHour = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colSalaryByHour).ToString());
                    decimal vSalaryByMinute = vSalaryByHour / 60;
                    decimal vTotalHours = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalHours).ToString());
                    decimal vTotalMinutes = decimal.Parse(gvOvertime.GetFocusedRowCellValue(gvOvertime_colWorkingDate_TotalMinutes).ToString());

                    gvOvertime.SetFocusedRowCellValue(gvOvertime_colTotal, ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute);

                    #endregion
                }

                CalcSalaryAmount(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void bgvPayrollDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void bgvPayrollDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (bgvPayrollDetail.FocusedRowHandle < 0)
                    return;

                int vCalcSalaryByMinutes = 0;
                if (Payroll_CalcSalaryByMinutes.Text != "")
                    vCalcSalaryByMinutes = int.Parse(Payroll_CalcSalaryByMinutes.Text);

                if (bgvPayrollDetail.FocusedColumn == gvPayrollDetail_colWorkingDate_In)
                {
                    #region gvPayrollDetail_colWorkingDate_In

                    if (e.Value == null || e.Value.ToString() == "")
                        return;

                    DateTime vFrom = DateTime.Parse(e.Value.ToString());
                    vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vFrom.Hour, vFrom.Minute, 0);

                    DateTime vTo = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_Out).ToString());
                    vTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vTo.Hour, vTo.Minute, 0);

                    bool vIsBreakTime = false;
                    if (bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom) != null &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom).ToString() != "" &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo) != null &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo).ToString() != "")
                        vIsBreakTime = true;

                    DateTime vBreakTimeFrom = DateTime.Now;
                    DateTime vBreakTimeTo = DateTime.Now;
                    if (vIsBreakTime)
                    {
                        vBreakTimeFrom = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom).ToString());
                        vBreakTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vBreakTimeFrom.Hour, vBreakTimeFrom.Minute, 0);

                        vBreakTimeTo = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo).ToString());
                        vBreakTimeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vBreakTimeTo.Hour, vBreakTimeTo.Minute, 0);
                    }

                    TimeSpan ts;
                    if (vIsBreakTime)
                    {
                        if (vBreakTimeFrom <= vFrom)
                        {
                            if (vBreakTimeTo <= vFrom)
                                ts = vTo - vFrom;
                            else if (vBreakTimeTo > vFrom && vBreakTimeTo < vTo)
                                ts = vTo - vBreakTimeTo;
                            else
                                ts = vTo - vTo;
                        }
                        else if (vBreakTimeFrom > vFrom && vBreakTimeFrom < vTo)
                        {
                            if (vBreakTimeTo < vTo)
                                ts = (vBreakTimeFrom - vFrom) + (vTo - vBreakTimeTo);
                            else
                                ts = vBreakTimeFrom - vFrom;
                        }
                        else
                            ts = vTo - vFrom;
                    }
                    else
                        ts = vTo - vFrom;

                    bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalHours, ts.Hours);

                    if (vCalcSalaryByMinutes == 0)
                        bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, ts.Minutes);
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, 0);
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, vTimes * vCalcSalaryByMinutes);
                        }
                    }

                    decimal vSalaryByHour = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colSalaryByHour).ToString());
                    decimal vSalaryByMinute = vSalaryByHour / 60;
                    decimal vTotalHours = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalHours).ToString());
                    decimal vTotalMinutes = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes).ToString());

                    bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colTotal, ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute);

                    #endregion
                }
                else if (bgvPayrollDetail.FocusedColumn == gvPayrollDetail_colWorkingDate_Out)
                {
                    #region gvPayrollDetail_colWorkingDate_Out

                    if (e.Value == null || e.Value.ToString() == "")
                        return;

                    DateTime vFrom = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_In).ToString());
                    vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vFrom.Hour, vFrom.Minute, 0);

                    DateTime vTo = DateTime.Parse(e.Value.ToString());
                    vTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vTo.Hour, vTo.Minute, 0);

                    bool vIsBreakTime = false;
                    if (bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom) != null &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom).ToString() != "" &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo) != null &&
                        bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo).ToString() != "")
                        vIsBreakTime = true;

                    DateTime vBreakTimeFrom = DateTime.Now;
                    DateTime vBreakTimeTo = DateTime.Now;
                    if (vIsBreakTime)
                    {
                        vBreakTimeFrom = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeFrom).ToString());
                        vBreakTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vBreakTimeFrom.Hour, vBreakTimeFrom.Minute, 0);

                        vBreakTimeTo = DateTime.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_BreakTimeTo).ToString());
                        vBreakTimeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, vBreakTimeTo.Hour, vBreakTimeTo.Minute, 0);
                    }

                    TimeSpan ts;
                    if (vIsBreakTime)
                    {
                        if (vBreakTimeFrom <= vFrom)
                        {
                            if (vBreakTimeTo <= vFrom)
                                ts = vTo - vFrom;
                            else if (vBreakTimeTo > vFrom && vBreakTimeTo < vTo)
                                ts = vTo - vBreakTimeTo;
                            else
                                ts = vTo - vTo;
                        }
                        else if (vBreakTimeFrom > vFrom && vBreakTimeFrom < vTo)
                        {
                            if (vBreakTimeTo < vTo)
                                ts = (vBreakTimeFrom - vFrom) + (vTo - vBreakTimeTo);
                            else
                                ts = vBreakTimeFrom - vFrom;
                        }
                        else
                            ts = vTo - vFrom;
                    }
                    else
                        ts = vTo - vFrom;

                    bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalHours, ts.Hours);

                    if (vCalcSalaryByMinutes == 0)
                        bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, ts.Minutes);
                    else
                    {
                        if (ts.Minutes < vCalcSalaryByMinutes)
                            bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, 0);
                        else
                        {
                            int vTimes = ts.Minutes / vCalcSalaryByMinutes;
                            bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes, vTimes * vCalcSalaryByMinutes);
                        }
                    }

                    decimal vSalaryByHour = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colSalaryByHour).ToString());
                    decimal vSalaryByMinute = vSalaryByHour / 60;
                    decimal vTotalHours = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalHours).ToString());
                    decimal vTotalMinutes = decimal.Parse(bgvPayrollDetail.GetFocusedRowCellValue(gvPayrollDetail_colWorkingDate_TotalMinutes).ToString());

                    bgvPayrollDetail.SetFocusedRowCellValue(gvPayrollDetail_colTotal, ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute);

                    #endregion
                }

                CalcSalaryAmount(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}