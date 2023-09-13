using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Data.Interfaces
{
    public interface ISportsZoneDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
    }
}
