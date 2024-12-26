namespace Shopee.Application.DTOs.Incoming
{
    public class CartItemCreateDto
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

    }
}