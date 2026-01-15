using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoMenu
    {
        /// <summary>
        /// Cập nhật MenuAndMaterials
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtMenuAndMaterials">Nguyên liệu mới, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtMenuAndMaterials_Old">Nguyên liệu cũ, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string MenuAndMaterials_Update(string CallBy, ref DataTable dtMenuAndMaterials, DataTable dtMenuAndMaterials_Old)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = "";
                foreach (DataRow dr in dtMenuAndMaterials_Old.Rows)
                {
                    result = DataProvider.DeleteByID(callFrom, con, sqlTrans, "MenuAndMaterials", dr["ID"].ToString());
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();
                        return result;
                    }
                }

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtMenuAndMaterials, true);
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
        /// Thêm MenuAndMaterials
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtMenuAndMaterials">Nguyên liệu mới, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string MenuAndMaterials_Insert(string CallBy, ref DataTable dtMenuAndMaterials)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtMenuAndMaterials, true);
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
        /// Lấy danh sách nguyên liệu để gán cho thực đơn
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MaterialsGroupID_Exclude">Mã nhóm thực đơn bị loại trừ</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string MenuAndMaterials_GetMaterials(string CallBy, ref DataTable dtResult, string MaterialsGroupID_Exclude)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.MenuAndMaterials_GetMaterials(MaterialsGroupID_Exclude);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nguyên liệu để gán cho thực đơn
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MenuID">Mã thực đơn</param>
        /// <param name="SizeID">Mã kích cỡ</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string MenuAndMaterials_GetByMenuIDAndSizeID(string CallBy, ref DataTable dtResult, string MenuID, string SizeID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.MenuAndMaterials_GetByMenuIDAndSizeID(MenuID, SizeID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy tất cả thực đơn đang sử dụng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll_IsActive(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetAll_IsActive();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }

        }

        /// <summary>
        /// Lấy tất cả thực đơn, đủ kích cỡ đang sử dụng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll_FullSize_IsActive(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetAll_FullSize_IsActive();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }

        }

        /// <summary>
        /// Lấy danh sách nguyên liệu để gán cho thực đơn
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string MenuAndMaterials_GetAllIsActive(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.MenuAndMaterials_GetAllIsActive();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy thực đơn đang sử dụng để làm bảng giá
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string PriceList_GetIsActive(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_PriceList_GetIsActive();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nhóm thực đơn
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListGroups(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetListGroups();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách thực đơn theo nhóm
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="GroupMenuID">Mã nhóm</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByGroup(string CallBy, ref DataTable dtResult, string GroupMenuID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetByGroup(GroupMenuID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách thực đơn theo trạng thái
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="StatusID">Mã trạng thái</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByStatus_FullSize(string CallBy, ref DataTable dtResult, string StatusID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetByStatus_FullSize(StatusID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách kích cỡ
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MenuID">Mã món</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetListOfSizes(string CallBy, ref DataTable dtResult, string MenuID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.Menu_GetListOfSizes(MenuID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtMenu">Bảng chính để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <param name="vdtMenu_Size">Bảng chi tiết để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtMenu, DataTable vdtMenu_Size)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtMenu);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                DataTable dtDataDetail_Old = new DataTable();
                string vQuery = "SELECT * FROM Menu_Size WHERE MenuID = " + dtMenu.Rows[0]["ID"].ToString();
                result = DataProvider.GetDataTable(callFrom, con, sqlTrans, vQuery, ref dtDataDetail_Old);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow drOld in dtDataDetail_Old.Rows)
                {
                    #region Check to Delete

                    bool vFlagDelete = true;
                    foreach (DataRow drNew in vdtMenu_Size.Rows)
                    {
                        if (drOld["MenuID"].ToString() == drNew["MenuID"].ToString() &&
                            drOld["SizeID"].ToString() == drNew["SizeID"].ToString())
                        {
                            vFlagDelete = false;
                            break;
                        }
                    }

                    #endregion

                    if (vFlagDelete)
                    {
                        #region Delete Menu_Size

                        vQuery = "DELETE FROM Menu_Size WHERE MenuID=@MenuID AND SizeID=@SizeID";
                        using (MySqlCommand cmdDelete = new MySqlCommand(vQuery, con, sqlTrans))
                        {
                            MySqlParameter pMenuID = new MySqlParameter("@MenuID", drOld["MenuID"]);
                            cmdDelete.Parameters.Add(pMenuID);

                            MySqlParameter pSizeID = new MySqlParameter("@SizeID", drOld["SizeID"]);
                            cmdDelete.Parameters.Add(pSizeID);

                            int vResult = cmdDelete.ExecuteNonQuery();
                            if (vResult < 0)
                            {
                                sqlTrans.Rollback();
                                sqlTrans.Dispose();
                                con.Close();
                                return "Delete data detail error. Query: " + vQuery;
                            }

                            if (cmdDelete != null)
                                cmdDelete.Dispose();
                        }

                        #endregion

                        #region Delete MenuAndMaterials

                        vQuery = "DELETE FROM MenuAndMaterials WHERE MenuID=@MenuID AND SizeID=@SizeID";
                        using (MySqlCommand cmdDelete = new MySqlCommand(vQuery, con, sqlTrans))
                        {
                            MySqlParameter pMenuID = new MySqlParameter("@MenuID", drOld["MenuID"]);
                            cmdDelete.Parameters.Add(pMenuID);

                            MySqlParameter pSizeID = new MySqlParameter("@SizeID", drOld["SizeID"]);
                            cmdDelete.Parameters.Add(pSizeID);

                            int vResult = cmdDelete.ExecuteNonQuery();
                            if (vResult < 0)
                            {
                                sqlTrans.Rollback();
                                sqlTrans.Dispose();
                                con.Close();
                                return "Delete data MenuAndMaterials error. Query: " + vQuery;
                            }

                            if (cmdDelete != null)
                                cmdDelete.Dispose();
                        }

                        #endregion

                        #region Delete PriceListDetail

                        vQuery = "DELETE FROM PriceListDetail WHERE MenuID=@MenuID AND SizeID=@SizeID";
                        using (MySqlCommand cmdDelete = new MySqlCommand(vQuery, con, sqlTrans))
                        {
                            MySqlParameter pMenuID = new MySqlParameter("@MenuID", drOld["MenuID"]);
                            cmdDelete.Parameters.Add(pMenuID);

                            MySqlParameter pSizeID = new MySqlParameter("@SizeID", drOld["SizeID"]);
                            cmdDelete.Parameters.Add(pSizeID);

                            int vResult = cmdDelete.ExecuteNonQuery();
                            if (vResult < 0)
                            {
                                sqlTrans.Rollback();
                                sqlTrans.Dispose();
                                con.Close();
                                return "Delete data PriceListDetail error. Query: " + vQuery;
                            }

                            if (cmdDelete != null)
                                cmdDelete.Dispose();
                        }

                        #endregion
                    }
                }

                foreach (DataRow drNew in vdtMenu_Size.Rows)
                {
                    #region Check exist

                    bool vFlagUpdate = false;
                    foreach (DataRow drOld in dtDataDetail_Old.Rows)
                    {
                        if (drNew["MenuID"].ToString() == drOld["MenuID"].ToString() &&
                            drNew["SizeID"].ToString() == drOld["SizeID"].ToString())
                        {
                            vFlagUpdate = true;
                            break;
                        }
                    }

                    #endregion

                    if (vFlagUpdate)
                    {
                        vQuery = "UPDATE Menu_Size SET CostPrice=@CostPrice,SalePrice=@SalePrice WHERE MenuID =@MenuID AND SizeID=@SizeID";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(vQuery, con, sqlTrans))
                        {
                            foreach (DataColumn col in drNew.Table.Columns)
                            {
                                MySqlParameter parameter = new MySqlParameter("@" + col.ColumnName, drNew[col.ColumnName]);
                                cmdUpdate.Parameters.Add(parameter);
                            }

                            int vResult = cmdUpdate.ExecuteNonQuery();
                            if (vResult < 0)
                            {
                                sqlTrans.Rollback();
                                sqlTrans.Dispose();
                                con.Close();
                                return "Update data detail error. Query: " + vQuery;
                            }

                            if (cmdUpdate != null)
                                cmdUpdate.Dispose();
                        }
                    }
                    else
                    {
                        #region Insert

                        DataRow drTemp = drNew;
                        int id = DataProvider.Insert_DataRow(callFrom, con, sqlTrans, ref drTemp, false);
                        if (id <= 0)
                            result = "Insert Error: Table = " + drNew.Table.TableName + "(Error:" + id + ")";
                        else
                            result = Utilities.Parameters.ResultMessage;
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }

                        #endregion
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
