using Linhkiendientu_API.Services.Orders.Dto;

namespace Linhkiendientu_API.Services.Orders.Dto
{
    public class OrderDtoView
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<OrderDto> data { get; set; }
    }

    public class OrderViewApiObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public OrderDto data { get; set; }
    }
}
