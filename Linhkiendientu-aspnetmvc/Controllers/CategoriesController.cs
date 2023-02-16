using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Linhkiendientu_aspnetmvc.ViewModel;

namespace Linhkiendientu_aspnetmvc.Controllers
{
	public class CategoriesController : Controller
	{
        private readonly BanHangDbContext _context;
		public CategoriesController (BanHangDbContext context)
		{
			_context = context;
		}
        public async Task<IActionResult> Index(int? id = 2)
		{
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var list1 = await products.Where(e => e.c.Id == id).Take(20).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Category = m.c.Name
                    }
                ).ToListAsync();
            var cate = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(new ProductCategory
            {
                ListProductViewModel1 = list1 ?? new List<ProductViewModel>(),
                Category = cate.Name ?? ""
            });
        }
        public async Task<IActionResult> Details(int? id = 2)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var list1 = await products.Where(e => e.c.Id == id).Take(20).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Category = m.c.Name
                    }
                ).ToListAsync();
            var cate = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(new ProductCategory
            {
                ListProductViewModel1 = list1 ?? new List<ProductViewModel>(),
                Category = cate.Name ?? ""
            });
        }
    }
}
