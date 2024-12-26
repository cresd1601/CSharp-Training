using FluentValidation;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(userLogin => userLogin.Username)
                .NotEmpty()
                .EmailAddress();
            RuleFor(userLogin => userLogin.Password)
                .NotEmpty();
        }
    }
}
