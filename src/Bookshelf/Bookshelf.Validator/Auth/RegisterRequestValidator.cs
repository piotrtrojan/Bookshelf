using Bookshelf.WebContract.Auth.Request;
using FluentValidation;

namespace Bookshelf.Validator.Auth
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(q => q.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(q => q.Password)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(q => q.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(q => q.LastName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
