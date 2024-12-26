using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.DTOs;
using Shopee.Application.Services;

namespace Shopee.API.Controllers
{
    [ApiVersion("1.0")]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // Get all orders of current user
        // Get: /api/orders
        [HttpGet]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes

            IEnumerable<OrderDto> orders = await _ordersService.GetAllByUserIdAsync(userId);

            return Ok(ApiResponseDto<IEnumerable<OrderDto>>.Success(orders));
        }

        // Add Order
        // Post: /api/orders
        [HttpPost]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateAsync()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using System.Security.Claims.ClaimTypes

            OrderDto createdOrder = await _ordersService.CreateAsync(userId);

            return Ok(ApiResponseDto<OrderDto>.Success(createdOrder));
        }
    }
}

