using Bookshelf.Validator.Shared;
using Bookshelf.Validator.Shared.Interfaces;
using Bookshelf.WebContract.Author.Request;
using FluentValidation;

namespace Bookshelf.Validator.Author
{
    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorRequestValidator(INationalityValidator nationalityValidator)
        {
            RuleFor(q => q.FirstName)
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(q => q.LastName)
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(q => q.Nationality)
               .NotEmpty()
               .Must(nationality => nationalityValidator.ValidateNationality(nationality))
               .WithMessage(SharedValidationMessages.InvalidNationality);
        }

    }
}
