using Shopee.Application.Mappings;

namespace Shopee.API.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            // Auto Mapper
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(CartItemProfile));

            return services;
        }
    }
}

