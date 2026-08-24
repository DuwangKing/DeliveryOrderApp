using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Data;
using DeliveryOrderApp.Models;

namespace DeliveryOrderApp.Controllers
{
    public class OrdersController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .OrderByDescending(order => order.Id)
                .ToListAsync();

                return View(orders);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("SenderCity,SenderAdress,RecipientAdress,Weight,PickupDate")] Order order)
        {
            if(ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();

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

            var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

            if(order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}