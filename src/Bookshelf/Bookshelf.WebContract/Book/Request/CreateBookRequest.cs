using System.Collections.Generic;

namespace Bookshelf.WebContract.Book.Request
{
    public class CreateBookRequest
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int? MaxLoanDays { get; set; }
        public ICollection<string> BookTags { get; set; }
    }
}
