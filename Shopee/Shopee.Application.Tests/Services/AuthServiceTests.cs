using Moq;
using Microsoft.AspNetCore.Identity;

using Shopee.Application.Services.Implement;
using Shopee.Application.Exceptions;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.Application.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<UserManager<UserEntity>> mockUserManager;
        private readonly Mock<ITokenRepository> mockTokenRepository;
        private readonly AuthService authService;

        public AuthServiceTests()
        {
            var userStoreMock = new Mock<IUserStore<UserEntity>>();
            mockUserManager = new Mock<UserManager<UserEntity>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            mockTokenRepository = new Mock<ITokenRepository>();
            authService = new AuthService(mockUserManager.Object, mockTokenRepository.Object);
        }

        [Fact]
        public async Task RegisterAsync_SuccessfullyCreatesUserAndAssignsRole()
        {
            // Arrange
            var userRegistrationDto = new UserRegistrationDto { Username = "testuser", Password = "Test@1234", Role = "Admin" };

            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<UserEntity>(), It.IsAny<string>()))
                           .ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<UserEntity>(), It.IsAny<string>()))
                           .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await authService.RegisterAsync(userRegistrationDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userRegistrationDto.Username, result.Username);

            mockUserManager.Verify(x => x.CreateAsync(It.IsAny<UserEntity>(), It.IsAny<string>()), Times.Once);
            mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<UserEntity>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_FailsToCreateUser_ThrowsException()
        {
            // Arrange
            var userRegistrationDto = new UserRegistrationDto { Username = "testuser", Password = "Test@1234", Role = "Admin" };

            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<UserEntity>(), It.IsAny<string>()))
                           .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Failed to create user." }));

            // Act & Assert
            await Assert.ThrowsAsync<RegistrationFailedException>(() => authService.RegisterAsync(userRegistrationDto));
        }

        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var userLoginDto = new UserLoginDto { Username = "testuser", Password = "Test@1234" };
            var user = new UserEntity { UserName = "testuser", Email = "testuser@example.com" };
            var roles = new List<string> { "Admin" };  // Ensure this is not null
            var jwtToken = "valid_jwt_token";

            mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                           .ReturnsAsync(user);
            mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<UserEntity>(), It.IsAny<string>()))
                           .ReturnsAsync(true);
            mockUserManager.Setup(x => x.GetRolesAsync(user))  // Ensure this returns a valid list
                           .ReturnsAsync(roles);
            mockTokenRepository.Setup(x => x.CreateJWTToken(user, roles))
                               .Returns(jwtToken);

            // Act
            var result = await authService.LoginAsync(userLoginDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(jwtToken, result.JwtToken);

            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            mockUserManager.Verify(x => x.CheckPasswordAsync(It.IsAny<UserEntity>(), It.IsAny<string>()), Times.Once);
            mockTokenRepository.Verify(x => x.CreateJWTToken(user, roles), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_InvalidCredentials_ThrowsException()
        {
            // Arrange
            var userLoginDto = new UserLoginDto { Username = "testuser", Password = "WrongPassword" };

            mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                           .ReturnsAsync((UserEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<LoginFailedException>(() => authService.LoginAsync(userLoginDto));
        }
    }
}