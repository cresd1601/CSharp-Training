using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(UserRegistrationDto userRegisterDto);

        Task<UserDto> LoginAsync(UserLoginDto userLoginDto);

    }
}

