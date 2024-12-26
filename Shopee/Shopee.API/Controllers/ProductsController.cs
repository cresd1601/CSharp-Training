using Microsoft.AspNetCore.Mvc;

using Shopee.Application.Services;

using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Microsoft.AspNetCore.Authorization;

namespace Shopee.API.Controllers
{
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // Get Products
        // Get: /api/products?search=<Inputted-Product-Name>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll([FromQuery] ProductSearchCriteriaDto productSearchCriteriaDto)
        {
            PagedListDto<IEnumerable<ProductDto>> products = await _productsService.GetAllAsync(productSearchCriteriaDto);

            return Ok(ApiResponseDto<PagedListDto<IEnumerable<ProductDto>>>.Success(products));
        }

        // Add Product
        // Post: /api/products
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateDto productCreateDto)
        {
            ProductDto createdProduct = await _productsService.CreateAsync(productCreateDto);

            return Ok(ApiResponseDto<ProductDto>.Success(createdProduct));
        }

        // Update Product
        // Put: /api/products/<Product-Id>
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] ProductCreateDto productCreateDto)
        {
            ProductDto updatedProduct = await _productsService.UpdateAsync(id, productCreateDto);

            if (updatedProduct == null)
            {
                return NotFound(ApiResponseDto<CartItemDto>.Failure(["Product not found."], "NotFound"));
            }
            
            return Ok(ApiResponseDto<ProductDto>.Success(updatedProduct));
        }

        // Delete Product
        // Delete: /api/products/<Product-Id>
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            ProductDto deletedProduct = await _productsService.DeleteAsync(id);

            if (deletedProduct == null)
            {
                return NotFound(ApiResponseDto<CartItemDto>.Failure(["Product not found."], "NotFound"));
            }
            
            return Ok(ApiResponseDto<ProductDto>.Success(deletedProduct));
        }
    }
}

