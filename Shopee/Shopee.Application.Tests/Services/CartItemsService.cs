using Moq;
using AutoMapper;
using System.Linq.Expressions;

using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.Exceptions;
using Shopee.Application.Services.Implement;
using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Tests.Services
{
    public class CartItemsServiceTests
    {
        private readonly Mock<IProductRepository> mockProductRepository;
        private readonly Mock<ICartItemRepository> mockCartItemRepository;
        private readonly Mock<IMapper> mockMapper;
        private readonly CartItemsService cartItemsService;

        public CartItemsServiceTests()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockCartItemRepository = new Mock<ICartItemRepository>();
            mockMapper = new Mock<IMapper>();
            cartItemsService = new CartItemsService(mockProductRepository.Object, mockCartItemRepository.Object, mockMapper.Object);
        }

        [Fact]
        public async Task GetAllByUserIdAsync_ReturnsCartItems()
        {
            // Arrange
            var userId = "user1";
            var cartItems = new List<CartItemEntity>
            {
                new CartItemEntity { UserId = userId, ProductId = Guid.NewGuid(), Quantity = 1 }
            };
            mockCartItemRepository.Setup(repo => repo.GetAllByUserIdAsync(userId))
                .ReturnsAsync(cartItems);
            mockMapper.Setup(m => m.Map<IEnumerable<CartItemDto>>(It.IsAny<IEnumerable<CartItemEntity>>()))
                .Returns(new List<CartItemDto> { new CartItemDto() });

            // Act
            var result = await cartItemsService.GetAllByUserIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            mockCartItemRepository.Verify(x => x.GetAllByUserIdAsync(userId), Times.Once);
            mockMapper.Verify(x => x.Map<IEnumerable<CartItemDto>>(cartItems), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ProductNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var userId = "user1";
            var createDto = new CartItemCreateDto { ProductId = Guid.NewGuid(), Quantity = 1 };
            mockProductRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                .ReturnsAsync((ProductEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => cartItemsService.CreateByUserIdAsync(userId, createDto));
        }

        [Fact]
        public async Task UpdateAsync_CartItemNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var userId = "user1";
            var cartItemId = Guid.NewGuid();
            mockCartItemRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<CartItemEntity, bool>>>()))
                .ReturnsAsync((CartItemEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => cartItemsService.UpdateByUserIdAsync(userId,cartItemId, new CartItemUpdateDto { Quantity = 2 }));
        }

        [Fact]
        public async Task DeleteAsync_CartItemNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var userId = "user1";
            var cartItemId = Guid.NewGuid();
            mockCartItemRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<CartItemEntity, bool>>>()))
                .ReturnsAsync((CartItemEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => cartItemsService.DeleteByUserIdAsync(userId,cartItemId));
        }

        [Fact]
        public async Task DeleteAsync_SuccessfullyDeletesCartItem()
        {
            // Arrange
            var userId = "user1";
            var cartItemId = Guid.NewGuid();
            var cartItem = new CartItemEntity { Id = cartItemId, UserId = "user1", ProductId = Guid.NewGuid(), Quantity = 1 };
            mockCartItemRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<CartItemEntity, bool>>>()))
                .ReturnsAsync(cartItem);
            mockCartItemRepository.Setup(repo => repo.DeleteAsync(It.IsAny<CartItemEntity>()))
                .ReturnsAsync(cartItem);
            mockMapper.Setup(m => m.Map<CartItemDto>(It.IsAny<CartItemEntity>()))
                .Returns(new CartItemDto());

            // Act
            var result = await cartItemsService.DeleteByUserIdAsync(userId, cartItemId);

            // Assert
            Assert.NotNull(result);
            mockCartItemRepository.Verify(x => x.DeleteAsync(cartItem), Times.Once);
            mockMapper.Verify(x => x.Map<CartItemDto>(cartItem), Times.Once);
        }
    }
}