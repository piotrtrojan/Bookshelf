using System.Collections.Generic;

namespace Bookshelf.WebContract.Book.Response
{
    public class GetBookByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int MaxLoanDays { get; set; }
        public int AuthorId { get; set; }
        public ICollection<string> BookTags { get; set; } // TODO: Add handler to fill it.

    }
}
