
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.ViewModel
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public float Price { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        public string? ShortDesc { get; set; }
        public string? LongDesc { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
    }
}
