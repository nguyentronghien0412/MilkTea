using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class daoImportFromSuppliers
    {
        /// <summary>
        /// Lấy danh sách nguyên liệu
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="ImportedDateFrom">Ngày nhập từ</param>
        /// <param name="ImportedDateTo">Ngày nhập đến</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetWarehouse(string CallBy, ref DataTable dtResult, DateTime ImportedDateFrom, DateTime ImportedDateTo)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.ImportFromSuppliers_GetWarehouse(ImportedDateFrom, ImportedDateTo);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy giá nhập lần gần nhất
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MaterialsID">Mã nguyên liệu</param>
        /// <param name="ImportFromSuppliersID_Exclude">Mã nhập</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPriceNearest(string CallBy, ref DataTable dtResult, string MaterialsID, string ImportFromSuppliersID_Exclude)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.ImportFromSuppliers_GetPriceNearest(MaterialsID, ImportFromSuppliersID_Exclude);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy giá nhập lần gần nhất
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <param name="MaterialsID">Mã nguyên liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetPriceNearest(string CallBy, ref DataTable dtResult, string MaterialsID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.ImportFromSuppliers_GetPriceNearest(MaterialsID);
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Lấy danh sách nguyên liệu để nhập hàng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtResult">Bảng lưu dữ liệu trả về</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string GetMaterials(string CallBy, ref DataTable dtResult)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string query = Queries.ImportFromSuppliers_GetMaterials();
                return DataProvider.GetDataTable(callFrom, query, ref dtResult);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// Nhập hàng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtImportFromSuppliers">Thông tin phiếu nhập, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtWarehouse">Danh sách nguyên liệu, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Insert(string CallBy, ref DataTable dtImportFromSuppliers, ref DataTable dtWarehouse)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtImportFromSuppliers, true);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtWarehouse.Rows)
                    dr["ImportFromSuppliersID"] = dtImportFromSuppliers.Rows[0]["ID"];

                result = DataProvider.Insert_Table(callFrom, con, sqlTrans, ref dtWarehouse, false);
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
        /// Cập nhật nhập hàng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtImportFromSuppliers">Thông tin phiếu nhập, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtWarehouse">Danh sách nguyên liệu, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Update(string CallBy, DataTable dtImportFromSuppliers, DataTable dtWarehouse)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtImportFromSuppliers);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                DataTable dtWarehouseOld = new DataTable();
                string query = "SELECT * FROM Warehouse WHERE ImportFromSuppliersID = " + dtImportFromSuppliers.Rows[0]["ID"].ToString();
                result = DataProvider.GetDataTable(callFrom, con, sqlTrans, query, ref dtWarehouseOld);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                foreach (DataRow dr in dtWarehouseOld.Rows)
                {
                    if (!dtWarehouse.AsEnumerable().Any(row => (int)dr["ID"] == row.Field<int>("ID")))
                    {
                        result = DataProvider.DeleteByID(callFrom, con, sqlTrans, "Warehouse", dr["ID"].ToString());
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return result;
                        }
                    }
                }

                foreach (DataRow dr in dtWarehouse.Rows)
                {
                    if (dr["ID"].ToString() == "" || !dtWarehouseOld.AsEnumerable().Any(row => (int)dr["ID"] == row.Field<int>("ID")))
                    {
                        DataRow drTemp = dr;
                        int id = DataProvider.Insert_DataRow(callFrom, con, sqlTrans, ref drTemp, false);
                        if (id <= 0)
                            result = "Insert Error: Table = " + dtWarehouse.TableName + "(Error:" + id + ")";
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
                    else
                    {
                        int rs = DataProvider.Update_DataRow_ByID(callFrom, con, sqlTrans, dr);
                        if (rs != 1)
                        {
                            sqlTrans.Rollback();
                            sqlTrans.Dispose();
                            con.Close();
                            return rs.ToString();
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
        /// Duyệt nhập hàng
        /// </summary>
        /// <param name="CallBy">Nơi gọi hàm</param>
        /// <param name="dtImportFromSuppliers">Thông tin phiếu nhập, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <param name="dtWarehouse">Danh sách nguyên liệu, phải có TableName: Tên bảng sẽ thêm dữ liệu</param>
        /// <returns>Chuỗi kết quả: Thành công hoặc thất bại</returns>
        public string Approved(string CallBy, DataTable dtImportFromSuppliers, DataTable dtWarehouse)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                MySqlConnection con = new MySqlConnection(Utilities.Parameters.ConnectionString);
                con.Open();
                MySqlTransaction sqlTrans = con.BeginTransaction();

                string result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtImportFromSuppliers);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();
                    return result;
                }

                result = DataProvider.Update_DataTable_ByID(callFrom, con, sqlTrans, ref dtWarehouse);
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
    }
}
