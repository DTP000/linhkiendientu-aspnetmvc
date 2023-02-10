using Linhkiendientu_aspnetmvc.Models.Common;

namespace Linhkiendientu_aspnetmvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IsDelete IsDeleted { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
