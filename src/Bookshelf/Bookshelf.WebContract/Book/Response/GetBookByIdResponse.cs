using System.Collections.Generic;
using Bookshelf.WebContract.BookTag.Response;

namespace Bookshelf.WebContract.Book.Response
{
    public class GetBookByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int? MaxLoanDays { get; set; }
        public int AuthorId { get; set; }
        public ICollection<BookTagResponse> BookTags { get; set; }

    }
}
