using AutoMapper;
using Linhkiendientu_API.Data;
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
        public async Task<List<CategoryDto>> GetAll()
        {
            var list = _context.Categories.ToList();
            var listDto = _mapper.Map<List<Category>, List<CategoryDto>>(list);
            return listDto;
        }

        public CategoryDto Create(CreateCategoryDto model)
        {
            var result = _context.Categories.Any(x => x.Name == model.Name);
            if (result)
            {
                throw new NotImplementedException();
            }
            Category category = new Category();
            _mapper.Map(model, category);
            _context.Categories.Add(category);
            return model;

        }

        public CategoryDto Update(EditCategoryDto model)
        {
            var result = _context.Categories.Any(x => x.Name == model.Name || x.Id == x.Id);
            if (result)
            {
                return -1;
            }
            Category category = new Category();
            _mapper.Map(model, category);
            _context.Categories.Add(category);
            return 0;
        }

        public CategoryDto GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
