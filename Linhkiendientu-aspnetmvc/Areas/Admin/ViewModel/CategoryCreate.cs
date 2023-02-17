using System.ComponentModel.DataAnnotations;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.ViewModel
{
    public class CategoryCreate
    {
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [Display(Name = "Tên Danh Mục")]
        public string Name { get; set; }
    }
}
