using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
        
        [Display(Name = "Tên Danh Mục")]
        public string Name { get; set; }
    }
}
