using System.Linq.Expressions;
using AutoMapper;

using Shopee.Application.DTOs.Incoming;
using Shopee.Application.DTOs.Outgoing;
using Shopee.Application.Exceptions;

using Shopee.Infrastructure.Entities;
using Shopee.Infrastructure.Repositories;

namespace Shopee.Application.Services.Implement
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedListDto<IEnumerable<ProductDto>>> GetAllAsync(ProductSearchCriteriaDto productSearchCriteriaDto)
        {
            Expression<Func<ProductEntity, bool>>? filterPredicate = null;
            Expression<Func<ProductEntity, object>>? orderPredicate = null;

            string searchTerm = productSearchCriteriaDto.SearchTerm ?? "";

            int pageNumber = productSearchCriteriaDto.Page ?? 1;
            int pageSize = productSearchCriteriaDto.PageSize ?? 10;

            decimal minPrice = productSearchCriteriaDto.MinPrice ?? 0;
            decimal maxPrice = productSearchCriteriaDto.MaxPrice ?? 999;

            bool orderByDescending = productSearchCriteriaDto.OrderByDescending ?? false;


            int totalCount = await _productRepository.CountAsync();

            // Determine the search expression based on search, minPrice, maxPrice parameter
            if (!string.IsNullOrWhiteSpace(productSearchCriteriaDto.SearchTerm) || productSearchCriteriaDto.MinPrice.HasValue || productSearchCriteriaDto.MinPrice.HasValue)
            {
                filterPredicate = product => product.Name.Contains(searchTerm) && product.Price >= minPrice && product.Price <= maxPrice;
            }

            // Determine the sort expression based on sortBy parameter
            if (!string.IsNullOrWhiteSpace(productSearchCriteriaDto.SortColumn))
            {
                switch (productSearchCriteriaDto.SortColumn.ToLower())
                {
                    case "name":
                        orderPredicate = product => product.Name;
                        break;
                    case "price":
                        orderPredicate = product => product.Price;
                        break;
                    // Add more cases for other properties if needed
                    default:
                        // Default sorting if sortBy parameter is invalid
                        orderPredicate = product => product.Name;
                        break;
                }
            }

            IEnumerable<ProductEntity> products = await _productRepository.GetAllAsync(
                filterPredicate,
                orderPredicate,
                orderByDescending,
                pageNumber,
                pageSize);

            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return new PagedListDto<IEnumerable<ProductDto>>(productDtos, pageNumber, pageSize, totalCount);
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto product)
        {
            ProductEntity productEntity = _mapper.Map<ProductEntity>(product);

            ProductEntity addedProduct = await _productRepository.AddAsync(productEntity);

            return _mapper.Map<ProductDto>(addedProduct);
        }

        public async Task<ProductDto?> UpdateAsync(Guid id, ProductCreateDto product)
        {
            ProductEntity exitingProduct = await _productRepository.GetFirstAsync(ti => ti.Id == id);

            if (exitingProduct == null)
            {
                return null;
            }

            exitingProduct.Name = product.Name;
            exitingProduct.Price = product.Price;
            exitingProduct.Description = product.Description;
            exitingProduct.StockQuantity = product.StockQuantity;

            ProductEntity updatedProduct = await _productRepository.UpdateAsync(exitingProduct);

            return _mapper.Map<ProductDto>(updatedProduct);

        }

        public async Task<ProductDto?> DeleteAsync(Guid id)
        {
            ProductEntity exitingProduct = await _productRepository.GetFirstAsync(tl => tl.Id == id);

            if (exitingProduct == null)
            {
                return null;
            }

            ProductEntity deletedProduct = await _productRepository.DeleteAsync(exitingProduct);

            return _mapper.Map<ProductDto>(deletedProduct);
        }
    }
}

