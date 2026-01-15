using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busSystemConfiguration
    {
        /// <summary>
        /// Kiểm tra kết nối đến cơ sở dữ liệu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Server">Tên máy chủ</param>
        /// <param name="Port">Cổng</param>
        /// <param name="Database">Tên cơ sở dữ liệu</param>
        /// <param name="Username">Tên đăng nhập</param>
        /// <param name="Password">Mật khẩu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string TestConnectToDatabase(string CallBy, string Server, string Port, string Database, string Username, string Password)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                return DataProvider.TestConnectToDatabase(Server, Port, Database, Username, Password);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
