using TestThuVien.Entity.Common;
using TestThuVien.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.ViewModel
{
    public class OrderDto
    {
        public int Id { get; set; }
        /* public int UserId { get; set; }*/
        /*public string UserName { get; set; }*/
        /*public User User { get; set; }*/
        [Display(Name = "Đơn vị chuyển")]
        public string ShipUnit { get; set; }
        [Display(Name = "Mã đơn")]
        public string ShipCode { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string FullName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime Finish { get; set; }
        /*public int StaffId { get; set; }*/
        /*public Role StaffRole { get; set; }*/
        /*public User Staff { get; set; }*/
        [Display(Name = "Phí vận chuyển")]
        public float ShipPrice { get; set; }
        [Display(Name = "Tổng tiền")]
        public float TotalPrice { get; set; }
        [Display(Name = "Ghi Chú")]
        public string? Note { get; set; }
        [Display(Name = "Phản hồi")]
        public string Response { get; set; }
        [Display(Name = "Trạng thái đơn")]
        public OrderStatus OrderStatus { get; set; }
    }
}
