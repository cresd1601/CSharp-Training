using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Contexts
{
    public class ShopeeAuthDbContext : IdentityDbContext<UserEntity>
    {
        public ShopeeAuthDbContext(DbContextOptions<ShopeeAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string userRoleId = "17caa5dd-75c1-401b-95e2-a5d341637876";
            string adminRoleId = "40e0a55c-45d2-4902-b05c-773c93cabff0";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
