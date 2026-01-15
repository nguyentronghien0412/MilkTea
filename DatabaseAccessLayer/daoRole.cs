using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoRole
    {
        /// <summary>
        /// Lấy tất cả Nhóm quyền
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Role_GetAll();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy Role theo ID
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="RoleID">Mã Role</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByID(string CallBy, ref DataTable dtResult, string RoleID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Role_GetByID(RoleID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy Role theo điều kiện
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="RoleID">Mã Role</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAllPermissionToEdit(string CallBy, ref DataTable dtResult, string RoleID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Role_GetAllPermissionToEdit(RoleID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thêm Role
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtRole">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtRoleDetail">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtRole, ref DataTable dtRoleDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtRole, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtRoleDetail.Rows)
                    dr["RoleID"] = dtRole.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtRoleDetail, false);
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

        private bool CheckPermissionDetailExist(string PermissionDetailID, DataTable dtCheck)
        {
            foreach (DataRow dr in dtCheck.Rows)
                if (PermissionDetailID == dr["PermissionDetailID"].ToString())
                    return true;
            return false;
        }

        /// <summary>
        /// Cập nhật Role
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtRole">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtRoleDetail">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtRole, DataTable dtRoleDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtRole);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                DataTable dtOld = new DataTable();
                string query = "SELECT * FROM RoleDetail WHERE RoleID = " + dtRole.Rows[0]["ID"].ToString();
                result = DataProvider.GetDataTable(callFrom, con, sqlTrans, query, ref dtOld);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtOld.Rows)
                {
                    if (!CheckPermissionDetailExist(dr["PermissionDetailID"].ToString(), dtRoleDetail))
                    {
                        query = "DELETE FROM RoleDetail where PermissionDetailID = " + dr["PermissionDetailID"].ToString() + " AND RoleID = " + dtRole.Rows[0]["ID"].ToString();
                        result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
                    }
                }

                foreach (DataRow dr in dtRoleDetail.Rows)
                {
                    if (!CheckPermissionDetailExist(dr["PermissionDetailID"].ToString(), dtOld))
                    {
                        DataRow drTemp = dr;
                        int id = DataProvider.Insert_DataRow(callFrom, con, sqlTrans, ref drTemp, false);
                        if (id <= 0)
                            result = "Insert Error: Table = " + dtRoleDetail.TableName + "(Error:" + id + ")";
                        else
                            result = Utilities.Parameters.ResultMessage;
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
                        else
                        {
                            if (dtRoleDetail.Columns.Contains("ID"))
                            {
                                dr["ID"] = drTemp["ID"];
                                dtRoleDetail.AcceptChanges();
                            }
                        }
                    }
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
        /// Xóa Role
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="RoleID">Mã Role</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Delete(string CallBy, string RoleID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"DELETE FROM RoleDetail WHERE RoleID = " + RoleID;
                string result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                query = @"DELETE FROM Role WHERE ID = " + RoleID;
                result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
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
