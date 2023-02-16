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
            /*var products = await _context.Products.Join(_context.CategoryProducts, p =>p.Id, cp=> cp.ProductId, (p,cp) => new {p, cp})
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp,c) => new {pcp,c}).Where(e => e.c.Id == 1).Select(
                    m => new ProductViewModel {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();*/
            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var list1 = await products.Where(e => e.c.Id == 1).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();
            var list2 = await products.Where(e => e.c.Id == 2).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();
            var list3 = await products.Where(e => e.c.Id == 3).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();
            var list4 = await products.Where(e => e.c.Id == 4).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();
            var list5 = await products.Where(e => e.c.Id == 5).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price
                    }
                ).ToListAsync();
            return View(new ProductCategory
              {
                  ListProductViewModel1 = list1,
                  ListProductViewModel2 = list2,
                  ListProductViewModel3 = list3,
                  ListProductViewModel4 = list4,
                  ListProductViewModel5 = list5,
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
            if (listPrdCateCDM == null)
            {
                prd.productViewModelsCungDanhMuc = new List<ProductViewModel>();
            } else
            {
                prd.productViewModelsCungDanhMuc = listPrdCateCDM;
            }
            if (listPrdCateMV == null)
            {
                prd.productViewModelsMoiVe = new List<ProductViewModel>();
            }
            else
            {
                prd.productViewModelsMoiVe = listPrdCateMV;
            }
            if (imgprd == null)
            {
                prd.imageProducts = new List<ImageProduct>();
            }
            else
            {
                prd.imageProducts = imgprd;
            }
            if (prd == null)
            {
                return NotFound();
            }
            return View(prd);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity,ShortDesc,LongDesc,Image,Url,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,ShortDesc,LongDesc,Image,Url,IsDeleted")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'BanHangDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.Id == id);
        }
    }
}
