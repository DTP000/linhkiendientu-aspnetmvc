using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Linhkiendientu_API.Services.Orders.Dto;
using Microsoft.AspNetCore.Cors;
using Linhkiendientu_API.Services.Orders;

namespace Linhkiendientu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<OrderDtoView>> GetOrders([FromQuery]PageAndSearch pageAndSearch)
        {
           return _orderService.GetAll(pageAndSearch);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewApiObject>> GetOrder(int id)
        {
            return _orderService.GetById(id);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderViewApiObject>> PutOrder(EditOrderDto editProduct)
        {
            return await _orderService.Update(editProduct);
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderViewApiObject>> PostOrder(CreateOrderDto createProduct)
        {
            return await _orderService.Create(createProduct);
        }

        // DELETE: api/Orders/5
        /*    [HttpDelete("{id}")]
            public async Task<ActionResult<OrderViewApiObject>> DeleteProduct(int id)
            {
                return _orderService.Delete(id);
            }*/
    }
}
