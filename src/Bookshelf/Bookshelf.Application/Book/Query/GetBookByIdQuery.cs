using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Book.Response;

namespace Bookshelf.Application.Book.Query
{
    public class GetBookByIdQuery : IQuery<GetBookByIdResponse>
    {
        public int BookId { get; set; }
    }
}
