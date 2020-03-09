namespace Bookshelf.WebContract.Book.Request
{
    /// <summary>
    /// DTO for creating new book.
    /// </summary>
    public class CreateBookRequest
    {
        /// <summary>
        /// New book's author id.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// New book's title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// New book's number of pages.
        /// </summary>
        public int Pages { get; set; }
        /// <summary>
        /// Max days of loaning for a book. Can be also specified by pieces.
        /// </summary>
        public int? MaxLoanDays { get; set; }
        /// <summary>
        /// List of tags to be added to the new book.
        /// </summary>
        public ICollection<string> BookTags { get; set; }
    }
}
