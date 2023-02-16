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
using System.Collections;

namespace Linhkiendientu_aspnetmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BanHangDbContext _context;

        public HomeController(ILogger<HomeController> logger, BanHangDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Join(_context.CategoryProducts, p => p.Id, cp => cp.ProductId, (p, cp) => new { p, cp })
                .Join(_context.Categories, pcp => pcp.cp.CategoryId, c => c.Id, (pcp, c) => new { pcp, c });
            var list1 = await products.Where(e => e.c.Id == 1).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).ToListAsync();
            var list2 = await products.Where(e => e.c.Id == 15).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).ToListAsync();
            var list3 = await products.Where(e => e.c.Id == 16).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).ToListAsync();
            var list4 = await products.Where(e => e.c.Id == 17).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
                    }
                ).ToListAsync();
            var list5 = await products.Where(e => e.c.Id == 7).Select(
                    m => new ProductViewModel
                    {
                        Id = m.pcp.p.Id,
                        Image = m.pcp.p.Image,
                        NameP = m.pcp.p.Name,
                        Price = m.pcp.p.Price,
                        Url = m.pcp.p.Url,
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

    }
}