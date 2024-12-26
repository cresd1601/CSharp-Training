using Microsoft.EntityFrameworkCore;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Contexts;

namespace Shopee.Infrastructure.Repositories.Implement
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ShopeeDbContext context) : base(context) 
        {
            
        }

        public async Task<IEnumerable<OrderEntity>> GetAllByUserIdAsync(string userId)
        {
            IQueryable<OrderEntity> query = _dbSet.Include(order => order.OrderItems).AsQueryable();

            query = query.Where(cartItem => cartItem.UserId.Equals(userId));

            return await query.ToListAsync();
        }
    }
}