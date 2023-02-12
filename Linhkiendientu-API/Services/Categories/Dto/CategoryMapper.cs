﻿using AutoMapper;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Categories.Dto
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<EditCategoryDto, Category>();
        }
    }
}