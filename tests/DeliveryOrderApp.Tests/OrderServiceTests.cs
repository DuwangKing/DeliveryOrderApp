using System;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Data;
using DeliveryOrderApp.Models;
using DeliveryOrderApp.Services;
using DeliveryOrderApp.DTOs;

namespace DeliveryOrderApp.Tests
{
    public class OrderServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CreateOrderAsync_ValidDto_AddsOrderToDatabase()
        {
            var context = GetInMemoryDbContext();
            var service = new OrderService(context);    
            var dto = new CreateOrderDto
            {
                SenderCity = "Астрахань",
                SenderAdress = "ул. Ленина 1",
                RecipientCity = "Казань",
                RecipientAdress = "ул. Тимме 2",
                Weight = 10.5m,
                PickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
            };

            await service.CreateOrderAsync(dto);

            var orders = await context.Orders.ToListAsync();
            Assert.Single(orders);
            Assert.Equal("Астрахань", orders[0].SenderCity);
            Assert.Equal(10.5m, orders[0].Weight);
        }
    }
}