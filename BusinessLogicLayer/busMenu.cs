using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class busMenu
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
                daoMenu dMenu = new daoMenu();
                return dMenu.MenuAndMaterials_Update(callFrom, ref dtMenuAndMaterials, dtMenuAndMaterials_Old);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.MenuAndMaterials_Insert(callFrom, ref dtMenuAndMaterials);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.MenuAndMaterials_GetMaterials(callFrom, ref dtResult, MaterialsGroupID_Exclude);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.MenuAndMaterials_GetByMenuIDAndSizeID(callFrom, ref dtResult, MenuID, SizeID);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.GetAll_IsActive(callFrom, ref dtResult);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.GetAll_FullSize_IsActive(callFrom, ref dtResult);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.MenuAndMaterials_GetAllIsActive(callFrom, ref dtResult);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.PriceList_GetIsActive(callFrom, ref dtResult);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.GetListGroups(callFrom, ref dtResult);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.GetByGroup(callFrom, ref dtResult, GroupMenuID);
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
                daoMenu dMenu = new daoMenu();
                string vResult = dMenu.GetByStatus_FullSize(callFrom, ref dtResult, StatusID);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + vResult);
                    return vResult;
                }

                dtResult.Columns.Add("PrintSticker2", typeof(bool));
                foreach (DataRow dr in dtResult.Rows)
                {
                    if (dr["PrintSticker"].ToString() == "")
                        dr["PrintSticker2"] = false;
                    else
                    {
                        if (dr["PrintSticker"].ToString() == "0")
                            dr["PrintSticker2"] = false;
                        else if (dr["PrintSticker"].ToString() == "1")
                            dr["PrintSticker2"] = true;
                        else
                            dr["PrintSticker2"] = bool.Parse(dr["PrintSticker"].ToString());
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
                daoMenu dMenu = new daoMenu();
                return dMenu.GetListOfSizes(callFrom, ref dtResult, MenuID);
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
                daoMenu dMenu = new daoMenu();
                return dMenu.Update(callFrom, dtMenu, vdtMenu_Size);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return "Exception : " + ex.Message;
            }
        }
    }
}
