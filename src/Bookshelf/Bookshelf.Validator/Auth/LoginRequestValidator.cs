using Bookshelf.WebContract.Auth.Request;
using FluentValidation;

namespace Bookshelf.Validator.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(q => q.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(q => q.Password)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
