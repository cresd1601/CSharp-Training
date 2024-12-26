using AutoMapper;

using Shopee.Infrastructure.Entities;

using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Mappings
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemEntity, OrderItemDto>().ReverseMap();
        }
    }
}