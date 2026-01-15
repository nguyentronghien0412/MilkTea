using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoReport
    {
        /// <summary>
        /// Báo cáo Món bán chạy nhất
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="DateFrom">Thời gian bán từ</param>
        /// <param name="DateTo">Thời gian bán đến</param>
        /// <param name="ViewByDate">Xem theo ngày</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string BestSeller(string CallBy, ref DataTable dtResult, DateTime DateFrom, DateTime DateTo, bool ViewByDate)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_BestSeller(DateFrom, DateTo, ViewByDate);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="ActionBy">Người thu tiền</param>
        /// <param name="ActionDateFrom">Thời gian thu từ</param>
        /// <param name="ActionDateTo">Thời gian thu đến</param>
        /// <param name="PaymentedType">Loại thanh toán: CASH = Tiền mặt; BANK = Chuyển khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_Employee(string CallBy, ref DataTable dtResult, string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_Employee(ActionBy, ActionDateFrom, ActionDateTo, PaymentedType);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên - Chi tiết
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="ActionBy">Người thu tiền</param>
        /// <param name="ActionDateFrom">Thời gian thu từ</param>
        /// <param name="ActionDateTo">Thời gian thu đến</param>
        /// <param name="PaymentedType">Loại thanh toán: CASH = Tiền mặt; BANK = Chuyển khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_Employee_Detail(string CallBy, ref DataTable dtResult, string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_Employee_Detail(ActionBy, ActionDateFrom, ActionDateTo, PaymentedType);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên - Số lượng xuất thực tế
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="ActionBy">Người thu tiền</param>
        /// <param name="ActionDateFrom">Thời gian thu từ</param>
        /// <param name="ActionDateTo">Thời gian thu đến</param>
        /// <param name="PaymentedType">Loại thanh toán: CASH = Tiền mặt; BANK = Chuyển khoản</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_Employee_ActualExport(string CallBy, ref DataTable dtResult, string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_Employee_ActualExport(ActionBy, ActionDateFrom, ActionDateTo, PaymentedType);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên - Lấy danh sách nhân viên thu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="PaymentedDateFrom">Thời gian thu từ</param>
        /// <param name="PaymentedDateTo">Thời gian thu đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_Employee_GetListEmployees(string CallBy, ref DataTable dtResult, DateTime PaymentedDateFrom, DateTime PaymentedDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_Employee_GetListEmployees(PaymentedDateFrom, PaymentedDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên - Lấy danh sách loại thanh toán
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="PaymentedDateFrom">Thời gian thu từ</param>
        /// <param name="PaymentedDateTo">Thời gian thu đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_GetListPaymentedType(string CallBy, ref DataTable dtResult, DateTime PaymentedDateFrom, DateTime PaymentedDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_GetListPaymentedType(PaymentedDateFrom, PaymentedDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nội dung thu/chi đã nhập
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string CollectAndSpend_GetName(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.CollectAndSpend_GetName();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo tồn kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Inventory(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Inventory();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Báo cáo tồn kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MaterialsID">Mã nguyên liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Inventory_GetPriceNearest(string CallBy, ref DataTable dtResult, string MaterialsID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Inventory_GetPriceNearest(MaterialsID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Tổng hợp doanh thu theo nhân viên
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="ActionBy">Người thu tiền</param>
        /// <param name="ActionDateFrom">Thời gian thu từ</param>
        /// <param name="ActionDateTo">Thời gian thu đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Revenue_SummaryOfRevenueByEmployee(string CallBy, ref DataTable dtResult, string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Report_Revenue_SummaryOfRevenueByEmployee(ActionBy, ActionDateFrom, ActionDateTo);
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
