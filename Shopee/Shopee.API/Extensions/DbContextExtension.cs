using Microsoft.EntityFrameworkCore;

using Shopee.Infrastructure.Contexts;
using Shopee.Infrastructure.UnitOfWork;

namespace Shopee.API.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<ShopeeDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ShopeeConnectionString")));
            services.AddDbContext<ShopeeAuthDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ShopeeAuthConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}



