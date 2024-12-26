using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Shopee.Application.Services;
using Shopee.Application.DTOs;
using Shopee.API.Controllers;
using Shopee.Application.DTOs.Outgoing;

namespace Shopee.API.Tests.Controllers
{
    public class OrdersControllerTests
    {
        private readonly Mock<IOrdersService> _mockOrdersService;
        private readonly OrdersController _controller;
        private readonly ClaimsPrincipal _user;

        public OrdersControllerTests()
        {
            _mockOrdersService = new Mock<IOrdersService>();
            _controller = new OrdersController(_mockOrdersService.Object);

            // Setup the ControllerContext to simulate an authenticated user
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "userId1"),
                new Claim(ClaimTypes.Role, "User")
            }, "TestAuthentication"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = _user }
            };
        }

        [Fact]
        public async Task GetAll_ReturnsAllOrdersForUser()
        {
            // Arrange
            var orders = new List<OrderDto>
            {
                new OrderDto { Id = Guid.NewGuid(), TotalPrice = 100.00M },
                new OrderDto { Id = Guid.NewGuid(), TotalPrice = 200.00M }
            };
            _mockOrdersService.Setup(s => s.GetAllByUserIdAsync("userId1"))
                              .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<IEnumerable<OrderDto>>>(okResult.Value);
            Assert.Equal(orders, response.Result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedOrder()
        {
            // Arrange
            var createdOrder = new OrderDto { Id = Guid.NewGuid(), TotalPrice = 150.00M };
            _mockOrdersService.Setup(s => s.CreateAsync("userId1"))
                              .ReturnsAsync(createdOrder);

            // Act
            var result = await _controller.CreateAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<OrderDto>>(okResult.Value);
            Assert.Equal(createdOrder, response.Result);
        }
    }
}
