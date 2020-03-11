using Bookshelf.Validator.Shared;
using Bookshelf.Validator.Shared.Interfaces;
using Bookshelf.WebContract.Book.Request;
using FluentValidation;

namespace Bookshelf.Validator.Book
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator(IAuthorValidator authorValidator)
        {
            RuleFor(q => q.AuthorId)
               .NotEmpty()
               .NotNull()
               .Must(q => authorValidator.AuthorExists(q))
               .WithMessage(SharedValidationMessages.AuthorNotFound);

            RuleFor(q => q.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(q => q.Pages)
                .NotNull()
                .InclusiveBetween(1, 99_999);

            RuleFor(q => q.MaxLoanDays.Value)
                .InclusiveBetween(1, 365)
                .When(q => q.MaxLoanDays.HasValue);

            RuleForEach(q => q.BookTags)
                .Length(1, 300);
        }
    }
}
