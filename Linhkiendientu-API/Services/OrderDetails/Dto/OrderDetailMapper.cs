using AutoMapper;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.OrderDetails.Dto
{
    public class OrderDetailMapper : Profile
    {
        public OrderDetailMapper()
        {
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();
            CreateMap<EditOrderDetailDto, OrderDetail>();
        }
    }
}
