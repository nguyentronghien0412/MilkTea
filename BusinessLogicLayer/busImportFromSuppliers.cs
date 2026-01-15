using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busImportFromSuppliers
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
                DateTime dateFrom = new DateTime(ImportedDateFrom.Year, ImportedDateFrom.Month, ImportedDateFrom.Day, 0, 0, 0);
                DateTime dateTo = new DateTime(ImportedDateTo.Year, ImportedDateTo.Month, ImportedDateTo.Day, 23, 59, 59);

                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.GetWarehouse(callFrom, ref dtResult, dateFrom, dateTo);
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
                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.GetPriceNearest(callFrom, ref dtResult, MaterialsID, ImportFromSuppliersID_Exclude);
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
                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.GetPriceNearest(callFrom, ref dtResult, MaterialsID);
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
                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.GetMaterials(callFrom, ref dtResult);
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
                dtImportFromSuppliers.Rows[0]["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtImportFromSuppliers.Rows[0]["CreatedDate"] = DateTime.Now;

                DataTable dtDetail = dtWarehouse.Copy();

                if (dtDetail.Columns.Contains("QuantityStyle"))
                    dtDetail.Columns.Remove("QuantityStyle");

                if (dtDetail.Columns.Contains("QuantityImport_UnitMax"))
                    dtDetail.Columns.Remove("QuantityImport_UnitMax");

                if (dtDetail.Columns.Contains("PriceImportOld"))
                    dtDetail.Columns.Remove("PriceImportOld");

                foreach (DataRow dr in dtDetail.Rows)
                    dr["QuantityCurrent"] = dr["QuantityImport"];

                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.Insert(callFrom, ref dtImportFromSuppliers, ref dtDetail);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }

        /// <summary>
        /// cập nhật nhập hàng
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
                dtImportFromSuppliers.Rows[0]["LastUpdatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtImportFromSuppliers.Rows[0]["LastUpdatedDate"] = DateTime.Now;

                DataTable dtDetail = dtWarehouse.Copy();

                if (dtDetail.Columns.Contains("QuantityStyle"))
                    dtDetail.Columns.Remove("QuantityStyle");

                if (dtDetail.Columns.Contains("QuantityImport_UnitMax"))
                    dtDetail.Columns.Remove("QuantityImport_UnitMax");

                if (dtDetail.Columns.Contains("PriceImportOld"))
                    dtDetail.Columns.Remove("PriceImportOld");

                foreach (DataRow dr in dtDetail.Rows)
                {
                    dr["QuantityCurrent"] = dr["QuantityImport"];
                    dr["ImportFromSuppliersID"] = dtImportFromSuppliers.Rows[0]["ID"];
                }

                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.Update(callFrom, dtImportFromSuppliers, dtDetail);
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
                daoImportFromSuppliers dImport = new daoImportFromSuppliers();
                return dImport.Approved(callFrom, dtImportFromSuppliers, dtWarehouse);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
