using TestThuVien.Entity.Common;

namespace Linhkiendientu_API.Services.Categories.Dto
{
    public class EditCategoryDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IsDelete IsDeleted { get; set; }
    }
}
