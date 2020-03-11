using Bookshelf.Contract;
using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Response;

namespace Bookshelf.Application.Book.Query
{
    public class GetBooksByAuthorQuery : BasePagedAndSortedQuery, IQuery<BasePagedAndSortedResult<GetBookByIdResponse>>
    {
        public int AuthorId { get; set; }
    }
}
