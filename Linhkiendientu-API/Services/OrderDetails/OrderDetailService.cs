using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Services.OrderDetails;
using Linhkiendientu_API.Services.OrderDetails.Dto;
using Microsoft.EntityFrameworkCore;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Orders
{
    public class OrderDetailService : IOrderDetailService
    {
        private BanHangDbContext _context;
        private readonly IMapper _mapper;

        public OrderDetailService(
            BanHangDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDetailDtoView GetAll(PageAndSearch pageAndSearch)
        {
            try
            {   
                if (pageAndSearch.OrderId <=0)
                {
                    return new OrderDetailDtoView
                    {
                        message = "Không có mã đơn hàng",
                        data = null,
                        success = false
                    };
                }
                var list = _context.OrderDetails.Where(x=>x.OrderId == pageAndSearch.OrderId && x.IsDelete ==TestThuVien.Entity.Common.IsDelete.NOT_DELETED).ToList();
                var listDto = _mapper.Map<List<OrderDetail>, List<OrderDetailDto>>(list);

                return new OrderDetailDtoView
                {
                    message = "Thành Công",
                    data = listDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderDetailDtoView
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }

        public async Task<OrderDetailViewApiObject> Create(CreateOrderDetailDto input)
        {
            try
            {
                var checkOrder = await _context.Orders.
                    Where(x => x.Id == input.OrderId).FirstOrDefaultAsync();
                if (checkOrder == null)
                {
                    return new OrderDetailViewApiObject
                    {
                        message = "Mã đơn hàng không chính xác",
                        data = null,
                        success = false
                    };
                }
                var checkProduct = await _context.Products.
                    Where(x => x.Id == input.ProductId &&
                            x.IsDeleted == TestThuVien.Entity.Common.IsDelete.NOT_DELETED).FirstOrDefaultAsync();
                if (checkProduct == null)
                {
                    return new OrderDetailViewApiObject
                    {
                        message = "Mã sản phẩm không chính xác",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<CreateOrderDetailDto, OrderDetail>(input);
                entity.IsDelete = TestThuVien.Entity.Common.IsDelete.NOT_DELETED;
                _context.OrderDetails.Add(entity);
                await _context.SaveChangesAsync();
                var dto = _context.OrderDetails.Where(x => x.OrderId == entity.OrderId).OrderByDescending(x=>x.Id).FirstOrDefault();
                var entityDto = _mapper.Map<OrderDetail, OrderDetailDto>(dto);
                return new OrderDetailViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderDetailViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public async Task<OrderDetailViewApiObject> Update(EditOrderDetailDto input)
        {
            try
            {
                var result = _context.OrderDetails.Any(x => x.Id == input.Id && x.IsDelete == TestThuVien.Entity.Common.IsDelete.NOT_DELETED);
                if (!result)
                {
                    return new OrderDetailViewApiObject
                    {
                        message = "Mã chi tiết đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<EditOrderDetailDto, OrderDetail>(input);
                _context.OrderDetails.Update(entity);
                await _context.SaveChangesAsync();
                var dto = _context.OrderDetails.Find(entity.Id);
                var entityDto = _mapper.Map<OrderDetail, OrderDetailDto>(dto);
                return new OrderDetailViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                }; 
            }
            catch (Exception ex)
            {
                return new OrderDetailViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public OrderDetailViewApiObject GetById(int id)
        {
            try
            {
                var entity = _context.OrderDetails.Where(x=> x.Id == id && x.IsDelete == TestThuVien.Entity.Common.IsDelete.NOT_DELETED).FirstOrDefault();
                if (entity == null)
                {
                    return new OrderDetailViewApiObject
                    {
                        message = "Mã chi tiết đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entityDto = _mapper.Map<OrderDetail, OrderDetailDto>(entity);

                return new OrderDetailViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new OrderDetailViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public OrderDetailViewApiObject Delete(int id)
        {
            try
            {
                var entity = _context.OrderDetails.Where(x=> x.Id == id && x.IsDelete == TestThuVien.Entity.Common.IsDelete.NOT_DELETED).FirstOrDefault();
                if (entity == null)
                {
                    return new OrderDetailViewApiObject
                    {
                        message = "Mã chi tiết đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
                entity.IsDelete = TestThuVien.Entity.Common.IsDelete.DELETED;
                _context.OrderDetails.Update(entity);
                _context.SaveChangesAsync();
                return new OrderDetailViewApiObject
                {
                    message = "Thành Công",
                    data = null,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderDetailViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
    }
}
