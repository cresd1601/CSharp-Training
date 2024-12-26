using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;

namespace Shopee.Application.Services
{
    public interface IProductsService
    {
        Task<PagedListDto<IEnumerable<ProductDto>>> GetAllAsync(ProductSearchCriteriaDto productSearchFilterDto);

        Task<ProductDto> CreateAsync(ProductCreateDto product);
        
        Task<ProductDto?> UpdateAsync(Guid id, ProductCreateDto product);
        
        Task<ProductDto?> DeleteAsync(Guid id);
    }
}

