using FluentValidation;

using Shopee.Application.DTOs.Incoming;

namespace Shopee.API.Validation
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationValidator()
        {
            RuleFor(userRegister => userRegister.Username)
                .NotEmpty()
                .EmailAddress();
            RuleFor(userRegister => userRegister.Password)
                .NotEmpty();
            RuleFor(userRegister => userRegister.Role)
                .NotEmpty();
        }
    }
}
