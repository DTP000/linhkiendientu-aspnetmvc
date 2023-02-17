using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Linhkiendientu_API.Services.Orders.Dto;

namespace Linhkiendientu_aspnetmvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly BanHangDbContext _context;

        public OrdersController(BanHangDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Orders
        public async Task<IActionResult> Index(string? Keyword)
        {
            var banHangDbContext = _context.Orders.Include(o => o.Staff).ToList();
            if (!String.IsNullOrEmpty(Keyword))
            {
                banHangDbContext = banHangDbContext.Where(x => x.FullName.ToLower().Contains(Keyword.ToLower()) || x.ShipCode.ToLower().Contains(Keyword.ToLower()) || x.Response.ToLower().Contains(Keyword.ToLower())).ToList();
            }
            return View(banHangDbContext.Select(x=> new OrderDto
            {
                Id = x.Id,
                ShipUnit = x.ShipUnit,
                ShipCode = x.ShipCode,
                FullName = x.FullName,
                Phone = x.Phone,
                Address = x.Address,
                CreateAt = x.CreateAt,
                Finish = x.Finish,
                ShipPrice = x.ShipPrice,
                TotalPrice = x.TotalPrice,
                Note = x.Note,
                Response = x.Response,
                OrderStatus = x.OrderStatus
            }).ToList());
        }

        // GET: Admin/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Staff)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/Orders/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Avatar");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Avatar");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ShipUnit,ShipCode,FullName,Phone,Address,CreateAt,Finish,StaffId,ShipPrice,TotalPrice,Note,Response,OrderStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Avatar", order.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Avatar", order.UserId);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Avatar", order.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Avatar", order.UserId);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ShipUnit,ShipCode,FullName,Phone,Address,CreateAt,Finish,StaffId,ShipPrice,TotalPrice,Note,Response,OrderStatus")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Avatar", order.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Avatar", order.UserId);
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Staff)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'BanHangDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.Id == id);
        }
    }
}
