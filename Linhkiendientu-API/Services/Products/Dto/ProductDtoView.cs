using Linhkiendientu_API.Services.Products.Dto;

namespace Linhkiendientu_API.Services.Products.Dto
{
    public class ProductDtoView
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<ProductDto> data { get; set; }
    }

    public class ProductViewApiObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public ProductDto data { get; set; }
    }
}
