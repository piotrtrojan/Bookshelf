using System.Collections.Generic;
using Bookshelf.WebContract.BookTag.Response;

namespace Bookshelf.WebContract.Book.Response
{
    /// <summary>
    /// Response DTO containing single book.
    /// </summary>
    public class GetBookByIdResponse
    {
        /// <summary>
        /// Book identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// No. of pages.
        /// </summary>
        public int Pages { get; set; }
        /// <summary>
        /// Max loan days of the book. When null - no restriction.
        /// </summary>
        public int? MaxLoanDays { get; set; }
        /// <summary>
        /// Book's author identifier.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Tags assigned to book. <see cref="BookTagResponse"/>
        /// </summary>
        public ICollection<BookTagResponse> BookTags { get; set; }

    }
}
