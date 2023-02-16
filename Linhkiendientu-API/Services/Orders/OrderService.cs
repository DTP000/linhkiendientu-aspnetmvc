using AutoMapper;
using Linhkiendientu_API.Data;
using Linhkiendientu_API.Services.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Services.Orders
{
    public class OrderService : IOrderService
    {
        private BanHangDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(
            BanHangDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDtoView GetAll(PageAndSearch pageAndSearch)
        {
            try
            {
                var list = _context.Orders.ToList();
                if (!String.IsNullOrEmpty(pageAndSearch.Keyword))
                {
                    list = list.Where(x => 
                    x.FullName.ToLower().Contains(pageAndSearch.Keyword.ToLower()) || 
                    x.Address.ToLower().Contains(pageAndSearch.Keyword.ToLower())  ||
                    x.ShipCode.ToLower().Contains(pageAndSearch.Keyword.ToLower()))
                    .ToList();
                }
                var listDto = _mapper.Map<List<Order>, List<OrderDto>>(list);

                return new OrderDtoView
                {
                    message = "Thành Công",
                    data = listDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderDtoView
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }

        public async Task<OrderViewApiObject> Create(CreateOrderDto input)
        {
            try
            {
                var checkUser = await _context.Users.
                    Where(x => x.Id == input.UserId &&
                            x.UserStatus == TestThuVien.Entity.Common.UserStatus.TAI_KHOAN_BINH_THUONG).FirstOrDefaultAsync();
                if (checkUser == null)
                {
                    return new OrderViewApiObject
                    {
                        message = "Mã khách hàng chưa được tạo",
                        data = null,
                        success = false
                    };
                }
                var checkStaff = await _context.Users.
                    Where(x => x.Id == input.StaffId &&
                            x.Role == TestThuVien.Entity.Common.Role.NHAN_VIEN).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    return new OrderViewApiObject
                    {
                        message = "Mã nhân viên không chính xác",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<CreateOrderDto, Order>(input);
                entity.OrderStatus = TestThuVien.Entity.Common.OrderStatus.CHO_LAY_HANG;
                _context.Orders.Add(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Orders.Where(x => x.FullName == entity.FullName).OrderByDescending(x=>x.CreateAt).FirstOrDefault();
                var entityDto = _mapper.Map<Order, OrderDto>(dto);
                return new OrderViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public async Task<OrderViewApiObject> Update(EditOrderDto input)
        {
            try
            {
                var result = _context.Orders.Any(x => x.Id == input.Id );
                if (!result)
                {
                    return new OrderViewApiObject
                    {
                        message = "Mã đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entity = _mapper.Map<EditOrderDto, Order>(input);
                _context.Orders.Update(entity);
                await _context.SaveChangesAsync();
                var dto = _context.Orders.Find(entity.Id);
                var entityDto = _mapper.Map<Order, OrderDto>(dto);
                return new OrderViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                }; 
            }
            catch (Exception ex)
            {
                return new OrderViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public OrderViewApiObject GetById(int id)
        {
            try
            {
                var entity = _context.Orders.Where(x=> x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return new OrderViewApiObject
                    {
                        message = "Mã đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
                var entityDto = _mapper.Map<Order, OrderDto>(entity);

                return new OrderViewApiObject
                {
                    message = "Thành Công",
                    data = entityDto,
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new OrderViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
        public OrderViewApiObject Delete(int id)
        {
            try
            {
                var entity = _context.Orders.Where(x=> x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return new OrderViewApiObject
                    {
                        message = "Mã đơn hàng không tồn tại",
                        data = null,
                        success = false
                    };
                }
               /* entity.IsDeleted = TestThuVien.Entity.Common.IsDelete.DELETED;*/
                _context.Orders.Update(entity);
                _context.SaveChangesAsync();
                return new OrderViewApiObject
                {
                    message = "Thành Công",
                    data = null,
                    success = true
                };
            } catch (Exception ex)
            {
                return new OrderViewApiObject
                {
                    message = ex.Message,
                    data = null,
                    success = false
                };
            }
        }
    }
}
