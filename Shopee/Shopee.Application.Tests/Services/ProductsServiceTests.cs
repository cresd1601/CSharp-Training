using Moq;
using AutoMapper;
using System.Linq.Expressions;

using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;
using Shopee.Application.Exceptions;
using Shopee.Application.Services.Implement;

namespace Shopee.Application.Tests.Services
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductsService _productsService;

        public ProductsServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>();
            _productsService = new ProductsService(_mockProductRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsFilteredAndPagedResults()
        {
            // Arrange
            var criteria = new ProductSearchCriteriaDto
            {
                SearchTerm = "test",
                MinPrice = 100,
                MaxPrice = 500,
                Page = 1,
                PageSize = 10,
                SortColumn = "price",
                OrderByDescending = true
            };
            var products = new List<ProductEntity>
            {
                new ProductEntity { Id = Guid.NewGuid(), Name = "Test Product", Price = 200 }
            };
                    var productDtos = new List<ProductDto>
            {
                new ProductDto { Id = products[0].Id, Name = "Test Product", Price = 200 }
            };
            int totalCount = 1;  // Adjusting to match the total number of products provided

            // Mock setups to simulate repository and mapper behavior
            _mockProductRepository.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>(),
                It.IsAny<Expression<Func<ProductEntity, object>>>(), true, 1, 10))
                .ReturnsAsync(products);
            _mockProductRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(totalCount);  // Ensure total count matches number of products
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ProductDto>>(products)).Returns(productDtos);

            // Act
            var result = await _productsService.GetAllAsync(criteria);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(criteria.Page, result.CurrentPage);  // Verify the current page is correctly set
            Assert.Equal(criteria.PageSize, result.PageSize); // Confirm the PageSize passed through to result matches the criteria
            Assert.Equal(1, result.TotalPages);               // Ensure TotalPages is correctly calculated
            Assert.NotEmpty(result.Data);                     // Ensure the data contains products, validating filter and page size
            Assert.False(result.HasNextPage);                 // Check navigation property based on current page and total pages
        }

        [Fact]
        public async Task CreateAsync_AddsProductSuccessfully()
        {
            // Arrange
            var productDto = new ProductCreateDto { Name = "New Product", Price = 100 };
            var productEntity = new ProductEntity { Id = Guid.NewGuid(), Name = "New Product", Price = 100 };
            var returnedDto = new ProductDto { Id = productEntity.Id, Name = productEntity.Name, Price = productEntity.Price };

            _mockMapper.Setup(m => m.Map<ProductEntity>(productDto)).Returns(productEntity);
            _mockProductRepository.Setup(repo => repo.AddAsync(productEntity)).ReturnsAsync(productEntity);
            _mockMapper.Setup(m => m.Map<ProductDto>(productEntity)).Returns(returnedDto);

            // Act
            var result = await _productsService.CreateAsync(productDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(returnedDto.Name, result.Name);
            Assert.Equal(returnedDto.Price, result.Price);
        }

        [Fact]
        public async Task UpdateAsync_WhenProductNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productDto = new ProductCreateDto { Name = "Updated Product", Price = 150 };

            _mockProductRepository.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync((ProductEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _productsService.UpdateAsync(productId, productDto));
        }

        [Fact]
        public async Task DeleteAsync_WhenProductNotFound_ThrowsResourceNotFoundException()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _mockProductRepository.Setup(repo => repo.GetFirstAsync(tl => tl.Id == productId)).ReturnsAsync((ProductEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _productsService.DeleteAsync(productId));
        }
    }
}
