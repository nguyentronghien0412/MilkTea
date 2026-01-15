using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busRole
    {
        /// <summary>
        /// Lấy tất cả Role
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoRole dRole = new daoRole();
                return dRole.GetAll(callFrom, ref dtResult);
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
                daoRole dRole = new daoRole();
                return dRole.GetByID(callFrom, ref dtResult, RoleID);
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
                daoRole dRole = new daoRole();
                return dRole.GetAllPermissionToEdit(callFrom, ref dtResult, RoleID);
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
        public string Insert(string CallBy, ref DataTable dtRole, DataTable dtRoleDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoRole dRole = new daoRole();
                return dRole.Insert(callFrom, ref dtRole, ref dtRoleDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
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
                daoRole dRole = new daoRole();
                return dRole.Update(callFrom, dtRole, dtRoleDetail);
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
                daoRole dRole = new daoRole();
                return dRole.Delete(callFrom, RoleID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
