using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Linhkiendientu_API.Data;
using TestThuVien.Entity;
using Microsoft.AspNetCore.Cors;
using Linhkiendientu_API.Services.OrderDetails;
using Linhkiendientu_API.Services.OrderDetails.Dto;

namespace Linhkiendientu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<OrderDetailDtoView>> GetOrderDetails([FromQuery]PageAndSearch pageAndSearch)
        {
           return _orderDetailService.GetAll(pageAndSearch);
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailViewApiObject>> GetOrderDetail(int id)
        {
            return _orderDetailService.GetById(id);
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDetailViewApiObject>> PutProduct(EditOrderDetailDto editOrderDetail)
        {
            return await _orderDetailService.Update(editOrderDetail);
        }

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetailViewApiObject>> PostOrderDetail(CreateOrderDetailDto createOrderDetail)
        {
            return await _orderDetailService.Create(createOrderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDetailViewApiObject>> DeleteOrderDetail(int id)
        {
            return _orderDetailService.Delete(id);
        }
    }
}
