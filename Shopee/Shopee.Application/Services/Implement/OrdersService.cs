using AutoMapper;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.Exceptions;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Services.Implement
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;


        public OrdersService(IMapper mapper, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllByUserIdAsync(string userId)
        {
            IEnumerable<OrderEntity> orderEntities = await _orderRepository.GetAllByUserIdAsync(userId);

            IEnumerable<OrderDto> orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);

            return orderDtos;
        }

        public async Task<OrderDto> CreateAsync(string userId)
        {
            IEnumerable<CartItemEntity> cartItems = await _cartItemRepository.GetAllByUserIdAsync(userId);

            if (!cartItems.Any())
            {
                throw new EmptyCartException();
            }

            // Step 1: Create the order with an initial total price of 0
            OrderEntity orderEntity = new OrderEntity { UserId = userId, TotalPrice = 0 };

            OrderEntity addedOrderEntity = await _orderRepository.AddAsync(orderEntity);

            decimal totalPrice = 0;

            // Step 2: Calculate the total price and create OrderItemEntity instances
            foreach (CartItemEntity cartItem in cartItems)
            {
                ProductEntity product = await _productRepository.GetFirstAsync(p => p.Id == cartItem.ProductId);
                
                if (product == null)
                {
                    throw new ResourceNotFoundException($"Product with ID {cartItem.ProductId} not found.");
                }

                totalPrice += product.Price * cartItem.Quantity;

                OrderItemEntity orderItem = new OrderItemEntity
                {
                    OrderId = addedOrderEntity.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = product.Price
                };

                await _orderItemRepository.AddAsync(orderItem);
            }

            // Step 3: Update the order with the calculated total price
            addedOrderEntity.TotalPrice = totalPrice;

            OrderEntity updatedOrderEntity = await _orderRepository.UpdateAsync(addedOrderEntity);

            // Step 4: Clear current cart
            await _cartItemRepository.ClearAllByUserIdAsync(userId);

            return _mapper.Map<OrderDto>(updatedOrderEntity);
        }
    }
}

