using ASPDotNetCore.Configs;
using System.Configuration;

namespace ASPDotNetCore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DatabaseConfigMiddleware
    {
        public DatabaseOptions? databaseOptions { get; private set; }

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configurations;
        private readonly ILogger _logger;

        public DatabaseConfigMiddleware(RequestDelegate next, ILogger<DatabaseConfigMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configurations = configuration;
        }

        public Task Invoke(HttpContext httpContext)
        {
            databaseOptions = _configurations.GetSection(DatabaseOptions.Database)
                                             .Get<DatabaseOptions>();

            _logger.LogInformation(
                "\nPostgres User: {user}" +
                "\nPostgres Password: {password}" +
                "\nPostgres Database: {database}" +
                "\nPostgres Data: {data}",
                databaseOptions.PostgresUser, databaseOptions.PostgresPassword, databaseOptions.PostgresDatabase, databaseOptions.PostgresData);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DatabaseConfigMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseConfigMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseConfigMiddleware>();
        }
    }
}
