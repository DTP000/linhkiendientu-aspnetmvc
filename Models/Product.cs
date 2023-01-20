using Linhkiendientu_aspnetmvc.Models.Common;

namespace Linhkiendientu_aspnetmvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public IsDelete IsDeleted { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
        public ICollection<ImageProduct> ImageProducts { get; set; }
        public ICollection<OrderDetailIn> OrderDetailIns { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
