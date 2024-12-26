using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Contexts;

namespace Shopee.Infrastructure.Repositories.Implement
{
    public class OrderItemRepository : BaseRepository<OrderItemEntity>, IOrderItemRepository
    {
        public OrderItemRepository(ShopeeDbContext context) : base(context) { }
    }
}