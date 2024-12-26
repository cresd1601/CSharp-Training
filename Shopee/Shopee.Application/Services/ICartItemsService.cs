using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Services
{
    public interface ICartItemsService
    {
        Task<IEnumerable<CartItemDto>> GetAllByUserIdAsync(string userId);

        Task<ApiResponseDto<CartItemDto>> CreateByUserIdAsync(string userId, CartItemCreateDto cartItem);

        Task<ApiResponseDto<CartItemDto>> UpdateByUserIdAsync(string userId, Guid id, CartItemUpdateDto cartItem);

        Task<ApiResponseDto<CartItemDto>> DeleteByUserIdAsync(string userId, Guid id);

    }
}

