using Microsoft.AspNetCore.Mvc;

using Shopee.Application.Services;

using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

namespace Shopee.API.Controllers
{
    [ApiVersion("1.0")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _AuthService;

        public AuthController(IAuthService AuthService)
        {
            _AuthService = AuthService;
        }

        [HttpPost]
        [Route("Register")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationDto userRegistrationDto)
        {
            UserDto registeredUser = await _AuthService.RegisterAsync(userRegistrationDto);

            return Ok(ApiResponseDto<UserDto>.Success(registeredUser));
        }

        [HttpPost]
        [Route("Register")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> RegisterV2Async([FromBody] UserRegistrationDto userRegistrationDto)
        {
            UserDto registeredUser = await _AuthService.RegisterAsync(userRegistrationDto);

            return Ok(ApiResponseDto<UserDto>.Success(registeredUser));
        }

        [HttpPost]
        [Route("Login")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userLoginDto)
        {
            UserDto loggedInUser = await _AuthService.LoginAsync(userLoginDto);

            return Ok(ApiResponseDto<UserDto>.Success(loggedInUser));
        }
    }
}

