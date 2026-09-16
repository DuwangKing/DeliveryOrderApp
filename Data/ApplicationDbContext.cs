using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Models;

namespace DeliveryOrderApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Order> Orders { get; set; }
    }
}