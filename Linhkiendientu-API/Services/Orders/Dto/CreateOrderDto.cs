
using TestThuVien.Entity.Common;

namespace Linhkiendientu_API.Services.Orders.Dto
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        /*public User User { get; set; }*/
        public string ShipUnit { get; set; }
        public string ShipCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime Finish { get; set; }
        public int StaffId { get; set; }
        /* public User Staff { get; set; }*/
        public float ShipPrice { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public string Response { get; set; }
        /*public OrderStatus OrderStatus { get; set; }*/
    }
}
