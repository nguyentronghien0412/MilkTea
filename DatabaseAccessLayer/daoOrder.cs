using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoOrder
    {
        /// <summary>
        /// Lấy Order theo mã
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="OrderID">Mã Order</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByID(string CallBy, ref DataTable dtResult, string OrderID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetByID(OrderID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách món
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="OrderID">Mã Order</param>
        /// <param name="IsCancelled">Order đã hủy</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetDetailsByOrderID(string CallBy, ref DataTable dtResult, string OrderID, bool IsCancelled)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.OrderDetail_GetByOrderID(OrderID, IsCancelled);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy các bàn đã hủy
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="DateFrom">Ngày Order Từ</param>
        /// <param name="DateTo">Ngày Order Đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetCancelledByDate(string CallBy, ref DataTable dtResult, DateTime DateFrom, DateTime DateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetCancelledByDate(DateFrom, DateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy các bàn đã thanh toán
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="DateFrom">Ngày Order Từ</param>
        /// <param name="DateTo">Ngày Order Đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPaymentedByDate(string CallBy, ref DataTable dtResult, DateTime DateFrom, DateTime DateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetPaymentedByDate(DateFrom, DateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy các bàn chưa thu tiền
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetNoCollected(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetNoCollected();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy các bàn chưa thanh toán
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetNoPayment(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetNoPayment();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy các bàn trống
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="GetIsEmpty">Lấy bàn chưa có khách</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetDinnerTable(string CallBy, ref DataTable dtResult, bool GetIsEmpty)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetDinnerTable(GetIsEmpty);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thêm Order
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrder">Order để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtOrderDetail">Danh sách món để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtOrder, ref DataTable dtOrderDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtOrder, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtOrderDetail.Rows)
                    dr["OrderID"] = dtOrder.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtOrderDetail, true);
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
        /// Cập nhật Order
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrder">Danh sách Order, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, ref DataTable dtOrder)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                return DataProvider.Update_DataTable_ByID(callFrom, ref dtOrder);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Cập nhật Order - Trừ kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrder">Danh sách Order, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="WarehouseRollback">Danh sách nguyên liệu để trừ kho</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update_WarehouseSubtract(string CallBy, ref DataTable dtOrder, DataTable WarehouseRollback)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtOrder);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                if (WarehouseRollback != null)
                {
                    foreach (DataRow dr in WarehouseRollback.Rows)
                    {
                        string querySubtract = "UPDATE Warehouse SET QuantityCurrent = QuantityCurrent - " + dr["QuantitySubtract"].ToString() + " WHERE ID = " + dr["WarehouseID"].ToString();
                        result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, querySubtract);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }

                        //Lấy lại thông tin sau khi trừ kho, nếu < 0 thì rollback
                        DataTable dtWarehouse = new DataTable();
                        string query = "SELECT * FROM Warehouse WHERE ID = " + dr["WarehouseID"].ToString();
                        result = DataProvider.GetDataTable(callFrom, con, sqlTrans, query, ref dtWarehouse);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return "Lỗi kiểm tra dữ liệu kho ("+ result + ")";
                        }

                        if (dtWarehouse == null || dtWarehouse.Rows.Count != 1)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return "Lỗi kiểm tra dữ liệu kho ("+ query + ")";
                        }

                        if (decimal.Parse(dtWarehouse.Rows[0]["QuantityCurrent"].ToString()) < 0)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return "Số lượng trừ kho lỗi. Vui lòng thực hiện thanh toán lại. (" + querySubtract + ")";
                        }
                    }

                    result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref WarehouseRollback, true);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
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
        /// Gộp Order
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrder">Danh sách Order, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtOrderDetail">Danh sách chi tiết Order, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="OrderMergeID">Mã Order gộp</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Merge(string CallBy,  ref DataTable dtOrder, ref DataTable dtOrderDetail, string OrderMergeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtOrder);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtOrderDetail);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                result = DataProvider.DeleteByID(callFrom, con, sqlTrans, "Orders", OrderMergeID);
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
        /// Thêm món
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrderDetail">Danh sách món để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string OrderDetail_Insert(string CallBy, ref DataTable dtOrderDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtOrderDetail, true);
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
        /// Cập nhật món
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtOrderDetail">Danh sách món để cập nhật, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string OrderDetail_Update(string CallBy, ref DataTable dtOrderDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                return DataProvider.Update_DataTable_ByID(callFrom,ref dtOrderDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nguyên liệu để trừ kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="OrderID">Mã Order</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetMaterials(string CallBy, ref DataTable dtResult, string OrderID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetMaterials(OrderID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nguyên liệu còn số lượng trong kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MaterialsID">Mã nguyên liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetWarehouse(string CallBy, ref DataTable dtResult, string MaterialsID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetWarehouse(MaterialsID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả nguyên liệu còn số lượng trong kho
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetWarehouse_All(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Order_GetWarehouse_All();
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
