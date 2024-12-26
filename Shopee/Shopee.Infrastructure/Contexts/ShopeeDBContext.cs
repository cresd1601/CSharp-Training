using Microsoft.EntityFrameworkCore;

using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Contexts
{
    public class ShopeeDbContext : DbContext
    {
        public ShopeeDbContext(DbContextOptions<ShopeeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrderEntity to OrderItemEntity (One-to-Many)
            modelBuilder.Entity<OrderEntity>(order =>
            {
                order.HasMany(order => order.OrderItems)
                     .WithOne(orderItems => orderItems.Order)
                     .HasForeignKey(orderItems => orderItems.OrderId);
            });

            // ProductEntity to OrderItemEntity (One-to-Many)
            modelBuilder.Entity<ProductEntity>(product =>
            {
                product.HasMany(product => product.OrderItems)
                       .WithOne(orderItem => orderItem.Product)
                       .HasForeignKey(orderItem => orderItem.ProductId)
                       .OnDelete(DeleteBehavior.Cascade); // Configures the delete behavior
            });

            // ProductEntity to CartItemEntity (One-to-Many)
            modelBuilder.Entity<ProductEntity>(product =>
            {
                product.HasMany(product => product.CartItems)
                       .WithOne(cartItem => cartItem.Product)
                       .HasForeignKey(cartItem => cartItem.ProductId)
                       .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed
            });
        }

        // Entities
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<CartItemEntity> CartItems { get; set; }

        public DbSet<OrderItemEntity> OrderItems { get; set; }
    }
}
