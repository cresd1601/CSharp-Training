using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDto>> GetAllByUserIdAsync(string userId);

        Task<OrderDto> CreateAsync(string userId);

/*        Task<OrderDto> UpdateAsync(Guid id, CartItemUpdateDto cartItem);
*/
    }
}

