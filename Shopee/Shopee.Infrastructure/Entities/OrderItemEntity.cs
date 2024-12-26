namespace Shopee.Infrastructure.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        public Guid OrderId { get; set; } // Foreign key to the OrderEntity

        public Guid ProductId { get; set; } // Foreign key to the ProductEntity

        public int Quantity { get; set; } // Quantity of the product ordered

        public decimal Price { get; set; } // Price of the product at the time of the order

        // Navigation properties
        public OrderEntity Order { get; set; } // The order this item belongs to

        public ProductEntity Product { get; set; } // The product being ordered
    }
}
