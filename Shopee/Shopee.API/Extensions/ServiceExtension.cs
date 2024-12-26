using Shopee.Application.Services;
using Shopee.Application.Services.Implement;

namespace Shopee.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICartItemsService, CartItemsService>();
            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}