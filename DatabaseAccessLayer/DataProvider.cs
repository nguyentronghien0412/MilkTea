using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class DataProvider
    {
        /// <summary>
        /// Kiểm tra kết nối đến cơ sở dữ liệu
        /// </summary>
        /// <param name="Server">Tên máy chủ</param>
        /// <param name="Port">Cổng</param>
        /// <param name="Database">Tên cơ sở dữ liệu</param>
        /// <param name="Username">Tên đăng nhập</param>
        /// <param name="Password">Mật khẩu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string TestConnectToDatabase(string Server, string Port, string Database, string Username, string Password)
        {
            string connectionString = "Server=" + Server + ";Database=" + Database + ";Port=" + Port + ";User Id=" + Username + ";Password='" + Password + "';SSL Mode=None;AllowPublicKeyRetrieval=True";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
                con.Close();
                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo câu truy vấn
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Query">Câu truy vấn</param>
        /// <param name="dtResult">Bảng dữ liệu lưu kết quả trả về; Phải có TableName</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string GetDataTable(string CallBy, string Query, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string _TableName = dtResult.TableName;

                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                dtResult = new DataTable();
                int result = da.Fill(dtResult);

                if (cmd != null)
                    cmd.Dispose();

                if (da != null)
                    da.Dispose();

                con.Close();

                dtResult.TableName = _TableName;

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo câu truy vấn có kèm Connection và Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="con">Kết nối</param>
        /// <param name="sqlTrans">Transaction để rollback</param>
        /// <param name="Query">Câu truy vấn</param>
        /// <param name="dtResult">Bảng dữ liệu lưu kết quả trả về; Phải có TableName</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string GetDataTable(string CallBy, MySqlConnection con, MySqlTransaction sqlTrans, string Query, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string _TableName = dtResult.TableName;

                MySqlCommand cmd = new MySqlCommand(Query, con, sqlTrans);
                cmd.CommandType = CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                dtResult = new DataTable();
                int result = da.Fill(dtResult);

                if (cmd != null)
                    cmd.Dispose();

                if (da != null)
                    da.Dispose();

                dtResult.TableName = _TableName;

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh có kèm Connection và Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="Query">Câu lệnh</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string ExecuteQuery(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, string Query)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlCommand cmd = new MySqlCommand(Query, Con, SqlTrans);
                cmd.CommandType = CommandType.Text;

                int result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Query = " + Query);
                    return "Error:\nQuery = \n" + Query;
                }

                if (cmd != null)
                    cmd.Dispose();

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Query">Câu lệnh</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string ExecuteQuery(string CallBy, string Query)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;

                int result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Query = " + Query);
                    return "Error:\nQuery = \n" + Query;
                }

                if (cmd != null)
                    cmd.Dispose();

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Xóa dữ liệu theo mã có kèm Connection và Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="TableName">Tên bảng dữ liệu</param>
        /// <param name="ID">Mã để xóa</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string DeleteByID(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, string TableName, string ID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string _Query = "DELETE FROM " + TableName + " WHERE ID = " + ID;

                MySqlCommand cmd = new MySqlCommand(_Query, Con, SqlTrans);
                cmd.CommandType = CommandType.Text;

                int _Result = cmd.ExecuteNonQuery();
                if (_Result < 0)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Delete from '" + TableName + "' error\nQuery:\n" + _Query);
                    return "Delete from '" + TableName + "' error\nQuery:\n" + _Query + "\n" + callFrom;
                }

                if (cmd != null)
                    cmd.Dispose();

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Xóa dữ liệu theo mã
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="TableName">Tên bảng dữ liệu</param>
        /// <param name="ID">Mã để xóa</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string DeleteByID(string CallBy, string TableName, string ID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string _Query = "DELETE FROM " + TableName + " WHERE ID = " + ID;

                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand(_Query, con);
                cmd.CommandType = CommandType.Text;

                int _Result = cmd.ExecuteNonQuery();
                if (_Result < 0)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Delete from '" + TableName + "' error\nQuery:\n" + _Query);
                    return "Delete from '" + TableName + "' error\nQuery:\n" + _Query + "\n" + callFrom;
                }

                if (cmd != null)
                    cmd.Dispose();

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thêm dữ liệu 1 dòng có kèm Connection và Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="drInsert">Dòng dữ liệu để thêm, phải có TableName</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <returns>
        /// -1: Exception
        /// -2: Không có tên bảng
        /// -3: Thực thi câu lệnh Insert lỗi
        /// 1: Thêm thành công
        /// </returns>
        public static int Insert_DataRow(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, ref DataRow drInsert, bool AutoIncremental)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (drInsert.Table.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found.\nError code: -2");
                    return -2;
                }

                #region Query

                string query = "INSERT INTO " + drInsert.Table.TableName + " (";
                string queryValues = " VALUES (";

                foreach (DataColumn col in drInsert.Table.Columns)
                {
                    if (col.ColumnName == "ID")
                    {
                        if (!AutoIncremental)
                        {
                            query = query + col.ColumnName + ",";
                            queryValues = queryValues + "@" + col.ColumnName + ",";
                        }
                    }
                    else
                    {
                        query = query + col.ColumnName + ",";
                        queryValues = queryValues + "@" + col.ColumnName + ",";
                    }
                }

                query = query.Substring(0, query.Length - 1) + ")";
                queryValues = queryValues.Substring(0, queryValues.Length - 1) + ")";

                query = query + queryValues;

                #endregion

                using (MySqlCommand cmdInsert = new MySqlCommand(query, Con, SqlTrans))
                {
                    foreach (DataColumn col in drInsert.Table.Columns)
                    {
                        MySqlParameter parameter = new MySqlParameter("@" + col.ColumnName, drInsert[col.ColumnName]);
                        cmdInsert.Parameters.Add(parameter);
                    }

                    int rs = cmdInsert.ExecuteNonQuery();
                    if (rs != 1)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Query:\n" + query + "\nReturn: " + rs + "\nError code: -3");
                        return -3;
                    }

                    if (drInsert.Table.Columns.Contains("ID"))
                    {
                        drInsert["ID"] = cmdInsert.LastInsertedId;
                        drInsert.AcceptChanges();
                    }

                    if (cmdInsert != null)
                        cmdInsert.Dispose();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Exception: " + ex.Message + "\nError code: -1");
                return -1;
            }
        }

        /// <summary>
        /// Thêm dữ liệu 1 dòng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <returns>
        /// -1: Exception
        /// -2: Không có tên bảng
        /// -3: Thực thi câu lệnh Insert lỗi
        /// 1: Thêm thành công
        /// </returns>
        public static int Insert_DataRow(string CallBy, ref DataRow drInsert, bool AutoIncremental)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (drInsert.Table.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found.\nError code: -2");
                    return -2;
                }

                #region Query

                string query = "INSERT INTO " + drInsert.Table.TableName + " (";
                string queryValues = " VALUES (";

                foreach (DataColumn col in drInsert.Table.Columns)
                {
                    if (col.ColumnName == "ID")
                    {
                        if (!AutoIncremental)
                        {
                            query = query + col.ColumnName + ",";
                            queryValues = queryValues + "@" + col.ColumnName + ",";
                        }
                    }
                    else
                    {
                        query = query + col.ColumnName + ",";
                        queryValues = queryValues + "@" + col.ColumnName + ",";
                    }
                }

                query = query.Substring(0, query.Length - 1) + ")";
                queryValues = queryValues.Substring(0, queryValues.Length - 1) + ")";

                query = query + queryValues;

                #endregion

                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();

                using (MySqlCommand cmdInsert = new MySqlCommand(query, con))
                {
                    foreach (DataColumn col in drInsert.Table.Columns)
                    {
                        MySqlParameter parameter = new MySqlParameter("@" + col.ColumnName, drInsert[col.ColumnName]);
                        cmdInsert.Parameters.Add(parameter);
                    }

                    int rs = cmdInsert.ExecuteNonQuery();
                    if (rs != 1)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Query:\n" + query + "\nReturn: " + rs + "\nError code: -3");
                        return -3;
                    }

                    if (drInsert.Table.Columns.Contains("ID"))
                    {
                        drInsert["ID"] = cmdInsert.LastInsertedId;
                        drInsert.AcceptChanges();
                    }

                    if (cmdInsert != null)
                        cmdInsert.Dispose();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Exception: " + ex.Message + "\nError code: -1");
                return -1;
            }
        }

        /// <summary>
        /// Thêm dữ liệu 1 bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtInsert">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string Insert_Table(string CallBy, ref DataTable dtInsert, bool AutoIncremental)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtInsert.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found");
                    return "TableName not found\n"+ callFrom;
                }

                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                foreach (DataRow drInsert in dtInsert.Rows)
                {
                    DataRow drTemp = drInsert;
                    int _Result = Insert_DataRow(CallBy, con, sqlTrans, ref drTemp, AutoIncremental);
                    if (_Result <= 0)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Insert Error\nTableName: " + dtInsert.TableName + "\nReturn: " + _Result);
                        return "Insert Error\nTableName: " + dtInsert.TableName + "\nReturn: " + _Result + "\n" + callFrom;
                    }

                    if (dtInsert.Columns.Contains("ID"))
                    {
                        drInsert["ID"] = drTemp["ID"];
                        drInsert.AcceptChanges();
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
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Thêm dữ liệu 1 bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="dtInsert">Bảng dữ liệu để thêm, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="AutoIncremental">ID cấp tự động tăng. Có = True, Không = False</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string Insert_Table(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, ref DataTable dtInsert, bool AutoIncremental)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtInsert.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found");
                    return "TableName not found\n" + callFrom;
                }

                foreach (DataRow drInsert in dtInsert.Rows)
                {
                    DataRow drTemp = drInsert;
                    int _Result = Insert_DataRow(CallBy, Con, SqlTrans, ref drTemp, AutoIncremental);
                    if (_Result <= 0)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Insert Error\nTableName: " + dtInsert.TableName + "\nReturn: " + _Result);
                        return "Insert Error\nTableName: " + dtInsert.TableName + "\nReturn: " + _Result + "\n" + callFrom;
                    }

                    if (dtInsert.Columns.Contains("ID"))
                    {
                        drInsert["ID"] = drTemp["ID"];
                        drInsert.AcceptChanges();
                    }
                }

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu 1 dòng theo Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="drUpdate">Dòng dữ liệu để cập nhật, phải có TableName</param>
        /// <returns>
        /// -1: Exception
        /// -2: Không có tên bảng
        /// -3: Thực thi câu lệnh Insert lỗi
        /// 1: Thành công
        /// </returns>
        public static int Update_DataRow_ByID(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, DataRow drUpdate)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (drUpdate.Table.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found.\nError code: -2");
                    return -2;
                }

                #region Query

                string ColumnID = "ID";
                string query = "UPDATE " + drUpdate.Table.TableName + " SET ";

                foreach (DataColumn col in drUpdate.Table.Columns)
                    if (col.ColumnName != ColumnID)
                        query = query + col.ColumnName + " = @" + col.ColumnName + ",";

                query = query.Substring(0, query.Length - 1);
                query = query + " WHERE " + ColumnID + " = @" + ColumnID;

                #endregion

                using (MySqlCommand cmdUpdate = new MySqlCommand(query, Con, SqlTrans))
                {
                    foreach (DataColumn col in drUpdate.Table.Columns)
                    {
                        MySqlParameter parameter = new MySqlParameter("@" + col.ColumnName, drUpdate[col.ColumnName]);
                        cmdUpdate.Parameters.Add(parameter);
                    }

                    int rs = cmdUpdate.ExecuteNonQuery();
                    if (rs < 0)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Query:\n" + query + "\nReturn: " + rs + "\nError code: -3");
                        return -3;
                    }

                    if (cmdUpdate != null)
                        cmdUpdate.Dispose();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Exception: " + ex.Message + "\nError code: -1");
                return -1;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtUpdate">Bảng dữ liệu để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string Update_DataTable_ByID(string CallBy, ref DataTable dtUpdate)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtUpdate.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found");
                    return "TableName not found\n" + callFrom;
                }

                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                foreach (DataRow drUpdate in dtUpdate.Rows)
                {
                    int _Result = Update_DataRow_ByID(CallBy, con, sqlTrans, drUpdate);
                    if (_Result <= 0)
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Update Error\nTableName: " + dtUpdate.TableName + "\nReturn: " + _Result);
                        return "Update Error->TableName: " + dtUpdate.TableName + "\nReturn: " + _Result + "\n" + callFrom;
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
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu 1 bảng theo Transaction
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="Con">Kết nối</param>
        /// <param name="SqlTrans">Transaction để rollback</param>
        /// <param name="dtUpdate">Bảng dữ liệu để cập nhật, phải có TableName: Tên bảng sẽ cập nhật dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public static string Update_DataTable_ByID(string CallBy, MySqlConnection Con, MySqlTransaction SqlTrans, ref DataTable dtUpdate)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (dtUpdate.TableName == "")
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "TableName not found");
                    return "TableName not found\n" + callFrom;
                }

                foreach (DataRow drUpdate in dtUpdate.Rows)
                {
                    int _Result = Update_DataRow_ByID(CallBy, Con, SqlTrans, drUpdate);
                    if (_Result <= 0)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + "Update Error\nTableName: " + dtUpdate.TableName + "\nReturn: " + _Result);
                        return "Update Error->TableName: " + dtUpdate.TableName + "\nReturn: " + _Result + "\n" + callFrom;
                    }
                }

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message + "\n" + callFrom;
            }
        }
    }
}
