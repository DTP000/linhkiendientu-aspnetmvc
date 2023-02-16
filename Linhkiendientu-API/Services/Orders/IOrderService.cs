using Linhkiendientu_API.Services.Orders.Dto;

namespace Linhkiendientu_API.Services.Orders
{
    public interface IOrderService
    {
        OrderDtoView GetAll(PageAndSearch pageAndSearch);
        OrderViewApiObject GetById(int id);
        Task<OrderViewApiObject> Create(CreateOrderDto model);
        Task<OrderViewApiObject> Update(EditOrderDto model);
        OrderViewApiObject Delete(int id);
    }
}
