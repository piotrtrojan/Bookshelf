namespace Bookshelf.Application.Nationality
{
    internal static class NationalitySqls
    {
        public const string GetNationalityIdByName = @"
            SELECT n.Id
            FROM Nationalities n
            WHERE n.Name = '{0}'";
    }
}
