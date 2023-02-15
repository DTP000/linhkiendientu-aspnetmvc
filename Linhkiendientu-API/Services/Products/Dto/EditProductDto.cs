using TestThuVien.Entity.Common;

namespace Linhkiendientu_API.Services.Products.Dto
{
    public class EditProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
