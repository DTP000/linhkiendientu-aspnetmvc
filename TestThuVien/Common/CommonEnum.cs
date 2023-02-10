using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestThuVien.Entity.Common
{
    public enum IsDelete
    {
        NOT_DELETED = 1,
        DELETED = 2
    }

    public enum Role
    {
        ADMIN = 1,
        KHANH_HANG_ONLINE = 2,
        KHANH_HANG_OFFLINE = 3,
        NHAN_VIEN = 4
    }

    public enum UserStatus
    {
        TAI_KHOAN_BINH_THUONG = 1,
        TAI_KHOAN_TAM_KHOA = 2,
        TAI_KHOAN_BI_KHOA_VINH_VIEN = 3
    }

    public enum OrderStatus
    {
        CHO_XAC_NHAN = 1,
        CHO_LAY_HANG = 2,
        DANG_GIAO = 3,
        DA_GIAO = 4,
        DA_HUY = 5,
        TRA_HANG = 6
    }
}
