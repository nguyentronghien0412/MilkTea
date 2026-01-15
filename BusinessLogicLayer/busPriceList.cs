using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busPriceList
    {
        /// <summary>
        /// Lấy menu của bảng giá đang sử dụng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MenuID">Mã thực đơn</param>
        /// <param name="SizeID">Mã kích thước</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string IsUsing_GetMenu(string CallBy, ref DataTable dtResult, string MenuID, string SizeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPriceList dPriceList = new daoPriceList();
                return dPriceList.IsUsing_GetMenu(callFrom, ref dtResult, MenuID, SizeID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy bảng giá theo ID
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="PriceListID">Mã ID bảng giá</param>
        /// <param name="IsExpired">Bảng giá hết hạn</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByID(string CallBy, ref DataTable dtResult, string PriceListID, bool IsExpired)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                daoPriceList dPriceList = new daoPriceList();
                return dPriceList.GetByID(callFrom, ref dtResult, PriceListID, IsExpired);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Thêm Bảng giá
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtPriceList">Bảng giá để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtPriceListDetail">Bảng giá chi tiết để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtPriceList, ref DataTable dtPriceListDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtDetail = new DataTable();
                dtDetail.TableName = dtPriceListDetail.TableName;
                dtDetail.Columns.Add("PriceListID", typeof(int));
                dtDetail.Columns.Add("MenuID", typeof(int));
                dtDetail.Columns.Add("SizeID", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));

                foreach (DataRow dr in dtPriceListDetail.Rows)
                {
                    object vPrice;
                    if (dr["Price"].ToString() == "" || dr["Price"].ToString() == "0")
                        vPrice = 0;
                    else
                        vPrice = dr["Price"];

                    DataRow drAdd = dtDetail.NewRow();

                    drAdd["PriceListID"] = dr["PriceListID"];
                    drAdd["MenuID"] = dr["MenuID"];
                    drAdd["SizeID"] = dr["SizeID"];
                    drAdd["Price"] = vPrice;

                    dtDetail.Rows.Add(drAdd);
                }

                daoPriceList dPriceList = new daoPriceList();
                return dPriceList.Insert(callFrom, ref dtPriceList, ref dtDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Cập nhật Bảng giá
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtPriceList">Bảng giá để cập nhật, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtPriceListDetail">Bảng giá chi tiết để cập nhật, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtPriceList, DataTable dtPriceListDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtDetail = new DataTable();
                dtDetail.TableName = dtPriceListDetail.TableName;
                dtDetail.Columns.Add("PriceListID", typeof(int));
                dtDetail.Columns.Add("MenuID", typeof(int));
                dtDetail.Columns.Add("SizeID", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));

                foreach (DataRow dr in dtPriceListDetail.Rows)
                {
                    object vPrice;
                    if (dr["Price"].ToString() == "" || dr["Price"].ToString() == "0")
                        vPrice = 0;
                    else
                        vPrice = dr["Price"];

                    DataRow drAdd = dtDetail.NewRow();

                    drAdd["PriceListID"] = dr["PriceListID"];
                    drAdd["MenuID"] = dr["MenuID"];
                    drAdd["SizeID"] = dr["SizeID"];
                    drAdd["Price"] = vPrice;

                    dtDetail.Rows.Add(drAdd);
                }

                daoPriceList dPriceList = new daoPriceList();
                return dPriceList.Update(callFrom, dtPriceList, dtDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
