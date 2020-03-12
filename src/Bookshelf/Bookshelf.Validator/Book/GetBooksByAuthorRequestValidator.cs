using Bookshelf.Utils.Config;
using Bookshelf.Validator.Shared;
using Bookshelf.WebContract.Book.Request;
using Bookshelf.WebContract.Book.Response;

namespace Bookshelf.Validator.Book
{
    public class GetBooksByAuthorRequestValidator : BasePagedAndSortedRequestValidator<GetBooksByAuthorRequest, GetBookByIdResponse>
    {
        public GetBooksByAuthorRequestValidator(ValidatorConfig validatorConfig) : base(validatorConfig)
        {
        }
    }
}
