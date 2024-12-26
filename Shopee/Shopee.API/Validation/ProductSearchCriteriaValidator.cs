using FluentValidation;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Validation
{
    public class ProductSearchCriteriaValidator : AbstractValidator<ProductSearchCriteriaDto>
    {
        public ProductSearchCriteriaValidator() {
            RuleFor(productSearchCriteria => productSearchCriteria.Page)
                .GreaterThan(0).WithMessage("Page must greater than 0");
            RuleFor(productSearchCriteria => productSearchCriteria.PageSize)
                .GreaterThan(0).WithMessage("Page Size must greater than 0");
            RuleFor(productSearchCriteria => productSearchCriteria.MinPrice)
                .GreaterThan(0).WithMessage("Min price must greater than 0");
            RuleFor(productSearchCriteria => productSearchCriteria.MaxPrice)
                .GreaterThan(0).WithMessage("Max price must greater than 0")
                .LessThanOrEqualTo(999).WithMessage("Max price must less than 1000");
        }
    }
}
