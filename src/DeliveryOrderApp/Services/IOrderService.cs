using DeliveryOrderApp.Models;
using DeliveryOrderApp.DTOs;

namespace DeliveryOrderApp.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(CreateOrderDto orderDto);

        Task<PagedResult<Order>> GetOrdersPagedAsync(int pageNumber, int pageSize);
    }
}