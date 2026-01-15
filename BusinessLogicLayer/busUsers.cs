using DatabaseAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busUsers
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
                daoUsers dUser = new daoUsers();
                return dUser.GetByUsername(callFrom, ref dtResult, UserName);
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
        /// <param name="dtPermission">Bảng lưu quyền trả về</param>
        /// <param name="dtPermission_Detail">Bảng lưu quyền chi tiết trả về</param>
        /// <param name="arrButtonStatusDefault">Mảng lưu trạng thái quyền trả về</param>
        /// <param name="UserID">Mã tài khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPermission(string CallBy, ref DataTable dtPermission, ref DataTable dtPermission_Detail, ref bool[][] arrButtonStatusDefault, string UserID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoUsers dUser = new daoUsers();
                string result = dUser.GetListPermission(callFrom, ref dtPermission, UserID);
                if (result != Utilities.Parameters.ResultMessage)
                    return result;

                result = dUser.GetListPermissionDetail(callFrom, ref dtPermission_Detail, UserID);
                if (result != Utilities.Parameters.ResultMessage)
                    return result;

                foreach (DataRow dr in dtPermission.Rows)
                    dr["Code"] = Utilities.Functions.DecryptByRC2(dr["Code"].ToString(), Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);

                foreach (DataRow dr in dtPermission_Detail.Rows)
                {
                    dr["Code"] = Utilities.Functions.DecryptByRC2(dr["Code"].ToString(), Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);
                    dr["PermissionCode"] = Utilities.Functions.DecryptByRC2(dr["PermissionCode"].ToString(), Utilities.Parameters.KEY_Permission, Utilities.Parameters.IV_Permission);
                }

                #region Set Index for Permission

                if (!dtPermission.Columns.Contains("IndexForPermission"))
                    dtPermission.Columns.Add("IndexForPermission", typeof(int));

                for (int i = 0; i < dtPermission.Rows.Count; i++)
                    dtPermission.Rows[i]["IndexForPermission"] = i + 1;

                #endregion

                #region Init arrButtonStatusDefault

                int row = dtPermission.Rows.Count + 1;
                int column = arrButtonStatusDefault[0].Length;

                arrButtonStatusDefault = new bool[row][];
                for (int i = 0; i < dtPermission.Rows.Count + 1; i++)
                    arrButtonStatusDefault[i] = new bool[column];

                for (int i = 0; i < row; i++)
                    for (int j = 0; j < column; j++)
                        arrButtonStatusDefault[i][j] = false;

                for (int i = 1; i < row; i++)
                {
                    arrButtonStatusDefault[i][2] = true;
                    arrButtonStatusDefault[i][2] = true;

                    arrButtonStatusDefault[i][5] = true;
                    arrButtonStatusDefault[i][5] = true;

                    arrButtonStatusDefault[i][6] = true;
                    arrButtonStatusDefault[i][6] = true;
                }

                #endregion

                foreach (DataRow dr in dtPermission.Rows)
                {
                    int permID = int.Parse(dr["ID"].ToString());
                    int idx = int.Parse(dr["IndexForPermission"].ToString());

                    DataView vDetail = new DataView(dtPermission_Detail);
                    vDetail.RowFilter = "PermissionID = " + permID;
                    DataTable dtDetail = vDetail.ToTable();

                    foreach (DataRow drDetail in dtDetail.Rows)
                    {
                        string permdCode = drDetail["Code"].ToString();

                        if (permdCode == Utilities.Parameters.Permission_NEW)
                            arrButtonStatusDefault[idx][1] = true;
                        else if (permdCode == Utilities.Parameters.Permission_EDIT)
                            arrButtonStatusDefault[idx][3] = true;
                        else if (permdCode == Utilities.Parameters.Permission_DELETE)
                            arrButtonStatusDefault[idx][4] = true;
                        else if (permdCode == Utilities.Parameters.Permission_PRINT)
                        {
                            arrButtonStatusDefault[idx][7] = true;
                            arrButtonStatusDefault[idx][8] = true;
                        }
                        else if (permdCode == Utilities.Parameters.Permission_EXPORT)
                            arrButtonStatusDefault[idx][9] = true;
                    }
                }

                return Utilities.Parameters.ResultMessage;
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
                daoUsers dUser = new daoUsers();
                return dUser.GetPermissionDetails(callFrom, ref dtResult, UserID);
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
                daoUsers dUser = new daoUsers();
                return dUser.GetToEdit(callFrom, ref dtResult, UserName, UserID);
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
                daoUsers dUser = new daoUsers();
                return dUser.GetAll(callFrom, ref dtResult);
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
                daoUsers dUser = new daoUsers();
                return dUser.GetAllByStatus(callFrom, ref dtResult, StatusID);
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
        /// <param name="ActionBy">Người thực hiện</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtEmployee, ref DataTable dtUser, ref DataTable dtUserAndRole,
            ref DataTable dtUserAndPermissionDetail, int ActionBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime ActionDate = DateTime.Now;

                dtEmployee.Rows[0]["CreatedBy"] = ActionBy;
                dtEmployee.Rows[0]["CreatedDate"] = ActionDate;

                dtUser.Rows[0]["CreatedBy"] = ActionBy;
                dtUser.Rows[0]["CreatedDate"] = ActionDate;

                dtUser.Rows[0]["Password"] = Utilities.Functions.EncryptByRC2(dtUser.Rows[0]["Password"].ToString(), Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);

                foreach (DataRow dr in dtUserAndRole.Rows)
                {
                    dr["CreatedBy"] = ActionBy;
                    dr["CreatedDate"] = ActionDate;
                }

                DataTable dtPermissionDetail = new DataTable();
                dtPermissionDetail.TableName = "UserAndPermissionDetail";

                dtPermissionDetail.Columns.Add("UserID", typeof(int));
                dtPermissionDetail.Columns.Add("PermissionDetailID", typeof(int));
                dtPermissionDetail.Columns.Add("CreatedBy", typeof(int));
                dtPermissionDetail.Columns.Add("CreatedDate", typeof(DateTime));

                foreach (DataRow dr in dtUserAndPermissionDetail.Rows)
                {
                    if (dr["Type"].ToString() == "PermissionDetail")
                    {
                        DataRow drAdd = dtPermissionDetail.NewRow();

                        drAdd["PermissionDetailID"] = dr["MainID"];
                        drAdd["CreatedBy"] = ActionBy;
                        drAdd["CreatedDate"] = ActionDate;

                        dtPermissionDetail.Rows.Add(drAdd);
                    }
                }

                daoUsers dUser = new daoUsers();
                return dUser.Insert(callFrom, ref dtEmployee, ref dtUser, ref dtUserAndRole, ref dtPermissionDetail);
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
        /// <param name="dtUserAndRole">Danh sách nhóm quyền</param>
        /// <param name="dtUserAndPermissionDetail">Danh sách quyền lẻ</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtEmployee, DataTable dtUser, DataTable dtUserAndRole, DataTable dtUserAndPermissionDetail, int ActionBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DateTime ActionDate = DateTime.Now;

                #region dtEmployee & dtUser

                dtEmployee.Rows[0]["LastUpdatedBy"] = ActionBy;
                dtEmployee.Rows[0]["LastUpdatedDate"] = ActionDate;

                if (dtUser.Rows[0]["ID"].ToString() == string.Empty)
                {
                    dtUser.Rows[0]["CreatedBy"] = ActionBy;
                    dtUser.Rows[0]["CreatedDate"] = ActionDate;
                }
                else
                {
                    dtUser.Rows[0]["LastUpdatedBy"] = ActionBy;
                    dtUser.Rows[0]["LastUpdatedDate"] = ActionDate;
                }

                if (dtUser.Rows[0]["StatusID"].ToString() != "" && 
                    int.Parse(dtUser.Rows[0]["StatusID"].ToString()) == (int)Utilities.CategoriesEnum.Status.Tạm_ngưng)
                {
                    dtUser.Rows[0]["StoppedBy"] = ActionBy;
                    dtUser.Rows[0]["StoppedDate"] = ActionDate;
                }

                dtUser.Rows[0]["Password"] = Utilities.Functions.EncryptByRC2(dtUser.Rows[0]["Password"].ToString(), Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);

                #endregion

                #region dtUserAndRole

                string userID = dtUser.Rows[0]["ID"].ToString();
                if (userID == string.Empty)
                    userID = "0";

                DataTable dtOldRole = new DataTable();
                string query = "SELECT * FROM UserAndRole WHERE UserID = " + userID;
                string result = DataProvider.GetDataTable(callFrom, query, ref dtOldRole);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + query);
                    return "Exception : " + query;
                }

                dtOldRole.TableName = "UserAndRole";
                DataTable dtUserAndRole_Insert = dtOldRole.Clone();
                DataTable dtUserAndRole_Delete = dtOldRole.Clone();

                foreach (DataRow dr in dtOldRole.Rows)
                {
                    if (!dtUserAndRole.AsEnumerable().Any(row => (int)dr["RoleID"] == row.Field<int>("RoleID")))
                    {
                        DataRow drDelete = dtUserAndRole_Delete.NewRow();

                        drDelete["RoleID"] = dr["RoleID"];
                        drDelete["UserID"] = userID;

                        dtUserAndRole_Delete.Rows.Add(drDelete);
                    }
                }

                foreach (DataRow dr in dtUserAndRole.Rows)
                {
                    if (!dtOldRole.AsEnumerable().Any(row => (int)dr["RoleID"] == row.Field<int>("RoleID")))
                    {
                        DataRow drInsert = dtUserAndRole_Insert.NewRow();

                        drInsert["RoleID"] = dr["RoleID"];
                        drInsert["UserID"] = userID;
                        drInsert["CreatedBy"] = ActionBy;
                        drInsert["CreatedDate"] = ActionDate;

                        dtUserAndRole_Insert.Rows.Add(drInsert);
                    }
                }

                #endregion

                #region dtUserAndPermissionDetail

                DataTable dtPermissionDetail = new DataTable();
                dtPermissionDetail.TableName = "UserAndPermissionDetail";

                dtPermissionDetail.Columns.Add("UserID", typeof(int));
                dtPermissionDetail.Columns.Add("PermissionDetailID", typeof(int));
                dtPermissionDetail.Columns.Add("CreatedBy", typeof(int));
                dtPermissionDetail.Columns.Add("CreatedDate", typeof(DateTime));

                foreach (DataRow dr in dtUserAndPermissionDetail.Rows)
                {
                    if (dr["Type"].ToString() == "PermissionDetail")
                    {
                        DataRow drAdd = dtPermissionDetail.NewRow();

                        drAdd["UserID"] = userID;
                        drAdd["PermissionDetailID"] = dr["MainID"];
                        drAdd["CreatedBy"] = ActionBy;
                        drAdd["CreatedDate"] = ActionDate;

                        dtPermissionDetail.Rows.Add(drAdd);
                    }
                }

                DataTable dtOldPermissionDetail = new DataTable();
                query = "SELECT * FROM UserAndPermissionDetail WHERE UserID = " + userID;
                result = DataProvider.GetDataTable(callFrom, query, ref dtOldPermissionDetail);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + query);
                    return "Exception : " + query;
                }

                dtOldPermissionDetail.TableName = "UserAndPermissionDetail";
                DataTable dtUserAndPermissionDetail_Insert = dtOldPermissionDetail.Clone();
                DataTable dtUserAndPermissionDetail_Delete = dtOldPermissionDetail.Clone();

                foreach (DataRow dr in dtOldPermissionDetail.Rows)
                {
                    if (!dtPermissionDetail.AsEnumerable().Any(row => (int)dr["PermissionDetailID"] == row.Field<int>("PermissionDetailID")))
                    {
                        DataRow drDelete = dtUserAndPermissionDetail_Delete.NewRow();

                        drDelete["PermissionDetailID"] = dr["PermissionDetailID"];
                        drDelete["UserID"] = userID;

                        dtUserAndPermissionDetail_Delete.Rows.Add(drDelete);
                    }
                }

                foreach (DataRow dr in dtPermissionDetail.Rows)
                {
                    if (!dtOldPermissionDetail.AsEnumerable().Any(row => (int)dr["PermissionDetailID"] == row.Field<int>("PermissionDetailID")))
                    {
                        DataRow drInsert = dtUserAndPermissionDetail_Insert.NewRow();

                        drInsert["PermissionDetailID"] = dr["PermissionDetailID"];
                        drInsert["UserID"] = userID;
                        drInsert["CreatedBy"] = ActionBy;
                        drInsert["CreatedDate"] = ActionDate;

                        dtUserAndPermissionDetail_Insert.Rows.Add(drInsert);
                    }
                }

                #endregion

                daoUsers dUsers = new daoUsers();
                return dUsers.Update(callFrom, dtEmployee, dtUser, dtUserAndRole_Insert, dtUserAndRole_Delete, dtUserAndPermissionDetail_Insert, dtUserAndPermissionDetail_Delete);
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
                daoUsers dUser = new daoUsers();
                return dUser.ResetPassword(callFrom, User);
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
                daoUsers dUser = new daoUsers();
                return dUser.ChangePassword(callFrom, dtUser);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
