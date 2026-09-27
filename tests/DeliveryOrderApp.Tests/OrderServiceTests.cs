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

        [Fact]
        public async Task GetOrdersPagedAsync_ReturnsCorrectPageAndTotalCount()
        {
            var context = GetInMemoryDbContext();

            context.Orders.AddRange(
            new Order { SenderCity = "A", SenderAdress = "1", RecipientCity = "B", RecipientAdress = "2", Weight = 1, PickupDate = DateOnly.FromDateTime(DateTime.Now) },
            new Order { SenderCity = "C", SenderAdress = "3", RecipientCity = "D", RecipientAdress = "4", Weight = 2, PickupDate = DateOnly.FromDateTime(DateTime.Now) },
            new Order { SenderCity = "E", SenderAdress = "5", RecipientCity = "F", RecipientAdress = "6", Weight = 3, PickupDate = DateOnly.FromDateTime(DateTime.Now) }
            );
            await context.SaveChangesAsync();

            var service = new OrderService(context);
            var result = await service.GetOrdersPagedAsync(pageNumber: 1, pageSize: 2);

            Assert.Equal(3, result.TotalCount);
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(1, result.CurrentPage);
        }
    }
}