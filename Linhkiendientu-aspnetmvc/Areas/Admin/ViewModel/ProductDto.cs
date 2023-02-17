using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.ViewModel
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Giá tiền")]
        public float Price { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }
    }
}
