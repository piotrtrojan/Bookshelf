using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Author.Response;

namespace Bookshelf.Application.Author.Query
{
    public class GetAuthorByIdQuery : IQuery<GetAuthorByIdResponse>
    {
        public int AuthorId { get; set; }
    }
}
