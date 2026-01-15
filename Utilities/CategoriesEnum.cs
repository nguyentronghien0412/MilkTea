using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class CategoriesEnum
    {
        public enum Overtime_Status
        {
            Chưa_duyệt = 1,
            Đã_duyệt = 2,
            Đã_tính_lương = 3

        }
        public enum Suppliers
        {
            Mua_lẻ = 1
        }

        public enum ImportFromSuppliersStatus
        {
            Chờ_duyệt = 1,
            Đã_nhập_kho = 2
        }

        public enum MaterialsGroup
        {
            Vật_tư_và_Thiết_bị = 1,
            Nguyên_liệu = 2,
            Nước_uống = 3
        }

        public enum MaterialsStatus
        {
            Đang_sử_dụng = 1,
            Tạm_ngưng = 2
        }

        public enum Status
        {
            Đang_hoạt_động = 1,
            Tạm_ngưng = 2
        }

        public enum StatusOfDinnerTable
        {
            Đang_sử_dụng = 1,
            Đang_sửa_chữa = 2,
            Ngưng_phục_vụ = 3
        }

        public enum StatusOfOrder
        {
            Chưa_thanh_toán = 1,
            Đã_thu_tiền = 2,
            Hủy = 3,
            Chưa_thu_tiền = 4
        }

        public enum StatusOfPriceList
        {
            Chưa_phát_hành = 1,
            Đang_hiện_hành = 2,
            Hết_hạn = 3
        }

        public enum StatusOfPromotion
        {
            Chưa_có_hiệu_lực = 1,
            Đang_có_hiệu_lực = 2,
            Hết_hiệu_lực = 3,
            Hết_hạn = 4
        }

        public enum Currency
        {
            Việt_nam_đồng = 1
        }

        public enum CollectAndSpendGroup
        {
            Tiền_chi = 1,
            Tiền_thu = 2
        }

        public enum MenuGroup
        {
            Lẩu = 1,
            Nướng_than_hoa = 2
        }

        public enum KindOfHotpot
        {
            Tomyum = 1,
            Tứ_xuyên = 2,
            Kim_chi = 3,
            Trường_thọ = 4,
            Thập_cẩm = 5,
            Gà_lá_giang = 6,
            Gà_lá_é = 7
        }

        public enum Employees
        {
            Administrator = 1
        }

        public enum AttendanceData_Status
        {
            Chưa_tính_lương = 1,
            Đã_tính_lương = 2,
            Đã_hủy = 3
        }

        public enum AttendanceData_RecordType
        {
            Giờ_vào = 1,
            Giờ_ra = 2
        }

        public enum Payroll_Status
        {
            Chưa_thanh_toán = 1,
            Đã_thanh_toán = 2
        }
    }
}
