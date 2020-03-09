using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Book.Response;

namespace Bookshelf.Application.Book.Query
{
    public class GetBooksByAuthorQuery : IPagedAndSortedQuery<GetBookByIdResponse>
    {
        public int AuthorId { get; set; }
        public string OrderBy { get; set; }
        public string Order { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
