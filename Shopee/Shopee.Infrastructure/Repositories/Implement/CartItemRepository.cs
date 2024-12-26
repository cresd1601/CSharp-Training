using Microsoft.EntityFrameworkCore;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Contexts;

namespace Shopee.Infrastructure.Repositories.Implement
{
    public class CartItemRepository : BaseRepository<CartItemEntity>, ICartItemRepository
    {
        public CartItemRepository(ShopeeDbContext context) : base(context) { }

        public async Task<IEnumerable<CartItemEntity>> GetAllByUserIdAsync(string userId)
        {
            return await FilterByUserId(userId).ToListAsync();
        }

        public async Task ClearAllByUserIdAsync(string userId)
        {
            var cartItems = await FilterByUserId(userId).ToListAsync();
            _dbSet.RemoveRange(cartItems);
            await _shopeeDBContext.SaveChangesAsync();
        }

        // Abstract the query logic into a method that can be mocked or overridden in tests
        protected virtual IQueryable<CartItemEntity> FilterByUserId(string userId)
        {
            return _dbSet.Where(cartItem => cartItem.UserId.Equals(userId));
        }
    }
}