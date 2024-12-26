using Shopee.Infrastructure.Repositories;
using Shopee.Infrastructure.Repositories.Implement;

namespace Shopee.API.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            return services;
        }
    }
}