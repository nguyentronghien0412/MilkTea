using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoPriceList
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
                string query = Queries.PriceList_IsUsing_GetMenu(MenuID, SizeID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                string query;

                if (IsExpired)
                    query = Queries.PriceList_GetByID_Expired(PriceListID);
                else
                    query = Queries.PriceList_GetByID(PriceListID);

                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtPriceList, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtPriceListDetail.Rows)
                    dr["PriceListID"] = dtPriceList.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtPriceListDetail, false);
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

        private bool CheckPriceListDetailExist(string PriceListID, string MenuID, string SizeID, DataTable dtCheck)
        {
            foreach (DataRow dr in dtCheck.Rows)
                if (PriceListID == dr["PriceListID"].ToString() && MenuID == dr["MenuID"].ToString() && SizeID == dr["SizeID"].ToString())
                    return true;
            return false;
        }

        /// <summary>
        /// Cập nhật Bảng giá
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtPriceList">Bảng giá để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <param name="dtPriceListDetail">Bảng giá chi tiết để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtPriceList, DataTable dtPriceListDetail)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtPriceList);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                DataTable dtOld = new DataTable();
                string query = "SELECT * FROM PriceListDetail WHERE PriceListID = " + dtPriceList.Rows[0]["ID"].ToString();
                result = DataProvider.GetDataTable(callFrom, con, sqlTrans, query, ref dtOld);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtOld.Rows)
                {
                    if (!CheckPriceListDetailExist(dr["PriceListID"].ToString(), dr["MenuID"].ToString(), dr["SizeID"].ToString(), dtPriceListDetail))
                    {
                        query = "DELETE FROM PriceListDetail WHERE PriceListID = " + dr["PriceListID"].ToString() + " AND MenuID = " + dr["MenuID"].ToString() + " AND SizeID = " + dr["SizeID"].ToString();
                        result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
                    }
                }

                foreach (DataRow dr in dtPriceListDetail.Rows)
                {
                    if (CheckPriceListDetailExist(dr["PriceListID"].ToString(), dr["MenuID"].ToString(), dr["SizeID"].ToString(), dtOld))
                    {
                        query = "UPDATE PriceListDetail SET Price = " + dr["Price"].ToString() + " WHERE PriceListID = " + dr["PriceListID"].ToString() + " AND MenuID = " + dr["MenuID"].ToString() + " AND SizeID = " + dr["SizeID"].ToString();
                        result = DataProvider.ExecuteQuery(callFrom, con, sqlTrans, query);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
                    }
                    else
                    {
                        DataRow drTemp = dr;
                        int id = DataProvider.Insert_DataRow(callFrom, con, sqlTrans, ref drTemp, false);
                        if (id <= 0)
                            result = "Insert Error: Table = " + dtPriceListDetail.TableName + "(Error:" + id + ")";
                        else
                            result = Utilities.Parameters.ResultMessage;
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
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
    }
}
