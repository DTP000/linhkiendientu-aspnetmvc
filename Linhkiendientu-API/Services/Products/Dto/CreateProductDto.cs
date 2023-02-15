
namespace Linhkiendientu_API.Services.Products.Dto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
