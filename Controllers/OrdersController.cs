using Microsoft.AspNetCore.Mvc;
using DeliveryOrderApp.Services;
using DeliveryOrderApp.Models;

namespace DeliveryOrderApp.Controllers
{
    public class OrdersController : Controller 
    {
        private readonly IOrderService _orderService;

        private const int DefaultPageSize = 5;
        private const int MaxAllowedPageNumber = 1000;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            if(pageNumber < 1 || pageNumber > MaxAllowedPageNumber)
            {
                return BadRequest($"Номер страницы должен быть от 1 до {MaxAllowedPageNumber}");
            }
            var orders = await _orderService.GetOrdersPagedAsync(pageNumber, DefaultPageSize);
            return View(orders);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Order order)
        {
            if(ModelState.IsValid)
            {
                await _orderService.CreateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);

            if(order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}