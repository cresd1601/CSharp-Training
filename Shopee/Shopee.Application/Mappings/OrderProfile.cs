using AutoMapper;

using Shopee.Infrastructure.Entities;

using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderEntity, OrderDto>().ReverseMap();
        }
    }
}