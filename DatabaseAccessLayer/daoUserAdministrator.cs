using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoUserAdministrator
    {
        /// <summary>
        /// Lấy danh sách quyền
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="lstPermission">Danh sách quyền</param>
        /// <param name="InOrNotIn">Điều kiện (IN hoặc NOT IN)</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPermission(string CallBy, ref DataTable dtResult, List<string> lstPermission, string InOrNotIn)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.UserAdministrator_GetPermission(lstPermission, InOrNotIn);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhóm quyền
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="lstRole">Danh sách nhóm quyền</param>
        /// <param name="InOrNotIn">Điều kiện (IN hoặc NOT IN)</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetRole(string CallBy, ref DataTable dtResult, List<string> lstRole, string InOrNotIn)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.UserAdministrator_GetRole(lstRole, InOrNotIn);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
