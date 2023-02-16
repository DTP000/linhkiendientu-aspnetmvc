using AutoMapper;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Orders.Dto
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<EditOrderDto, Order>();
        }
    }
}
