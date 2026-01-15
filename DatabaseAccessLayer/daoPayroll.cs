using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoPayroll
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
                string query = Queries.Payroll_GetListOfCreatedBy(CreatedDateFrom, CreatedDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                string query = Queries.Payroll_GetListOfEmployees(CreatedDateFrom, CreatedDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                string query = Queries.AttendanceData_GetListOfEmployees(AttendanceTimeFrom, AttendanceTimeTo, StatusID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtPayroll, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtPayrollDetail.Rows)
                    dr["PayrollID"] = dtPayroll.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtPayrollDetail, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtAttendanceData.Rows)
                {
                    dr["PayrollID"] = dtPayroll.Rows[0]["ID"];
                    dr["StatusID"] = (int)Utilities.CategoriesEnum.AttendanceData_Status.Đã_tính_lương;
                }

                result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtAttendanceData);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtOvertime.Rows)
                {
                    dr["PayrollID"] = dtPayroll.Rows[0]["ID"];
                    dr["StatusID"] = (int)Utilities.CategoriesEnum.Overtime_Status.Đã_tính_lương;
                }

                result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtOvertime);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();

                return Utilities.Parameters.ResultMessage;
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
                string result = DataProvider.Update_DataTable_ByID(callFrom, ref dtPayroll);
                return Utilities.Parameters.ResultMessage;
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string vQuery = "UPDATE AttendanceData SET StatusID = " + (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương + ", PayrollID = null WHERE PayrollID = " + PayrollID;
                string vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                vQuery = "UPDATE Overtime SET StatusID = " + (int)Utilities.CategoriesEnum.Overtime_Status.Đã_duyệt + ", PayrollID = null WHERE PayrollID = " + PayrollID;
                vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                vQuery = "DELETE FROM PayrollDetail WHERE PayrollID = " + PayrollID;
                vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                vQuery = "DELETE FROM Payroll WHERE ID = " + PayrollID;
                vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();

                return Utilities.Parameters.ResultMessage;
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string vQuery = "UPDATE AttendanceData SET EmployeeID_ChangeShift = " + EmployeeID_ChangeShift + " WHERE ID = " + AttendanceDataID;
                string vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();

                return Utilities.Parameters.ResultMessage;
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
                string query = Queries.Overtime_GetListOfEmployees(WorkingDateFrom, WorkingDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                string query = Queries.Overtime_GetListOfCreatedBy(WorkingDateFrom, WorkingDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                string query = Queries.Overtime_GetListOfApprovedBy(WorkingDateFrom, WorkingDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string vQuery = "DELETE FROM Overtime WHERE ID = " + OvertimeID;
                string vResult = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, vQuery);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return vResult;
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
