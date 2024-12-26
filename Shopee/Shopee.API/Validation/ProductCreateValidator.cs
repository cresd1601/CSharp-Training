using FluentValidation;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Validation
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator() {
            RuleFor(productCreate => productCreate.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Name has to be a maximum of 100 characters");
            RuleFor(productCreate => productCreate.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must greater than 0")
                .LessThanOrEqualTo(999).WithMessage("Price must less than 1000");
            RuleFor(productCreate => productCreate.Description)
                .NotEmpty()
                .MaximumLength(5000).WithMessage("Description has to be a maximum of 5000 characters");
            RuleFor(productCreate => productCreate.StockQuantity)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Stock Quantity must greater than 0")
                .LessThanOrEqualTo(999).WithMessage("Quantity Stock must less than 1000");
        }
    }
}
