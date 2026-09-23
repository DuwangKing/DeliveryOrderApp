using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Data;
using DeliveryOrderApp.Models;

namespace DeliveryOrderApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
            .OrderByDescending(order => order.Id)
            .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Order>> GetOrdersPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Orders.CountAsync();

            var orders = await _context.Orders
            .OrderByDescending(o => o.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            var result = new PagedResult<Order>();

            result.Items = orders;
            result.CurrentPage = pageNumber;
            result.PageSize = pageSize;
            result.TotalCount = totalCount;

            return result;
        }
    }
}