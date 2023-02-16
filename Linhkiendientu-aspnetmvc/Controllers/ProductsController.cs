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
    public class ProductsController : Controller
    {
        private readonly BanHangDbContext _context;

        public ProductsController(BanHangDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var list1 = await products.Where(e => e.c.Id == 2).Take(20).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Category = m.c.Name
                    }
                ).ToListAsync();
            var cate = await _context.Categories.Where(x => x.Id == 2).FirstOrDefaultAsync();
            return View(new ProductCategory
            {
                ListProductViewModel1 = list1 ?? new List<ProductViewModel>(),
                Category = cate.Name ?? ""
            });
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            
            var product = _context.Products
                .Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c })
                .Join(_context.OrderDetailIns, podi => podi.pcp.p.Id, odi => odi.ProductId, (podi, odi) => new {podi, odi})
                .Join(_context.OrderIns, pod => pod.odi.OrderInId, oi => oi.Id, (pod, oi) => new {pod, oi})
                .Join(_context.Suppliers, ps => ps.oi.SupplierId, s => s.Id, (ps, s) => new {ps, s})
                ;
            var prd = await product.Where(e => e.ps.pod.podi.pcp.p.Id == id).Select(
                    m => new ProductDetailViewModel
                    {
                        Id = m.ps.pod.podi.pcp.p.Id,
                        Image = m.ps.pod.podi.pcp.p.Image,
                        CategoryId = m.ps.pod.podi.c.Id,
                        Category = m.ps.pod.podi.c.Name,
                        SupplierId = m.s.Id,
                        Supplier = m.s.Name,
                        NameP = m.ps.pod.podi.pcp.p.Name,
                        Price = m.ps.pod.podi.pcp.p.Price,
                        Quantity = m.ps.pod.podi.pcp.p.Quantity,
                        ShortDesc = m.ps.pod.podi.pcp.p.ShortDesc,
                        LongDesc = m.ps.pod.podi.pcp.p.LongDesc,
                    }
                ).FirstOrDefaultAsync();

            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var listPrdCateCDM = await products.Where(e => e.c.Id == prd.CategoryId).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).ToListAsync();
            var listPrdCateMV = await products.Where(e => e.c.Id == prd.CategoryId).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).Take(5).ToListAsync();
            var imgprd = await _context.ImageProducts.Where(x => x.ProductId == id).ToListAsync();
            
            prd.productViewModelsCungDanhMuc = listPrdCateCDM ?? new List<ProductViewModel>();
            prd.productViewModelsMoiVe = listPrdCateMV ?? new List<ProductViewModel>();
            prd.imageProducts = imgprd ?? new List<ImageProduct>();
            
            if (prd == null)
            {
                return NotFound();
            }
            return View(prd);
        }
        [Route("Search")]
        public async Task<IActionResult> Search(string q)
        {
            string query = q;
            if (query == null || _context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products;
            var list1 = await products.Where(e => e.Name.Contains(query)).Take(20).Select(
                    m => new ProductViewModel
                    {
                        Id = m.Id,
                        Image = m.Image,
                        NameP = m.Name,
                        Price = m.Price,
                    }
                ).ToListAsync();
            return View(new ProductCategory
            {
                ListProductViewModel1 = list1 ?? new List<ProductViewModel>(),
                Category = "Tìm kiếm " + query ?? ""
            });
        }
    }
}
