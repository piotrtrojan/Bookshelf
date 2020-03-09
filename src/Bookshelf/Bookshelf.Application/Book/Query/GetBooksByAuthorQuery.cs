using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Book.Response;

namespace Bookshelf.Application.Book.Query
{
    public class GetBooksByAuthorQuery : IQuery<GetBookByIdResponse>
    {
        public int AuthorId { get; set; }
    }
}
