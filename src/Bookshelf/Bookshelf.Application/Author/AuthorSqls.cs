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
            WHERE a.IsActive = 1
                AND a.Id = {0}
        ";

        public const string DoesAuthorExist = @"
            SELECT Count(1)
            FROM Authors a
            WHERE a.IsActive = 1
                AND a.Id = {0}
        ";
    }
}
