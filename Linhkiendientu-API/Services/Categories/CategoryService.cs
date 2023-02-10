using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Services.Categories.Dto;
using System;
using System.Collections.Generic;
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
        public IEnumerable<CategoryDto> GetAll()
        {
            var list = _context.Categories.ToArray();
            List<CategoryDto> listDto = new List<CategoryDto>();
            _mapper.Map(list, listDto);
            return listDto;
        }

        public CreateCategoryDto Create(CreateCategoryDto model)
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

        public int Update(EditCategoryDto model)
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
