using Linhkiendientu_API.Services.Categories.Dto;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        CategoryDto GetById(int id);
        CreateCategoryDto Create(CreateCategoryDto model);
        int Update(EditCategoryDto model);
        int Delete(int id);
    }
}
