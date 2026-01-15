using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busGeneralFunctions
    {
        /// <summary>
        /// Lấy tất cả dữ liệu trong 1 bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="TableName">Tên bảng lấy dữ liệu</param>
        /// <param name="OrderBy">Sắp xếp theo thứ tự: ASC/DESC</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll(string CallBy, ref DataTable dtResult, string TableName, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                string result = dGeneralFunctions.GetAll(callFrom, ref dtResult, TableName, OrderBy);
                dtResult.TableName = TableName;
                return result;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo điều kiện
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="TableName">Tên bảng lấy dữ liệu</param>
        /// <param name="FieldName">Tên cột so sánh</param>
        /// <param name="Value">Giá trị so sánh</param>
        /// <param name="OrderBy">Sắp xếp theo tiêu chí</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByCondition(string CallBy, ref DataTable dtResult, string TableName, string[] FieldName, string[] Value, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                string result = dGeneralFunctions.GetByCondition(callFrom, ref dtResult, TableName, FieldName, Value, OrderBy);
                dtResult.TableName = TableName;
                return result;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo điều kiện
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="TableName">Tên bảng lấy dữ liệu</param>
        /// <param name="FieldName">Tên cột so sánh</param>
        /// <param name="Operator">Danh sách toán tử so sánh</param>
        /// <param name="Value">Giá trị so sánh</param>
        /// <param name="OrderBy">Sắp xếp theo tiêu chí</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByCondition(string CallBy, ref DataTable dtResult, string TableName, string[] FieldName, string[] Operator, string[] Value, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                string result = dGeneralFunctions.GetByCondition(callFrom, ref dtResult, TableName, FieldName, Operator, Value, OrderBy);
                dtResult.TableName = TableName;
                return result;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thêm dữ liệu vào bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtInsert">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ diệu</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtInsert, bool AutoIncremental)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                return dGeneralFunctions.Insert(callFrom, ref dtInsert, AutoIncremental);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thêm dữ liệu vào bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtInsert">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ diệu</param>
        /// <param name="dtInsertDetail">Bảng dữ liệu chi tiết để thêm, phải có TableName: Tên bảng sẽ thêm dữ diệu</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <param name="AutoIncrementalDetail">ID cấp tự động tăng của bảng chi tiết. Có = True, Không = False</param>
        /// <param name="ColumnParentName">Tên cột bảng chi tiết (cha-con)</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtInsert, ref DataTable dtInsertDetail, bool AutoIncremental, bool AutoIncrementalDetail, string ColumnParentName)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                return dGeneralFunctions.Insert(callFrom, ref dtInsert, ref dtInsertDetail, AutoIncremental, AutoIncrementalDetail, ColumnParentName);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu vào bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtUpdate">Bảng dữ liệu để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ diệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string UpdateByID(string CallBy, DataTable dtUpdate)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                return dGeneralFunctions.UpdateByID(callFrom, dtUpdate);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu vào bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtData">Bảng chính để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <param name="dtDataDetail">Bảng chi tiết để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <param name="ColumnParentName">Tên cột bảng chi tiết (cha-con)</param>
        /// <param name="ColumnNameToCompare">Danh sách cột để so sánh cập nhật chi tiết</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtData, DataTable dtDataDetail, string ColumnParentName, List<string> ColumnNameToCompare)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {                
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                return dGeneralFunctions.Update(callFrom, dtData, dtDataDetail, ColumnParentName, ColumnNameToCompare);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Xóa dữ liệu theo ID
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="TableName">Tên bảng dữ liệu</param>
        /// <param name="ID">Mã ID</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string DeleteByID(string CallBy, string TableName, string ID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneralFunctions = new daoGeneralFunctions();
                return dGeneralFunctions.DeleteByID(callFrom, TableName, ID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }
    }
}
