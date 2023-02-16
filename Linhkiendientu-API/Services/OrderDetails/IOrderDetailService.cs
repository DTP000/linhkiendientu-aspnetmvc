using Linhkiendientu_API.Services.OrderDetails.Dto;

namespace Linhkiendientu_API.Services.OrderDetails
{
    public interface IOrderDetailService
    {
        OrderDetailDtoView GetAll(PageAndSearch pageAndSearch);
        OrderDetailViewApiObject GetById(int id);
        Task<OrderDetailViewApiObject> Create(CreateOrderDetailDto model);
        Task<OrderDetailViewApiObject> Update(EditOrderDetailDto model);
        OrderDetailViewApiObject Delete(int id);
    }
}
