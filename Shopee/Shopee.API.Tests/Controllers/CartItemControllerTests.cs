using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Shopee.Application.Services;
using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.API.Controllers;

namespace Shopee.API.Tests.Controllers
{
    public class CartItemsControllerTests
    {
        private readonly Mock<ICartItemsService> _mockCartItemsService;
        private readonly CartItemsController _controller;
        private readonly ClaimsPrincipal _user;

        public CartItemsControllerTests()
        {
            _mockCartItemsService = new Mock<ICartItemsService>();
            _controller = new CartItemsController(_mockCartItemsService.Object);

            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "userId1"),
                new Claim(ClaimTypes.Role, "User")
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = _user }
            };
        }

        [Fact]
        public async Task GetAll_ReturnsAllCartItemsForUser()
        {
            // Arrange
            var cartItems = new List<CartItemDto>
            {
                new CartItemDto { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 1 },
                new CartItemDto { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 2 }
            };
            _mockCartItemsService.Setup(s => s.GetAllByUserIdAsync("userId1"))
                .ReturnsAsync(cartItems);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<IEnumerable<CartItemDto>>>(okResult.Value);
            Assert.Equal(cartItems, response.Result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedCartItem()
        {
            // Arrange
            var newCartItem = new CartItemCreateDto { ProductId = Guid.NewGuid(), Quantity = 1 };
            var createdCartItem = new CartItemDto { Id = Guid.NewGuid(), ProductId = newCartItem.ProductId, Quantity = newCartItem.Quantity };
            _mockCartItemsService.Setup(s => s.CreateByUserIdAsync("userId1", newCartItem))
                .ReturnsAsync(createdCartItem);

            // Act
            var result = await _controller.CreateAsync(newCartItem);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<CartItemDto>>(okResult.Value);
            Assert.Equal(createdCartItem, response.Result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsUpdatedCartItem()
        {
            // Arrange
            var cartItemId = Guid.NewGuid();
            var cartItemUpdate = new CartItemUpdateDto { Quantity = 3 };
            var updatedCartItem = new CartItemDto { Id = cartItemId, ProductId = Guid.NewGuid(), Quantity = cartItemUpdate.Quantity };
            _mockCartItemsService.Setup(s => s.UpdateByUserIdAsync("userId1", cartItemId, cartItemUpdate))
                .ReturnsAsync(updatedCartItem);

            // Act
            var result = await _controller.UpdateAsync(cartItemId, cartItemUpdate);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<CartItemDto>>(okResult.Value);
            Assert.Equal(updatedCartItem, response.Result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsDeletedCartItem()
        {
            // Arrange
            var cartItemId = Guid.NewGuid();
            var deletedCartItem = new CartItemDto { Id = cartItemId, ProductId = Guid.NewGuid(), Quantity = 1 };
            _mockCartItemsService.Setup(s => s.DeleteByUserIdAsync("userId1", cartItemId))
                .ReturnsAsync(deletedCartItem);

            // Act
            var result = await _controller.DeleteAsync(cartItemId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<CartItemDto>>(okResult.Value);
            Assert.Equal(deletedCartItem, response.Result);
        }
    }
}