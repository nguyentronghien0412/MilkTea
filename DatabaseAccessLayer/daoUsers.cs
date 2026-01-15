using DataObject;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoUsers
    {
        /// <summary>
        /// Lấy Tài khoản theo Tên đăng nhập
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="UserName">Tên đăng nhập</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByUsername(string CallBy, ref DataTable dtResult, string UserName)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetByUsername(UserName);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy quyền của tài khoản
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="UserID">Mã tài khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListPermission(string CallBy, ref DataTable dtResult, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetListPermission(UserID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy Quyền chi tiết của tài khoản
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="UserID">Mã tài khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListPermissionDetail(string CallBy, ref DataTable dtResult, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetListPermissionDetail(UserID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy tất cả quyền lẻ của người dùng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="UserID">Mã người dùng</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPermissionDetails(string CallBy, ref DataTable dtResult, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetPermissionDetails(UserID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy tài khoản theo điều kiện
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="UserName">Tên đăng nhập</param>
        /// <param name="UserID">Mã tài khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetToEdit(string CallBy, ref DataTable dtResult, string UserName, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetToEdit(UserName, UserID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thêm người dùng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtEmployee">Thông tin người dùng</param>
        /// <param name="dtUser">Tài khoản người dùng</param>
        /// <param name="dtUserAndRole">Danh sách nhóm quyền</param>
        /// <param name="dtUserAndPermissionDetail">Danh sách quyền lẻ</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtEmployee, ref DataTable dtUser, ref DataTable dtUserAndRole, ref DataTable dtUserAndPermissionDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                #region Insert Employee

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtEmployee, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Insert User

                dtUser.Rows[0]["EmployeesID"] = dtEmployee.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUser, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Insert Role

                foreach (DataRow dr in dtUserAndRole.Rows)
                    dr["UserID"] = dtUser.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUserAndRole, false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Insert PermissionDetail

                foreach (DataRow dr in dtUserAndPermissionDetail.Rows)
                    dr["UserID"] = dtUser.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUserAndPermissionDetail, false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

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
        /// Cập nhật người dùng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtEmployee">Thông tin người dùng</param>
        /// <param name="dtUser">Tài khoản người dùng</param>
        /// <param name="dtUserAndRole_Insert">Danh sách nhóm quyền - Thêm</param>
        /// <param name="dtUserAndRole_Delete">Danh sách nhóm quyền - Xóa</param>
        /// <param name="dtUserAndPermissionDetail_Insert">Danh sách quyền lẻ - Thêm</param>
        /// <param name="dtUserAndPermissionDetail_Delete">Danh sách quyền lẻ - Xóa</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtEmployee, DataTable dtUser,
            DataTable dtUserAndRole_Insert, DataTable dtUserAndRole_Delete,
            DataTable dtUserAndPermissionDetail_Insert, DataTable dtUserAndPermissionDetail_Delete)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string query = "";

                #region Update Employee

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtEmployee);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Update User

                if (dtUser.Rows[0]["ID"].ToString() == string.Empty)
                {
                    #region Insert User

                    dtUser.Rows[0]["EmployeesID"] = dtEmployee.Rows[0]["ID"];

                    result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUser, true);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
                    }

                    #endregion

                    foreach (DataRow dr in dtUserAndRole_Insert.Rows)
                        dr["UserID"] = dtUser.Rows[0]["ID"];

                    foreach (DataRow dr in dtUserAndPermissionDetail_Insert.Rows)
                        dr["UserID"] = dtUser.Rows[0]["ID"];
                }
                else
                {
                    #region Update User

                    result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtUser);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
                    }

                    #endregion
                }

                #endregion

                #region Insert Role

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUserAndRole_Insert, false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Delete Role

                foreach (DataRow dr in dtUserAndRole_Delete.Rows)
                {
                    query = @"DELETE FROM UserAndRole WHERE RoleID = " + dr["RoleID"].ToString() + " AND UserID = " + dr["UserID"].ToString();
                    result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
                    }
                }

                #endregion

                #region Insert PermissionDetail

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtUserAndPermissionDetail_Insert, false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                #endregion

                #region Delete PermissionDetail

                foreach (DataRow dr in dtUserAndPermissionDetail_Delete.Rows)
                {
                    query = @"DELETE FROM UserAndPermissionDetail WHERE PermissionDetailID = " + dr["PermissionDetailID"].ToString() + " AND UserID = " + dr["UserID"].ToString();
                    result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
                    }
                }

                #endregion

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
        /// Lấy tất cả người dùng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetAll();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy tất cả người dùng theo trạng thái
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="StatusID">Trạng thái</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAllByStatus(string CallBy, ref DataTable dtResult, int StatusID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Users_GetAllByStatus(StatusID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Đặt lại mật khẩu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="User">Thông tin tài khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string ResetPassword(string CallBy, dtoUsers User)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string query = Queries.Users_ResetPassword(User);
                string result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
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
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtUser">Thông tin người dùng</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string ChangePassword(string CallBy, DataTable dtUser)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtUser);
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
    }
}
