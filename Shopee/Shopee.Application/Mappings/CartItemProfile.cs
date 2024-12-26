using AutoMapper;

using Shopee.Infrastructure.Entities;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.DTOs.Incoming;

namespace Shopee.Application.Mappings
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemEntity, ProductCreateDto>().ReverseMap();
            CreateMap<CartItemEntity, CartItemDto>().ReverseMap();
        }
    }
}