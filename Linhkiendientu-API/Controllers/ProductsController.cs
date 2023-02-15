using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Linhkiendientu_API.Services.Products.Dto;
using Microsoft.AspNetCore.Cors;
using Linhkiendientu_API.Services.Products;

namespace Linhkiendientu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<ProductDtoView>> GetProducts([FromQuery]PageAndSearch pageAndSearch)
        {
           return _productService.GetAll(pageAndSearch);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewApiObject>> GetProduct(int id)
        {
            return _productService.GetById(id);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductViewApiObject>> PutProduct(EditProductDto editProduct)
        {
            return _productService.Update(editProduct);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductViewApiObject>> PostProduct(CreateProductDto createProduct)
        {
            return _productService.Create(createProduct);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductViewApiObject>> DeleteProduct(int id)
        {
            return _productService.Delete(id);
        }
    }
}
