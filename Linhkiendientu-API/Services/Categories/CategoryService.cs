using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Migrations;
using Linhkiendientu_API.Services.Categories.Dto;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public async Task<List<CategoryDto>> GetAll(PageAndSearch pageAndSearch)
        {
            var list = _context.Categories
                .Where(x=>x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED)
                .ToList();
            if (!String.IsNullOrEmpty(pageAndSearch.Keyword))
            {
                list = list.Where(x => x.Name.ToLower().Contains(pageAndSearch.Keyword.ToLower())).ToList();
            }
            var listDto = _mapper.Map<List<Category>, List<CategoryDto>>(list);
            return listDto;
        }

        public CreateCategoryDto Create(CreateCategoryDto input)
        {
            var result = _context.Categories.Any(x => x.Name == input.Name);
            if (result)
            {
                // Tên danh mục tồn tại
                throw new NotImplementedException();
            }
            var entity = _mapper.Map<CreateCategoryDto, Category>(input);
            entity.IsDeleted = TestThuVien.Entity.Common.IsDelete.NOT_DELETED;
            _context.Categories.Add(entity);
            _context.SaveChangesAsync();
            return input;

        }

        public EditCategoryDto Update(EditCategoryDto input)
        {
            var result = _context.Categories.Any(x => x.Id == x.Id);
            if (!result)
            {
                // Danh mục không tồn tại
                throw new NotImplementedException();
            }
            var entity = _mapper.Map<EditCategoryDto, Category>(input);
            _context.Categories.Update(entity);
            _context.SaveChangesAsync();
            return input;
        }

        public CategoryDto GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                // Danh mục không tồn tại
                throw new NotImplementedException();
            }
            var categoryDto = _mapper.Map<Category, CategoryDto>(category);
            return categoryDto;
        }
        public bool Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                // Danh mục không tồn tại
                return false;
            }
            category.IsDeleted = TestThuVien.Entity.Common.IsDelete.DELETED;
            _context.Categories.Update(category);
            _context.SaveChangesAsync();
            return true;
        }
    }
}
