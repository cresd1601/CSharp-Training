namespace Shopee.Application.DTOs.Outgoing
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}