namespace Bookshelf.Application.Author
{
    internal static class AuthorSqls
    {
        public const string GetAuthorById = @"
            SELECT 
                a.Id,
                a.FirstName,
                a.LastName,
                a.NationalityId
            FROM Authors a
        ";
    }
}
