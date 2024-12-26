using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Shopee.Application.Services;
using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.API.Controllers;
using System.Security.Claims;


namespace Shopee.API.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductsService> _mockProductsService;
        private readonly ProductsController _controller;
        private readonly ClaimsPrincipal _user;

        public ProductsControllerTests()
        {
            _mockProductsService = new Mock<IProductsService>();
            _controller = new ProductsController(_mockProductsService.Object);

            // Setup the ControllerContext to simulate an authenticated user
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "userId"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = _user }
            };
        }

        [Fact]
        public async Task GetAll_ReturnsOkWithProducts()
        {
            // Arrange
            var productSearchCriteriaDto = new ProductSearchCriteriaDto();
            var products = new List<ProductDto>
            {
                new ProductDto { Id = Guid.NewGuid(), Name = "Test Product" }
            };
            var pagedProducts = new PagedListDto<IEnumerable<ProductDto>>(
                data: products,
                currentPage: 1,
                pageSize: 10,
                totalPages: 1
            );

            _mockProductsService.Setup(s => s.GetAllAsync(It.IsAny<ProductSearchCriteriaDto>()))
                                .ReturnsAsync(pagedProducts);

            // Act
            var result = await _controller.GetAll(productSearchCriteriaDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseDto<PagedListDto<IEnumerable<ProductDto>>>>(okResult.Value);

            Assert.True(apiResponse.Succeeded);
            Assert.Single(apiResponse.Result.Data);
            Assert.Equal(1, apiResponse.Result.CurrentPage);
            Assert.Equal(10, apiResponse.Result.PageSize);
            Assert.Equal(1, apiResponse.Result.TotalPages);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedProduct()
        {
            // Arrange
            var newProductDto = new ProductCreateDto { Name = "New Product" };
            var createdProductDto = new ProductDto { Id = Guid.NewGuid(), Name = "New Product" };

            _mockProductsService.Setup(s => s.CreateAsync(newProductDto)).ReturnsAsync(createdProductDto);

            // Act
            var result = await _controller.CreateAsync(newProductDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<ProductDto>>(okResult.Value);

            Assert.True(response.Succeeded);
            Assert.Equal("New Product", response.Result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsUpdatedProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productUpdateDto = new ProductCreateDto { Name = "Updated Product" };
            var updatedProductDto = new ProductDto { Id = productId, Name = "Updated Product" };

            _mockProductsService.Setup(s => s.UpdateAsync(productId, productUpdateDto)).ReturnsAsync(updatedProductDto);

            // Act
            var result = await _controller.UpdateAsync(productId, productUpdateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<ProductDto>>(okResult.Value);

            Assert.True(response.Succeeded);
            Assert.Equal("Updated Product", response.Result.Name);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsDeletedProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var deletedProductDto = new ProductDto { Id = productId, Name = "Deleted Product" };

            _mockProductsService.Setup(s => s.DeleteAsync(productId)).ReturnsAsync(deletedProductDto);

            // Act
            var result = await _controller.DeleteAsync(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<ProductDto>>(okResult.Value);

            Assert.True(response.Succeeded);
            Assert.Equal("Deleted Product", response.Result.Name);
        }
    }
}