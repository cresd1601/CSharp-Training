using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Repositories
{
    public interface ICartItemRepository : IBaseRepository<CartItemEntity>
    {
        Task<IEnumerable<CartItemEntity>> GetAllByUserIdAsync(string userId);

        Task ClearAllByUserIdAsync(string userId);

    }
}