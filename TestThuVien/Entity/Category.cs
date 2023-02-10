using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IsDelete IsDeleted { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
