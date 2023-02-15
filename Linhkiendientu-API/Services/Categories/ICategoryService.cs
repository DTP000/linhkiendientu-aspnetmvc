using Linhkiendientu_API.Services.Categories.Dto;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Categories
{
    public interface ICategoryService
    {
        CategoryDtoView GetAll(PageAndSearch pageAndSearch);
        CategoryViewApiObject GetById(int id);
        Task<CategoryViewApiObject> Create(CreateCategoryDto model);
        Task<CategoryViewApiObject> Update(EditCategoryDto model);
        CategoryViewApiObject Delete(int id);
    }
}
