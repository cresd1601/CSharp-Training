using AutoMapper;
using Shopee.Application.DTOs;
using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Services.Implement
{
    public class CartItemsService : ICartItemsService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemsService(IProductRepository productRepository, ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartItemDto>> GetAllByUserIdAsync(string userId)
        {
            IEnumerable<CartItemEntity> cartItems = await _cartItemRepository.GetAllByUserIdAsync(userId);

            IEnumerable<CartItemDto> cartItemDtos = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);

            return cartItemDtos;
        }

        public async Task<ApiResponseDto<CartItemDto>> CreateByUserIdAsync(string userId, CartItemCreateDto cartItemCreateDto)
        {
            ProductEntity exitingProduct = await _productRepository.GetFirstAsync(ti => ti.Id == cartItemCreateDto.ProductId);

            // Retrieve the product to check the available stock
            if (exitingProduct == null)
            {
                return ApiResponseDto<CartItemDto>.Failure(new List<string> { "Product not found." }, "NotFound");
            }

            // Check if the requested quantity exceeds the available stock
            if (cartItemCreateDto.Quantity > exitingProduct.StockQuantity)
            {
                return ApiResponseDto<CartItemDto>.Failure(new List<string> { "Requested quantity exceeds available stock." }, "BadRequest");
            }

            // Create a new cart item
            CartItemEntity cartItemEntity = new CartItemEntity
            {
                UserId = userId,
                ProductId = cartItemCreateDto.ProductId,
                Quantity = cartItemCreateDto.Quantity
            };

            CartItemEntity addedCartItem = await _cartItemRepository.AddAsync(cartItemEntity);

            return ApiResponseDto<CartItemDto>.Success(_mapper.Map<CartItemDto>(addedCartItem));
        }

        public async Task<ApiResponseDto<CartItemDto>> UpdateByUserIdAsync(string userId, Guid id, CartItemUpdateDto cartItem)
        {
            CartItemEntity exitingCartItem = await _cartItemRepository.GetFirstAsync(item => item.Id == id && item.UserId == userId);

            if (exitingCartItem == null)
            {
                return ApiResponseDto<CartItemDto>.Failure(["Cart item not found."], "NotFound");
            }
            
            exitingCartItem.Quantity = cartItem.Quantity;

            CartItemEntity updatedCartItem = await _cartItemRepository.UpdateAsync(exitingCartItem);

            return ApiResponseDto<CartItemDto>.Success(_mapper.Map<CartItemDto>(updatedCartItem));
        }

        public async Task<ApiResponseDto<CartItemDto>> DeleteByUserIdAsync(string userId, Guid id)
        {
            CartItemEntity exitingCartItem = await _cartItemRepository.GetFirstAsync(item => item.Id == id && item.UserId == userId);

            if (exitingCartItem == null)
            {
                return ApiResponseDto<CartItemDto>.Failure(["Cart item not found."], "NotFound");
            }

            CartItemEntity deletedCartItem = await _cartItemRepository.DeleteAsync(exitingCartItem);

            return ApiResponseDto<CartItemDto>.Success(_mapper.Map<CartItemDto>(deletedCartItem));
        }
    }
}

