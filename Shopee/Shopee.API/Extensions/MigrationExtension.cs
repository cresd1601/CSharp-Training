using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Npgsql;

using Shopee.Infrastructure.Contexts;

namespace Shopee.API.Extensions
{
    public static class MigrationExtension
    {
        public static void UseMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            // Get DbContextOptions from the service provider
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ShopeeAuthDbContext>>();

            // Get the connection string from the DbContextOptions
            var connectionString = dbContextOptions.FindExtension<NpgsqlOptionsExtension>()?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Handle case where connection string is not found
                return;
            }

            // Extracting the database name from the connection string
            var builder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            var databaseName = builder.Database;

            // Perform migration
            using var dbContext = new ShopeeAuthDbContext(dbContextOptions);
            dbContext.Database.Migrate();

            Console.WriteLine($"Migration completed for database: {databaseName}");
        }
    }
}