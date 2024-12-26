using FluentValidation;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Validation
{
    public class CartItemCreateValidator : AbstractValidator<CartItemCreateDto>
    {
        public CartItemCreateValidator() {
            RuleFor(cartItemCreate => cartItemCreate.ProductId)
                .NotEmpty();
            RuleFor(cartItemCreate => cartItemCreate.Quantity)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Quantity must greater than 0")
                .LessThanOrEqualTo(999).WithMessage("Quantity must less than 1000");
        }
    }
}
