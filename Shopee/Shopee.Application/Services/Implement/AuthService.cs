using Microsoft.AspNetCore.Identity;

using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.Exceptions;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Services.Implement
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthService(UserManager<UserEntity> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        public async Task<UserDto> RegisterAsync(UserRegistrationDto userRegisterDto)
        {
            UserEntity user = new UserEntity { UserName = userRegisterDto.Username, Email = userRegisterDto.Username };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!result.Succeeded)
            {
                throw new RegistrationFailedException("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var roles = new List<string>(); // Initialize roles list

            if (!string.IsNullOrEmpty(userRegisterDto.Role))
            {
                await _userManager.AddToRoleAsync(user, userRegisterDto.Role);
                roles.Add(userRegisterDto.Role);
            }

            // Return UserDto without a JWT token
            return new UserDto
            {
                Username = user.UserName,
                Roles = roles,
            };
        }

        public async Task<UserDto> LoginAsync(UserLoginDto userLoginDto)
        {

            // Attempt to find the user by their email or username
            var user = await _userManager.FindByEmailAsync(userLoginDto.Username);

            // Check if the password is correct
            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (user == null || !isPasswordCorrect)
            {
                throw new LoginFailedException("Invalid login attempt.");
            }

            // Get roles associated with the user for role-based authorization
            var roles = await _userManager.GetRolesAsync(user);

            // Generate JWT token for authenticated sessions
            string jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

            // Return a simplified UserDto that only includes the JWT token
            return new UserDto
            {
                JwtToken = jwtToken
            };
        }
    }
}