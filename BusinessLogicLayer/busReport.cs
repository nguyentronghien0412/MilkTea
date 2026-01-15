using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busReport
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
                DateTime vFrom = new DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, 0, 0, 0);
                DateTime vTo = new DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.BestSeller(callFrom, ref dtResult, vFrom, vTo, ViewByDate);
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
                DateTime from = new DateTime(ActionDateFrom.Year, ActionDateFrom.Month, ActionDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(ActionDateTo.Year, ActionDateTo.Month, ActionDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_Employee(callFrom, ref dtResult, ActionBy, from, to, PaymentedType);
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
                DateTime from = new DateTime(ActionDateFrom.Year, ActionDateFrom.Month, ActionDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(ActionDateTo.Year, ActionDateTo.Month, ActionDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_Employee_Detail(callFrom, ref dtResult, ActionBy, from, to, PaymentedType);
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
                DateTime from = new DateTime(ActionDateFrom.Year, ActionDateFrom.Month, ActionDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(ActionDateTo.Year, ActionDateTo.Month, ActionDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_Employee_ActualExport(callFrom, ref dtResult, ActionBy, from, to, PaymentedType);
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
                DateTime from = new DateTime(PaymentedDateFrom.Year, PaymentedDateFrom.Month, PaymentedDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(PaymentedDateTo.Year, PaymentedDateTo.Month, PaymentedDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_Employee_GetListEmployees(callFrom, ref dtResult, from, to);
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
                DateTime from = new DateTime(PaymentedDateFrom.Year, PaymentedDateFrom.Month, PaymentedDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(PaymentedDateTo.Year, PaymentedDateTo.Month, PaymentedDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_GetListPaymentedType(callFrom, ref dtResult, from, to);
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
                daoReport dReport = new daoReport();
                return dReport.CollectAndSpend_GetName(callFrom, ref dtResult);
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
                daoReport dReport = new daoReport();
                string result= dReport.Inventory(callFrom, ref dtResult);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
                    return "Exception : " + result;
                }

                dtResult.Columns.Add("PriceNearest", typeof(decimal));
                dtResult.Columns.Add("AmountTotal", typeof(decimal));

                foreach (DataRow dr in dtResult.Rows)
                {
                    DataTable dtPriceNearest = new DataTable();
                    result = dReport.Inventory_GetPriceNearest(callFrom, ref dtPriceNearest, dr["MaterialsID"].ToString());
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
                        return "Exception : " + result;
                    }

                    if (dtPriceNearest.Rows.Count > 0)
                    {
                        dr["PriceNearest"] = dtPriceNearest.Rows[0]["PriceImport"];

                        decimal price = 0;
                        if (dtPriceNearest.Rows[0]["PriceImport"].ToString() != "")
                            price = decimal.Parse(dtPriceNearest.Rows[0]["PriceImport"].ToString());

                        decimal quantity = 0;
                        if (dr["QuantityCurrent"].ToString() != "")
                            quantity = decimal.Parse(dr["QuantityCurrent"].ToString());

                        dr["AmountTotal"] = price * quantity;
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
                DateTime from = new DateTime(ActionDateFrom.Year, ActionDateFrom.Month, ActionDateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(ActionDateTo.Year, ActionDateTo.Month, ActionDateTo.Day, 23, 59, 59);

                daoReport dReport = new daoReport();
                return dReport.Revenue_SummaryOfRevenueByEmployee(callFrom, ref dtResult, ActionBy, from, to);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
