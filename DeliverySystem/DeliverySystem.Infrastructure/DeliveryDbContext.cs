
using DeliverySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Infrastructure
{
    public class DeliveryDbContext:DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
