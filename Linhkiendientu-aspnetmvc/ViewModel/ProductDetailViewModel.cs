using TestThuVien.Entity;
using Linhkiendientu_aspnetmvc.ViewModel;
namespace Linhkiendientu_aspnetmvc.ViewModel
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SupplierId { get; set; }
        public string Supplier { get; set; }
        public string NameP { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public ICollection<ImageProduct> imageProducts { get; set; }
        public List<ProductViewModel> productViewModelsMoiVe { get; set; }
        public List<ProductViewModel> productViewModelsCungDanhMuc { get; set; }

    }
}
