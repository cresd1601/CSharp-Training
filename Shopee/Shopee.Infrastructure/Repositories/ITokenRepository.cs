using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(UserEntity user, List<string> roles);
    }
}