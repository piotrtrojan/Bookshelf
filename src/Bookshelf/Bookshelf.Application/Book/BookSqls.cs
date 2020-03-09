namespace Bookshelf.Application.Book
{
    internal static class BookSqls
    {
        public const string GetBookById = @"
            SELECT
                b.Id,
                b.AuthorId,                
                b.Title,
                b.Pages,
                b.MaxLoanDays
            FROM Books b
            WHERE b.Id = {0}";
    }
}
