using Moq;
using Microsoft.AspNetCore.Mvc;

using Shopee.Application.Services;
using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.API.Controllers;

namespace Shopee.API.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _controller = new AuthController(_mockAuthService.Object);
        }

        [Fact]
        public async Task RegisterAsync_ReturnsOk_WhenRegistrationIsSuccessful()
        {
            // Arrange
            var userRegistrationDto = new UserRegistrationDto { Username = "newuser", Password = "password123" };
            var registeredUser = new UserDto { JwtToken = "some-jwt-token" };
            _mockAuthService.Setup(service => service.RegisterAsync(userRegistrationDto))
                            .ReturnsAsync(registeredUser);

            // Act
            var result = await _controller.RegisterAsync(userRegistrationDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<UserDto>>(okResult.Value);
            Assert.NotNull(response.Result);
            Assert.Equal("some-jwt-token", response.Result.JwtToken);
        }

        [Fact]
        public async Task LoginAsync_ReturnsOk_WhenLoginIsSuccessful()
        {
            // Arrange
            var userLoginDto = new UserLoginDto { Username = "existinguser", Password = "password123" };
            var loggedInUser = new UserDto { JwtToken = "valid-jwt-token" };
            _mockAuthService.Setup(service => service.LoginAsync(userLoginDto))
                            .ReturnsAsync(loggedInUser);

            // Act
            var result = await _controller.LoginAsync(userLoginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<UserDto>>(okResult.Value);
            Assert.NotNull(response.Result);
            Assert.Equal("valid-jwt-token", response.Result.JwtToken);
        }
    }
}