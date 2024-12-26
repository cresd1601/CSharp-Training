using AutoMapper;

using Shopee.Infrastructure.Entities;

using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.DTOs.Incoming;

namespace Shopee.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductCreateDto>().ReverseMap();
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}