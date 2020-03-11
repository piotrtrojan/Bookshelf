using Bookshelf.Application.Author.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Validator.Shared.Interfaces;

namespace Bookshelf.Validator.Shared
{
    class AuthorValidator : IAuthorValidator
    {
        private readonly IQueryHandler<DoesAuthorExistQuery, bool> doesAuthorExistQueryHandler;

        public AuthorValidator(IQueryHandler<DoesAuthorExistQuery, bool> doesAuthorExistQueryHandler)
        {
            this.doesAuthorExistQueryHandler = doesAuthorExistQueryHandler;
        }

        public bool AuthorExists(int authorId)
        {
            return doesAuthorExistQueryHandler.Handle(new DoesAuthorExistQuery { AuthorId = authorId });
        }
    }
}
