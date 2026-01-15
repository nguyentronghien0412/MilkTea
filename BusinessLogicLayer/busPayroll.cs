using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busPayroll
    {
        /// <summary>
        /// Lấy danh sách người tạo Bảng lương
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="CreatedDateFrom">Ngày lập: Từ ngày</param>
        /// <param name="CreatedDateTo">Ngày lập: Đến ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListOfCreatedBy(string CallBy, ref DataTable dtResult,
            DateTime CreatedDateFrom, DateTime CreatedDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(CreatedDateFrom.Year, CreatedDateFrom.Month, CreatedDateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(CreatedDateTo.Year, CreatedDateTo.Month, CreatedDateTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.GetListOfCreatedBy(callFrom, ref dtResult, vFrom, vTo);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên có dữ liệu lương theo khoảng thời gian
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="CreatedDateFrom">Ngày lập: Từ ngày</param>
        /// <param name="CreatedDateTo">Ngày lập: Đến ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListOfEmployees(string CallBy, ref DataTable dtResult,
            DateTime CreatedDateFrom, DateTime CreatedDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(CreatedDateFrom.Year, CreatedDateFrom.Month, CreatedDateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(CreatedDateTo.Year, CreatedDateTo.Month, CreatedDateTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.GetListOfEmployees(callFrom, ref dtResult, vFrom, vTo);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên có dữ liệu chấm công theo khoảng thời gian
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="AttendanceTimeFrom">Từ ngày</param>
        /// <param name="AttendanceTimeTo">Đến ngày</param>
        /// <param name="StatusID">Mã trạng thái dữ liệu chấm công</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string AttendanceData_GetListOfEmployees(string CallBy, ref DataTable dtResult,
            DateTime AttendanceTimeFrom, DateTime AttendanceTimeTo, int StatusID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(AttendanceTimeFrom.Year, AttendanceTimeFrom.Month, AttendanceTimeFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(AttendanceTimeTo.Year, AttendanceTimeTo.Month, AttendanceTimeTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.AttendanceData_GetListOfEmployees(callFrom, ref dtResult, vFrom, vTo, StatusID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thêm Bảng lương
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtPayroll">Thông tin bảng lương, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtPayrollDetail">Thông tin chi tiết bảng lương, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtAttendanceData">Dữ liệu chấm công, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtOvertime">Dữ liệu tăng ca, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtPayroll, ref DataTable dtPayrollDetail, ref DataTable dtAttendanceData, ref DataTable dtOvertime)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Insert(callFrom, ref dtPayroll, ref dtPayrollDetail, ref dtAttendanceData, ref dtOvertime);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Xóa Bảng lương
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="PayrollID">Mã bảng lương</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Delete(string CallBy, string PayrollID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Delete(callFrom, PayrollID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thanh toán lương
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtPayroll">Thông tin bảng lương, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Payment(string CallBy, DataTable dtPayroll)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Payment(callFrom, dtPayroll);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Đổi ca làm việc
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="AttendanceDataID">Mã giờ chấm công</param>
        /// <param name="EmployeeID_ChangeShift">Nhân viên được đổi ca</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string ChangeShift(string CallBy, string AttendanceDataID, string EmployeeID_ChangeShift)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.ChangeShift(callFrom, AttendanceDataID, EmployeeID_ChangeShift);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên có dữ liệu tăng ca theo khoảng thời gian
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="WorkingDateFrom">Ngày tăng ca: Từ ngày</param>
        /// <param name="WorkingDateTo">Ngày tăng ca: Đến ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Overtime_GetListOfEmployees(string CallBy, ref DataTable dtResult,
            DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(WorkingDateFrom.Year, WorkingDateFrom.Month, WorkingDateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(WorkingDateTo.Year, WorkingDateTo.Month, WorkingDateTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Overtime_GetListOfEmployees(callFrom, ref dtResult, vFrom, vTo);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách người tạo Tăng ca
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="WorkingDateFrom">Ngày lập: Từ ngày</param>
        /// <param name="WorkingDateTo">Ngày lập: Đến ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Overtime_GetListOfCreatedBy(string CallBy, ref DataTable dtResult,
            DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(WorkingDateFrom.Year, WorkingDateFrom.Month, WorkingDateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(WorkingDateTo.Year, WorkingDateTo.Month, WorkingDateTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Overtime_GetListOfCreatedBy(callFrom, ref dtResult, vFrom, vTo);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách người duyệt Tăng ca
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="WorkingDateFrom">Ngày lập: Từ ngày</param>
        /// <param name="WorkingDateTo">Ngày lập: Đến ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Overtime_GetListOfApprovedBy(string CallBy, ref DataTable dtResult,
            DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime vFrom = new DateTime(WorkingDateFrom.Year, WorkingDateFrom.Month, WorkingDateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(WorkingDateTo.Year, WorkingDateTo.Month, WorkingDateTo.Day, 23, 59, 59);

                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Overtime_GetListOfApprovedBy(callFrom, ref dtResult, vFrom, vTo);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Xóa tăng ca
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="OvertimeID">Mã dữ liệu tăng ca</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Overtime_Delete(string CallBy, string OvertimeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPayroll dPayroll = new daoPayroll();
                return dPayroll.Overtime_Delete(callFrom, OvertimeID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
