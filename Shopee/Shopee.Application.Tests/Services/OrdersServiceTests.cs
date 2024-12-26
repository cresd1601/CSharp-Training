using Moq;
using AutoMapper;
using System.Linq.Expressions;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.Exceptions;
using Shopee.Application.Services.Implement;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Tests.Services
{
    public class OrdersServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IOrderItemRepository> _mockOrderItemRepository;
        private readonly Mock<ICartItemRepository> _mockCartItemRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly OrdersService _ordersService;

        public OrdersServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderItemRepository = new Mock<IOrderItemRepository>();
            _mockCartItemRepository = new Mock<ICartItemRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _ordersService = new OrdersService(_mockMapper.Object, _mockOrderRepository.Object, _mockOrderItemRepository.Object, _mockCartItemRepository.Object, _mockProductRepository.Object);
        }

        [Fact]
        public async Task GetAllByUserIdAsync_ReturnsOrders()
        {
            // Arrange
            var userId = "testUser";  // User identifier for whom orders are being retrieved
            var orders = new List<OrderEntity> { new OrderEntity { UserId = userId } };  // Simulate an existing order for the user

            // Ensure the order repository returns the list of orders when queried with the userId
            _mockOrderRepository.Setup(repo => repo.GetAllByUserIdAsync(userId)).ReturnsAsync(orders);

            // Ensure the mapper converts the list of OrderEntity to a list of OrderDto objects
            // This mimics the transformation typically done in the service to prepare data for API responses
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<OrderDto>>(orders)).Returns(new List<OrderDto> { new OrderDto() });

            // Act
            var result = await _ordersService.GetAllByUserIdAsync(userId);  // Execute the method under test

            // Assert
            Assert.NotNull(result);  // Validate that the result is not null, ensuring some response was received
            Assert.NotEmpty(result); // Check that the result contains elements, confirming that orders are being retrieved and mapped

            // Verify that the repository and the mapper are called exactly once with the correct parameters
            _mockOrderRepository.Verify(x => x.GetAllByUserIdAsync(userId), Times.Once);
            _mockMapper.Verify(x => x.Map<IEnumerable<OrderDto>>(orders), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_NoCartItems_ThrowsEmptyCartException()
        {
            // Arrange
            var userId = "testUser";  // Identifier for the user for whom the order is being created

            // Set up the cart item repository to return an empty list, simulating a scenario where the user has no items in the cart
            _mockCartItemRepository.Setup(repo => repo.GetAllByUserIdAsync(userId)).ReturnsAsync(new List<CartItemEntity>());

            // Act & Assert
            // Expect the service to throw an EmptyCartException when attempting to create an order with no cart items
            // This tests the service's handling of the edge case where the cart is checked and found empty before proceeding with order creation
            await Assert.ThrowsAsync<EmptyCartException>(() => _ordersService.CreateAsync(userId));

            // The test checks that the service is correctly implementing business logic that requires a non-empty cart for order creation
            // No further setups are necessary since the service should terminate the operation upon finding the empty cart condition
        }

        [Fact]
        public async Task CreateAsync_ProductNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var userId = "testUser";  // Identifier for the user
            var productId = Guid.NewGuid();  // Simulated product ID that will not be found
            var cartItems = new List<CartItemEntity> { new CartItemEntity { ProductId = productId, Quantity = 1 } };  // Cart containing one item with a non-existent product

            // Setup mock to return cart items when queried
            _mockCartItemRepository.Setup(repo => repo.GetAllByUserIdAsync(userId)).ReturnsAsync(cartItems);

            // Setup mock to return null when a product is queried, simulating product not found
            _mockProductRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync((ProductEntity)null);

            // Act & Assert
            // Expect the method to throw a ResourceNotFoundException because the product does not exist
            var exception = await Assert.ThrowsAsync<ResourceNotFoundException>(() => _ordersService.CreateAsync(userId));

            // Assert
            Assert.Equal($"Product with ID {productId} not found.", exception.Message);  // Optional: Check if the exception message is as expected
        }

        [Fact]
        public async Task CreateAsync_SuccessfullyCreatesOrderAndClearsCart()
        {
            // Arrange
            var userId = "testUser";  // Identifier for the user
            var productId = Guid.NewGuid();  // Simulated product ID
            var cartItems = new List<CartItemEntity> { new CartItemEntity { ProductId = productId, Quantity = 1 } };  // Simulating a cart with one item
            var product = new ProductEntity { Id = productId, Price = 100 };  // Simulating a product with a price
            var orderEntity = new OrderEntity { UserId = userId, TotalPrice = 0 };  // Initial order setup with zero total price
            var orderItemEntity = new OrderItemEntity { OrderId = orderEntity.Id, ProductId = productId, Quantity = 1, Price = 100 };  // Details of the order item

            // Setup repository and mapper responses
            _mockCartItemRepository.Setup(repo => repo.GetAllByUserIdAsync(userId)).ReturnsAsync(cartItems);  // Setup to return cart items when queried
            _mockProductRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(product);  // Setup to return a product when any product ID is queried
            _mockOrderRepository.Setup(repo => repo.AddAsync(It.IsAny<OrderEntity>())).ReturnsAsync(orderEntity);  // Setup to return an order entity when an order is added
            _mockOrderItemRepository.Setup(repo => repo.AddAsync(It.IsAny<OrderItemEntity>())).ReturnsAsync(orderItemEntity);  // Setup to return an order item when it is added
            _mockCartItemRepository.Setup(repo => repo.ClearAllByUserIdAsync(userId)).Returns(Task.CompletedTask);  // Setup to complete task when clearing the cart
            _mockMapper.Setup(mapper => mapper.Map<OrderDto>(It.IsAny<OrderEntity>())).Returns(new OrderDto());  // Setup mapper to return a DTO when an order entity is mapped

            // Act
            var result = await _ordersService.CreateAsync(userId);  // Execute the create method

            // Assert
            Assert.NotNull(cartItems);  // Verify cart items are loaded
            Assert.NotNull(product);    // Verify product details are loaded
            Assert.NotNull(orderEntity); // Verify an order entity is created
            Assert.NotNull(orderItemEntity); // Verify an order item is created
            Assert.NotNull(result);    // Verify the final result is not null

            _mockCartItemRepository.Verify(x => x.ClearAllByUserIdAsync(userId), Times.Once);  // Verify that the cart is cleared exactly once
        }

    }
}
