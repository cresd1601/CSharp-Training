namespace Shopee.Infrastructure.Entities
{
    public class CartItemEntity : BaseEntity
    {
        public string UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        // Navigation properties
        public ProductEntity Product { get; set; }
    }
}