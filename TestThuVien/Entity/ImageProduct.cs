using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class ImageProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
        public IsDelete IsDelete { get; set; }
    }
}
