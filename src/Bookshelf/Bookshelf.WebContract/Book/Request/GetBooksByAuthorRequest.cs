using Bookshelf.WebContract.Base;

namespace Bookshelf.WebContract.Book.Request
{
    /// <summary>
    /// Request DTO for getting books connected with author. Contains sorting and Paging.
    /// </summary>
    public class GetBooksByAuthorRequest : BasePagedAndSortedRequest
    {
    }
}
