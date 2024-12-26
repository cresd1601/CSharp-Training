using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Shopee.API.Extensions
{
    public static class ApiVersionExtension
    {
        public static IServiceCollection AddApiVersionConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options => 
            {  
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }
    }
}



