using System.Collections.Generic;
using Bookshelf.Contract.Base;
using Bookshelf.WebContract.BookTag.Response;

namespace Bookshelf.Application.BookTag.Query
{
    public class GetBookTagsByBookIdQuery : IQuery<ICollection<BookTagResponse>>
    {
        public int BookId { get; set; }
    }
}
