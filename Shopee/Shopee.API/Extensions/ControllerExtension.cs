using FluentValidation.AspNetCore;
using Shopee.API.Validation;
using System.Reflection;

namespace Shopee.API.Extensions
{
    public static class ControllerExtension
    {
        public static IServiceCollection AddControllerConfig(this IServiceCollection services)
        {
            // Add services to the container.
            // services.AddControllers(
            //     
            // );

            services.AddControllers(
                        options => options.Filters.Add(typeof(ValidateModelAttribute))
                    )
                    .AddFluentValidation(
                        options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()
                    )
            );

            return services;
        }
    }
}