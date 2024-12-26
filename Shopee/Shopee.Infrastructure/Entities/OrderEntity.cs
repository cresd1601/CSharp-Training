namespace Shopee.Infrastructure.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}
