using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Contexts;

namespace Shopee.Infrastructure.Repositories.Implement
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ShopeeDbContext context) : base(context) { }
    }
}