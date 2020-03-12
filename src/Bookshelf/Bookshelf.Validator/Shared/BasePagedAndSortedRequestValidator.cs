using System.Linq;
using Bookshelf.Contract.Enum;
using Bookshelf.Utils.Config;
using Bookshelf.WebContract.Base;
using FluentValidation;

namespace Bookshelf.Validator.Shared
{
    public class BasePagedAndSortedRequestValidator<T, TResponse> : AbstractValidator<T> where T : BasePagedAndSortedRequest
    {
        public BasePagedAndSortedRequestValidator(ValidatorConfig validatorConfig)
        {
            RuleFor(q => q.Limit)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1, validatorConfig.MaxPageSize);
            
            RuleFor(q => q.Page)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(q => q.Order)
                .NotNull()
                .NotEmpty()
                .IsEnumName(typeof(OrderEnum));

            RuleFor(q => q.OrderBy)
                .NotNull()
                .NotEmpty()
                .Must(IsOrderCorrect)
                .WithMessage(SharedValidationMessages.InvalidOrderBy);
        }

        private bool IsOrderCorrect(string orderBy)
        {
            var properties = typeof(TResponse).GetProperties();
            return properties.Any(q => q.Name.ToLowerInvariant() == orderBy.ToLowerInvariant());
        }
    }
}
