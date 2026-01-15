using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busUserAdministrator
    {
        /// <summary>
        /// Lấy danh sách quyền người dùng chưa có
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="dtPermission">Danh sách quyền</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPermissionDetail(string CallBy, ref DataTable dtResult, DataTable dtPermission)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                List<string> lstPermission = new List<string>();
                foreach (DataRow dr in dtPermission.Rows)
                    if (dr["Type"].ToString() == "PermissionDetail")
                        lstPermission.Add(dr["MainID"].ToString());

                daoUserAdministrator dUserAdministrator = new daoUserAdministrator();
                return dUserAdministrator.GetPermission(callFrom, ref dtResult, lstPermission, "NOT IN");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy tất cả quyền người dùng muốn thêm
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="lstPermissionDetail">Danh sách quyền</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPermissionDetailToAdd(string CallBy, ref DataTable dtResult, List<string> lstPermissionDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoUserAdministrator dUserAdministrator = new daoUserAdministrator();
                return dUserAdministrator.GetPermission(callFrom, ref dtResult, lstPermissionDetail, "IN");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhóm quyền người dùng chưa có
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="dtRole">Danh sách nhóm quyền</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetRole(string CallBy, ref DataTable dtResult, DataTable dtRole)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                List<string> lstRole = new List<string>();
                foreach (DataRow dr in dtRole.Rows)
                    lstRole.Add(dr["RoleID"].ToString());

                daoUserAdministrator dUserAdministrator = new daoUserAdministrator();
                return dUserAdministrator.GetRole(callFrom, ref dtResult, lstRole, "NOT IN");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhóm quyền cần thêm
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="lstRole">Danh sách nhóm quyền</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetRoleToAdd(string CallBy, ref DataTable dtResult, List<string> lstRole)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoUserAdministrator dUserAdministrator = new daoUserAdministrator();
                return dUserAdministrator.GetRole(callFrom, ref dtResult, lstRole, "IN");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }

        }
    }
}
