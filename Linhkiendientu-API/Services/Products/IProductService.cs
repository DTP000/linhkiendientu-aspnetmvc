using Linhkiendientu_API.Services.Products.Dto;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Products
{
    public interface IProductService
    {
        ProductDtoView GetAll(PageAndSearch pageAndSearch);
        ProductViewApiObject GetById(int id);
        Task<ProductViewApiObject> Create(CreateProductDto model);
        Task<ProductViewApiObject> Update(EditProductDto model);
        ProductViewApiObject Delete(int id);
    }
}
