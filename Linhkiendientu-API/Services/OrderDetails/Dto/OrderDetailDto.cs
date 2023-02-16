using AutoMapper;
using TestThuVien.Entity;
using TestThuVien.Entity.Common;

namespace Linhkiendientu_API.Services.OrderDetails.Dto
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Note { get; set; }
    }
}
