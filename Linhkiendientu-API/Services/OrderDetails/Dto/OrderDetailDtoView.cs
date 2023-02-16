using Linhkiendientu_API.Services.OrderDetails.Dto;

namespace Linhkiendientu_API.Services.OrderDetails.Dto
{
    public class OrderDetailDtoView
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<OrderDetailDto> data { get; set; }
    }

    public class OrderDetailViewApiObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public OrderDetailDto data { get; set; }
    }
}
