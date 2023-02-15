using AutoMapper;
using TestThuVien.Common;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Products.Dto
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<EditProductDto, Product>();
        }
    }
}
