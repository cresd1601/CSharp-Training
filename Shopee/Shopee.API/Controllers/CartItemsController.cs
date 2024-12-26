using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.DTOs;
using Shopee.Application.Services;
using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Controllers
{
    [ApiVersion("1.0")]
    public class CartItemsController : BaseController
    {
        private readonly ICartItemsService _cartItemsService;

        public CartItemsController(ICartItemsService cartItemsService)
        {
            _cartItemsService = cartItemsService;
        }

        // Get all cart item of current user
        // Get: /api/cartItems
        [HttpGet]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes

            IEnumerable<CartItemDto> cartItems = await _cartItemsService.GetAllByUserIdAsync(userId);

            return Ok(ApiResponseDto<IEnumerable<CartItemDto>>.Success(cartItems));
        }

        // Add Cart Item
        // Post: /api/cartItems
        [HttpPost]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateAsync([FromBody] CartItemCreateDto cartItemCreateDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes

            ApiResponseDto<CartItemDto> createdCartItem = await _cartItemsService.CreateByUserIdAsync(userId, cartItemCreateDto);
            
            if (!createdCartItem.Succeeded)
            {
                return NotFound(createdCartItem);
            }
            
            return Ok(createdCartItem);
        }

        // Update cart item
        // Put: /api/cartItems/<cart-item-id>
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] CartItemUpdateDto cartItemUpdateDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes
            
            ApiResponseDto<CartItemDto> updatedCartItem = await _cartItemsService.UpdateByUserIdAsync(userId, id, cartItemUpdateDto);

            if (!updatedCartItem.Succeeded)
            {
                if (updatedCartItem.ErrorCode == "NotFound")
                {
                    return NotFound(updatedCartItem);
                }
                
                return BadRequest(updatedCartItem);
            }
            
            return Ok(updatedCartItem);
        }

        // Delete cart item
        // Delete: /api/cartItems/<cart-item-id>
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes
            
            ApiResponseDto<CartItemDto> deletedCartItem = await _cartItemsService.DeleteByUserIdAsync(userId, id);
            
            if (!deletedCartItem.Succeeded)
            {
                return NotFound(deletedCartItem);
            }

            return Ok(deletedCartItem);
        }
    }
}

