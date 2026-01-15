using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busOrder
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
                daoOrder dOrder = new daoOrder();
                return dOrder.GetByID(callFrom, ref dtResult, OrderID);
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
        /// <param name="OrderID">Mãs Order</param>
        /// <param name="IsCancelled">Order đã hủy</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetDetailsByOrderID(string CallBy, ref DataTable dtResult, string OrderID, bool IsCancelled)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoOrder dOrder = new daoOrder();
                return dOrder.GetDetailsByOrderID(callFrom, ref dtResult, OrderID, IsCancelled);
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
                DateTime from = new DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59);

                daoOrder dOrder = new daoOrder();
                return dOrder.GetCancelledByDate(callFrom, ref dtResult, from, to);
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
                DateTime from = new DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59);

                daoOrder dOrder = new daoOrder();
                return dOrder.GetPaymentedByDate(callFrom, ref dtResult, from, to);
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
                daoOrder dOrder = new daoOrder();
                return dOrder.GetNoCollected(callFrom, ref dtResult);
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
                daoOrder dOrder = new daoOrder();
                return dOrder.GetNoPayment(callFrom, ref dtResult);
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
                daoOrder dOrder = new daoOrder();
                return dOrder.GetDinnerTable(callFrom, ref dtResult, GetIsEmpty);
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
                dtOrder.Rows[0]["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrder.Rows[0]["CreatedDate"] = DateTime.Now;
                dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán;

                DataTable dtDetail = new DataTable();
                dtDetail.TableName = "OrdersDetail";
                dtDetail.Columns.Add("ID", typeof(int));
                dtDetail.Columns.Add("OrderID", typeof(int));
                dtDetail.Columns.Add("MenuID", typeof(int));
                dtDetail.Columns.Add("Quantity", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("PriceListID", typeof(int));
                dtDetail.Columns.Add("CreatedBy", typeof(int));
                dtDetail.Columns.Add("CreatedDate", typeof(DateTime));
                dtDetail.Columns.Add("CancelledBy", typeof(int));
                dtDetail.Columns.Add("CancelledDate", typeof(DateTime));
                dtDetail.Columns.Add("Note", typeof(string));
                dtDetail.Columns.Add("KindOfHotpot1ID", typeof(int));
                dtDetail.Columns.Add("KindOfHotpot2ID", typeof(int));
                dtDetail.Columns.Add("SizeID", typeof(int));

                foreach (DataRow dr in dtOrderDetail.Rows)
                {
                    DataRow drAdd = dtDetail.NewRow();

                    drAdd["MenuID"] = dr["MenuID"];
                    drAdd["Quantity"] = dr["Quantity"];
                    drAdd["Price"] = dr["Price"];
                    drAdd["PriceListID"] = dr["PriceListID"];
                    drAdd["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    drAdd["CreatedDate"] = DateTime.Now;
                    drAdd["Note"] = dr["Note"];
                    drAdd["KindOfHotpot1ID"] = dr["KindOfHotpot1ID"];
                    drAdd["KindOfHotpot2ID"] = dr["KindOfHotpot2ID"];
                    drAdd["SizeID"] = dr["SizeID"];

                    dtDetail.Rows.Add(drAdd);
                }

                daoOrder dOrder = new daoOrder();
                return dOrder.Insert(callFrom, ref dtOrder, ref dtDetail);
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
        /// <param name="OrderID">Mã Order</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string OrderDetail_Insert(string CallBy, ref DataTable dtOrderDetail, int OrderID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtDetail = new DataTable();
                dtDetail.TableName = "OrdersDetail";
                dtDetail.Columns.Add("ID", typeof(int));
                dtDetail.Columns.Add("OrderID", typeof(int));
                dtDetail.Columns.Add("MenuID", typeof(int));
                dtDetail.Columns.Add("Quantity", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("PriceListID", typeof(int));
                dtDetail.Columns.Add("CreatedBy", typeof(int));
                dtDetail.Columns.Add("CreatedDate", typeof(DateTime));
                dtDetail.Columns.Add("CancelledBy", typeof(int));
                dtDetail.Columns.Add("CancelledDate", typeof(DateTime));
                dtDetail.Columns.Add("Note", typeof(string));
                dtDetail.Columns.Add("KindOfHotpot1ID", typeof(int));
                dtDetail.Columns.Add("KindOfHotpot2ID", typeof(int));
                dtDetail.Columns.Add("SizeID", typeof(int));

                foreach (DataRow dr in dtOrderDetail.Rows)
                {
                    DataRow drAdd = dtDetail.NewRow();

                    drAdd["OrderID"] = OrderID;
                    drAdd["MenuID"] = dr["MenuID"];
                    drAdd["Quantity"] = dr["Quantity"];
                    drAdd["Price"] = dr["Price"];
                    drAdd["PriceListID"] = dr["PriceListID"];
                    drAdd["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    drAdd["CreatedDate"] = DateTime.Now;
                    drAdd["Note"] = dr["Note"];
                    drAdd["KindOfHotpot1ID"] = dr["KindOfHotpot1ID"];
                    drAdd["KindOfHotpot2ID"] = dr["KindOfHotpot2ID"];
                    drAdd["SizeID"] = dr["SizeID"];

                    dtDetail.Rows.Add(drAdd);
                }

                daoOrder dOrder = new daoOrder();
                return dOrder.OrderDetail_Insert(callFrom, ref dtDetail);
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
                daoOrder dOrder = new daoOrder();
                return dOrder.OrderDetail_Update(callFrom, ref dtOrderDetail);
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
                daoOrder dOrder = new daoOrder();
                return dOrder.Update(callFrom, ref dtOrder);
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
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update_WarehouseSubtract(string CallBy, ref DataTable dtOrder)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoOrder dOrder = new daoOrder();
                DataTable WarehouseRollback = null;

                DataTable dtMaterials = new DataTable();
                string result = dOrder.GetMaterials(callFrom, ref dtMaterials, dtOrder.Rows[0]["ID"].ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
                    return "Exception : " + result;
                }

                DataTable dtWarehouse_All = new DataTable();
                result = dOrder.GetWarehouse_All(callFrom, ref dtWarehouse_All);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
                    return "Exception : " + result;
                }

                DataTable dtWarehouse_All_Check = dtWarehouse_All.Copy();

                WarehouseRollback = new DataTable();
                WarehouseRollback.TableName = "WarehouseRollback";
                WarehouseRollback.Columns.Add("ID", typeof(int));
                WarehouseRollback.Columns.Add("OrderID", typeof(int));
                WarehouseRollback.Columns.Add("WarehouseID", typeof(int));
                WarehouseRollback.Columns.Add("QuantitySubtract", typeof(decimal));

                foreach (DataRow drM in dtMaterials.Rows)
                {
                    decimal quantityM = decimal.Parse(drM["Quantity"].ToString());
                    foreach (DataRow drW in dtWarehouse_All.Rows)
                    {
                        if (drW["MaterialsID"].ToString() == drM["MaterialsID"].ToString() && decimal.Parse(drW["QuantityCurrent"].ToString()) > 0)
                        {
                            decimal quantityCurrent = decimal.Parse(drW["QuantityCurrent"].ToString());

                            DataRow drAdd = WarehouseRollback.NewRow();
                            drAdd["OrderID"] = dtOrder.Rows[0]["ID"];
                            drAdd["WarehouseID"] = drW["ID"];

                            if (quantityM <= quantityCurrent)
                            {
                                drAdd["QuantitySubtract"] = quantityM;
                                drW["QuantityCurrent"] = decimal.Parse(drW["QuantityCurrent"].ToString()) - quantityM;
                            }
                            else
                            {
                                drAdd["QuantitySubtract"] = quantityCurrent;
                                drW["QuantityCurrent"] = 0;
                            }

                            dtWarehouse_All.AcceptChanges();

                            WarehouseRollback.Rows.Add(drAdd);

                            quantityM = quantityM - quantityCurrent;

                            if (quantityM <= 0)
                                break;
                        }
                    }

                    if (quantityM > 0)
                    {
                        decimal vQTyM = 0;
                        foreach (DataRow drCount_M in dtMaterials.Rows)
                            if (drM["MaterialsID"].ToString() == drCount_M["MaterialsID"].ToString())
                                vQTyM = vQTyM + decimal.Parse(drCount_M["Quantity"].ToString());

                        decimal vQTyW = 0;
                        foreach (DataRow drCount_W in dtWarehouse_All_Check.Rows)
                            if (drM["MaterialsID"].ToString() == drCount_W["MaterialsID"].ToString())
                                vQTyW = vQTyW + decimal.Parse(drCount_W["QuantityCurrent"].ToString());

                        return "Nguyên liệu '" + drM["MaterialsName"].ToString() + "' không đủ số lượng để xuất\nTồn: " + vQTyW + "; Xuất: " + vQTyM;
                    }
                }

                return dOrder.Update_WarehouseSubtract(callFrom, ref dtOrder, WarehouseRollback);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        //public string Update_WarehouseSubtract(string CallBy, ref DataTable dtOrder)
        //{
        //    string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    try
        //    {
        //        daoOrder dOrder = new daoOrder();
        //        DataTable WarehouseRollback = null;

        //        DataTable dtMaterials = new DataTable();
        //        string result = dOrder.GetMaterials(callFrom, ref dtMaterials, dtOrder.Rows[0]["ID"].ToString());
        //        if (result != Utilities.Parameters.ResultMessage)
        //        {
        //            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
        //            return "Exception : " + result;
        //        }

        //        WarehouseRollback = new DataTable();
        //        WarehouseRollback.TableName = "WarehouseRollback";
        //        WarehouseRollback.Columns.Add("ID", typeof(int));
        //        WarehouseRollback.Columns.Add("OrderID", typeof(int));
        //        WarehouseRollback.Columns.Add("WarehouseID", typeof(int));
        //        WarehouseRollback.Columns.Add("QuantitySubtract", typeof(decimal));

        //        foreach (DataRow drM in dtMaterials.Rows)
        //        {
        //            DataTable dtWarehouse = new DataTable();
        //            result = dOrder.GetWarehouse(callFrom, ref dtWarehouse, drM["MaterialsID"].ToString());
        //            if (result != Utilities.Parameters.ResultMessage)
        //            {
        //                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + result);
        //                return "Exception : " + result;
        //            }

        //            decimal totalW = 0;
        //            decimal quantityM = decimal.Parse(drM["Quantity"].ToString());
        //            foreach (DataRow drW in dtWarehouse.Rows)
        //            {
        //                decimal quantityCurrent = decimal.Parse(drW["QuantityCurrent"].ToString());
        //                totalW = totalW + quantityCurrent;

        //                DataRow drAdd = WarehouseRollback.NewRow();
        //                drAdd["OrderID"] = dtOrder.Rows[0]["ID"];
        //                drAdd["WarehouseID"] = drW["ID"];

        //                if (quantityM <= quantityCurrent)
        //                {
        //                    drAdd["QuantitySubtract"] = quantityM;
        //                }
        //                else
        //                {
        //                    drAdd["QuantitySubtract"] = quantityCurrent;
        //                }

        //                WarehouseRollback.Rows.Add(drAdd);

        //                quantityM = quantityM - quantityCurrent;

        //                if (quantityM <= 0)
        //                    break;
        //            }

        //            if (quantityM > 0)
        //                return "Nguyên liệu '" + drM["MaterialsName"].ToString() + "' không đủ số lượng để xuất\nTồn: " + totalW + "; Xuất: " + decimal.Parse(drM["Quantity"].ToString());
        //        }

        //        return dOrder.Update_WarehouseSubtract(callFrom, ref dtOrder, WarehouseRollback);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
        //        return "Exception : " + ex.Message;
        //    }
        //}

        /// <summary>
        /// Gộp Order
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="OrderID">Mã Order giữ lại</param>
        /// <param name="OrderMergeID">Mã Order gộp</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Merge(string CallBy, string OrderID, string OrderMergeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoGeneralFunctions dGeneral = new daoGeneralFunctions();

                #region dtOrder

                DataTable dtOrder = new DataTable();
                string result = dGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { OrderID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Order_GetByCondition:\n" + result);
                    return result + "\n" + callFrom + " -> Order_GetByCondition";
                }

                dtOrder.Rows[0]["MergedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrder.Rows[0]["MergedDate"] = DateTime.Now;
                dtOrder.TableName = "Orders";

                #endregion

                #region dtOrderDetails

                DataTable dtOrderDetails = new DataTable();
                result = dGeneral.GetByCondition(callFrom, ref dtOrderDetails, "OrdersDetail", new string[] { "OrderID" }, new string[] { OrderMergeID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> OrderDetails_GetByCondition:\n" + result);
                    return result + "\n" + callFrom + " -> OrderDetails_GetByCondition";
                }

                foreach (DataRow dr in dtOrderDetails.Rows)
                    dr["OrderID"] = int.Parse(OrderID);

                dtOrderDetails.TableName = "OrdersDetail";

                #endregion

                daoOrder dOrder = new daoOrder();
                return dOrder.Merge(callFrom, ref dtOrder,ref dtOrderDetails, OrderMergeID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
