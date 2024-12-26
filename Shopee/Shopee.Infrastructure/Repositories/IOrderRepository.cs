using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Repositories
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetAllByUserIdAsync(string userId);
    }
}