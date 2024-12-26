namespace Shopee.Infrastructure.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        // Navigation properties to related order items and cart items
        public ICollection<OrderItemEntity> OrderItems { get; set; }

        public ICollection<CartItemEntity> CartItems { get; set; }
    }
}