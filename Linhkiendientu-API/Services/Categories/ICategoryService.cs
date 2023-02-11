using Linhkiendientu_API.Services.Categories.Dto;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll(PageAndSearch pageAndSearch);
        CategoryDto GetById(int id);
        CreateCategoryDto Create(CreateCategoryDto model);
        EditCategoryDto Update(EditCategoryDto model);
        bool Delete(int id);
    }
}
