using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Services.Products.Dto;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Products
{
    public class ProductService : IProductService
    {
        private BanHangDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(
            BanHangDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDtoView GetAll(PageAndSearch pageAndSearch)
        {
            try
            {
                var list = _context.Products
                    .Where(x => x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED)
                    .ToList();
                if (!String.IsNullOrEmpty(pageAndSearch.Keyword))
                {
                    list = list.Where(x => x.Name.ToLower().Contains(pageAndSearch.Keyword.ToLower()))
                        .ToList();
                }
                var listDto = _mapper.Map<List<Product>, List<ProductDto>>(list);

                return new ProductDtoView
                {
                    message = "Thành Công",
                    data = listDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new ProductDtoView
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }

        public async Task<ProductViewApiObject> Create(CreateProductDto input)
        {
            try
            {
                var result = _context.Products.Any(x => x.Name == input.Name);
                if (result)
                {
                    return new ProductViewApiObject
                    {
                        message = "Tên sản phẩm đã có sẵn",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<CreateProductDto, Product>(input);
                entity.IsDeleted = TestThuVien.Entity.Common.IsDelete.NOT_DELETED;
                _context.Products.Add(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Products.FirstOrDefault(x=> x.Name == entity.Name);
                var entityDto = _mapper.Map<Product, ProductDto>(dto);
                return new ProductViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new ProductViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public async Task<ProductViewApiObject> Update(EditProductDto input)
        {
            try
            {
                var result = _context.Products.Any(x => x.Id == input.Id && x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED);
                if (!result)
                {
                    return new ProductViewApiObject
                    {
                        message = "Mã sản phẩm không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<EditProductDto, Product>(input);
                _context.Products.Update(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Products.FirstOrDefault(x => x.Name == entity.Name);
                var entityDto = _mapper.Map<Product, ProductDto>(dto);
                return new ProductViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                }; 
            }
            catch (Exception ex)
            {
                return new ProductViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public ProductViewApiObject GetById(int id)
        {
            try
            {
                var entity = _context.Products.Where(x => x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED && x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return new ProductViewApiObject
                    {
                        message = "Mã sản phẩm không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entityDto = _mapper.Map<Product, ProductDto>(entity);

                return new ProductViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new ProductViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public ProductViewApiObject Delete(int id)
        {
            try
            {
                var entity = _context.Products.Where(x=>x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED && x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return new ProductViewApiObject
                    {
                        message = "Mã sản phẩm không tồn tại",
                        data = null,
                        success = false
                    };
                }
                entity.IsDeleted = TestThuVien.Entity.Common.IsDelete.DELETED;
                _context.Products.Update(entity);
                _context.SaveChangesAsync();
                return new ProductViewApiObject
                {
                    message = "Thành Công",
                    data = null,
                    success = true
                };
            } catch (Exception ex)
            {
                return new ProductViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
    }
}
