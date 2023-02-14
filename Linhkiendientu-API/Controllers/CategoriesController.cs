using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Linhkiendientu_API.Services.Categories;
using Linhkiendientu_API.Services.Categories.Dto;
using Microsoft.AspNetCore.Cors;

namespace Linhkiendientu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<CategoryDtoView>> GetCategories([FromQuery]PageAndSearch pageAndSearch)
        {
           return  _categoryService.GetAll(pageAndSearch);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewApiObject>> GetCategory(int id)
        {
            return _categoryService.GetById(id);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewApiObject>> PutCategory(EditCategoryDto editCategory)
        {
            return _categoryService.Update(editCategory);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryViewApiObject>> PostCategory(CreateCategoryDto createCategory)
        {
            return _categoryService.Create(createCategory);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryViewApiObject>> DeleteCategory(int id)
        {
            return _categoryService.Delete(id);
        }
    }
}
