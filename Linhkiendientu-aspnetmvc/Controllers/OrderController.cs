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
    public class OrderController : Controller
    {
        private readonly BanHangDbContext _context;

        public OrderController(BanHangDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Card")]
        public async Task<IActionResult> Card()
        {
            return View();
        }

    }
}
