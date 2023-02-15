using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Services.Categories.Dto;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private BanHangDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(
            BanHangDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoryDtoView GetAll(PageAndSearch pageAndSearch)
        {
            try
            {
                var list = _context.Categories
                    .Where(x => x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED)
                    .ToList();
                if (!String.IsNullOrEmpty(pageAndSearch.Keyword))
                {
                    list = list.Where(x => x.Name.ToLower().Contains(pageAndSearch.Keyword.ToLower())).ToList();
                }
                var listDto = _mapper.Map<List<Category>, List<CategoryDto>>(list);

                return new CategoryDtoView
                {
                    message = "Thành Công",
                    data = listDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new CategoryDtoView
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }

        public async Task<CategoryViewApiObject> Create(CreateCategoryDto input)
        {
            try
            {
                var result = _context.Categories.Any(x => x.Name == input.Name);
                if (result)
                {
                    return new CategoryViewApiObject
                    {
                        message = "Tên danh mục đã có sẵn",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<CreateCategoryDto, Category>(input);
                entity.IsDeleted = TestThuVien.Entity.Common.IsDelete.NOT_DELETED;
                _context.Categories.Add(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Categories.FirstOrDefault(x=> x.Name == entity.Name);
                var entityDto = _mapper.Map<Category, CategoryDto>(dto);
                return new CategoryViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new CategoryViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public async Task<CategoryViewApiObject> Update(EditCategoryDto input)
        {
            try
            {
                var result = _context.Categories.Any(x => x.Id == input.Id && x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED);
                if (!result)
                {
                    return new CategoryViewApiObject
                    {
                        message = "Mã danh mục không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<EditCategoryDto, Category>(input);
                _context.Categories.Update(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Categories.FirstOrDefault(x => x.Name == entity.Name);
                var entityDto = _mapper.Map<Category, CategoryDto>(dto);
                return new CategoryViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                }; 
            }
            catch (Exception ex)
            {
                return new CategoryViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public CategoryViewApiObject GetById(int id)
        {
            try
            {
                var category = _context.Categories.Where(x => x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED && x.Id == id).FirstOrDefault();
                if (category == null)
                {
                    return new CategoryViewApiObject
                    {
                        message = "Mã danh mục không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var categoryDto = _mapper.Map<Category, CategoryDto>(category);

                return new CategoryViewApiObject
                {
                    message = "Thành Công",
                    data = categoryDto,
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new CategoryViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public CategoryViewApiObject Delete(int id)
        {
            try
            {
                var category = _context.Categories.Where(x=>x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED && x.Id == id).FirstOrDefault();
                if (category == null)
                {
                    return new CategoryViewApiObject
                    {
                        message = "Mã danh mục không tồn tại",
                        data = null,
                        success = false
                    };
                }
                category.IsDeleted = TestThuVien.Entity.Common.IsDelete.DELETED;
                _context.Categories.Update(category);
                _context.SaveChangesAsync();
                return new CategoryViewApiObject
                {
                    message = "Thành Công",
                    data = null,
                    success = true
                };
            } catch (Exception ex)
            {
                return new CategoryViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
    }
}
