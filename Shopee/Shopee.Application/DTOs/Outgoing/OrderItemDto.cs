namespace Shopee.Application.DTOs.Outgoing
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
