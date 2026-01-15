using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoGeneralFunctions
    {
        /// <summary>
        /// Lấy tất cả dữ liệu trong 1 bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="TableName">Tên bảng lấy dữ liệu</param>
        /// <param name="OrderBy">Sắp xếp theo tiêu chí</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetAll(string CallBy, ref DataTable dtResult, string TableName, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries_GeneralFunctions.GetAll(TableName, OrderBy);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
        /// <param name="FieldName">Danh sách Tên cột so sánh</param>
        /// <param name="Value">Danh sách Giá trị so sánh</param>
        /// <param name="OrderBy">Sắp xếp theo tiêu chí</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByCondition(string CallBy, ref DataTable dtResult, string TableName, string[] FieldName, string[] Value, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries_GeneralFunctions.GetByCondition(TableName, FieldName, Value, OrderBy);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
        /// <param name="FieldName">Danh sách Tên cột so sánh</param>
        /// <param name="Operator">Danh sách toán tử so sánh</param>
        /// <param name="Value">Danh sách Giá trị so sánh</param>
        /// <param name="OrderBy">Sắp xếp theo tiêu chí</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetByCondition(string CallBy, ref DataTable dtResult, string TableName, string[] FieldName, string[] Operator, string[] Value, string OrderBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries_GeneralFunctions.GetByCondition(TableName, FieldName, Operator, Value, OrderBy);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
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
                return DataProvider.Insert_Table(callFrom, ref dtInsert, AutoIncremental);
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtInsert, AutoIncremental);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtInsertDetail.Rows)
                    dr[ColumnParentName] = dtInsert.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtInsertDetail, AutoIncrementalDetail);
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
                return DataProvider.Update_DataTable_ByID(callFrom, ref dtUpdate);
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
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtData);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                DataTable dtDataDetail_Old = new DataTable();
                string vQuery = "SELECT * FROM " + dtDataDetail.TableName + " WHERE " + ColumnParentName + " = " + dtData.Rows[0]["ID"].ToString();
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
                    foreach (DataRow drNew in dtDataDetail.Rows)
                    {
                        bool vFlagExist = true;
                        foreach (DataColumn col in dtDataDetail.Columns)
                        {
                            if (ColumnNameToCompare.Contains(col.ColumnName) && drNew[col.ColumnName].ToString() != drOld[col.ColumnName].ToString())
                            {
                                vFlagExist = false;
                                break;
                            }
                        }
                        if (vFlagExist)
                        {
                            vFlagDelete = false;
                            break;
                        }
                    }

                    #endregion

                    if (vFlagDelete)
                    {
                        #region Query

                        vQuery = "DELETE FROM " + dtDataDetail.TableName + " WHERE ";

                        foreach (DataColumn col in drOld.Table.Columns)
                            if (ColumnNameToCompare.Contains(col.ColumnName))
                                vQuery = vQuery + col.ColumnName + " = @" + col.ColumnName + " AND ";

                        vQuery = vQuery.Substring(0, vQuery.Length - 4);

                        #endregion

                        using (MySqlCommand cmdDelete = new MySqlCommand(vQuery, con, sqlTrans))
                        {
                            foreach (DataColumn col in drOld.Table.Columns)
                            {
                                if (ColumnNameToCompare.Contains(col.ColumnName))
                                {
                                    MySqlParameter parameter = new MySqlParameter("@" + col.ColumnName, drOld[col.ColumnName]);
                                    cmdDelete.Parameters.Add(parameter);
                                }
                            }

                            int vResult = cmdDelete.ExecuteNonQuery();
                            if (vResult < 0)
                            {
                                sqlTrans.Rollback();
                                sqlTrans.Dispose();
                                con.Close();
                                return "Delete data detail error. Query: "+ vQuery;
                            }

                            if (cmdDelete != null)
                                cmdDelete.Dispose();
                        }
                    }
                }

                foreach (DataRow drNew in dtDataDetail.Rows)
                {
                    #region Check exist

                    bool vFlagInsert = true;
                    foreach (DataRow drOld in dtDataDetail_Old.Rows)
                    {
                        bool vFlagExist = true;
                        foreach (DataColumn col in dtDataDetail_Old.Columns)
                        {
                            if (ColumnNameToCompare.Contains(col.ColumnName) && drNew[col.ColumnName].ToString() != drOld[col.ColumnName].ToString())
                            {
                                vFlagExist = false;
                                break;
                            }
                        }
                        if (vFlagExist)
                        {
                            vFlagInsert = false;
                            break;
                        }
                    }

                    #endregion

                    if (!vFlagInsert)
                    {
                        #region Query

                        vQuery = "UPDATE " + drNew.Table.TableName + " SET ";

                        bool vIsUpdate = false;
                        foreach (DataColumn col in drNew.Table.Columns)
                            if (!ColumnNameToCompare.Contains(col.ColumnName))
                            {
                                vQuery = vQuery + col.ColumnName + " = @" + col.ColumnName + ",";
                                vIsUpdate = true;
                            }

                        vQuery = vQuery.Substring(0, vQuery.Length - 1);
                        vQuery = vQuery + " WHERE ";

                        foreach (DataColumn col in drNew.Table.Columns)
                            if (ColumnNameToCompare.Contains(col.ColumnName))
                                vQuery = vQuery + col.ColumnName + " = @" + col.ColumnName + " AND ";

                        vQuery = vQuery.Substring(0, vQuery.Length - 4);

                        #endregion

                        if (vIsUpdate)
                        {
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
                    }
                    else
                    {
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
                return DataProvider.DeleteByID(callFrom, TableName, ID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }
    }

    public class Queries_GeneralFunctions
    {
        public static string GetAll(string TableName, string OrderBy)
        {
            string query = @"SELECT * FROM " + TableName;
            if (OrderBy != null && OrderBy != "")
                query = query + " ORDER BY " + OrderBy;

            return query;
        }

        public static string GetByCondition(string TableName, string[] FieldName, string[] Value, string OrderBy)
        {
            string query = @"SELECT * FROM " + TableName;

            if (FieldName != null && FieldName.Length > 0)
            {
                query = query + " WHERE " + FieldName.GetValue(0).ToString() + " = " + Value.GetValue(0).ToString();

                for (int i = 1; i < FieldName.Length; i++)
                    query = query + " AND " + FieldName.GetValue(i).ToString() + " = " + Value.GetValue(i).ToString();
            }

            if (OrderBy != null && OrderBy != "")
                query = query + " ORDER BY " + OrderBy;

            return query;
        }

        public static string GetByCondition(string TableName, string[] FieldName, string[] Operator, string[] Value, string OrderBy)
        {
            string query = @"SELECT * FROM " + TableName;

            if (FieldName != null && FieldName.Length > 0)
            {
                query = query + " WHERE " + FieldName.GetValue(0).ToString() + " " + Operator.GetValue(0).ToString() + " " + Value.GetValue(0).ToString();

                for (int i = 1; i < FieldName.Length; i++)
                    query = query + " AND " + FieldName.GetValue(i).ToString() + " " + Operator.GetValue(i).ToString() + " " + Value.GetValue(i).ToString();
            }

            if (OrderBy != null && OrderBy != "")
                query = query + " ORDER BY " + OrderBy;

            return query;
        }
    }
}
