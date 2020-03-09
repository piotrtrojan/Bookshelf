namespace Bookshelf.Application.BookTag
{
    internal static class BookTagSqls
    {
        public const string GetBookTagIdByName = @"
            SELECT
                bt.Id
            FROM BookTags bt
            WHERE bt.Tag = '{0}'";

        public const string GetBookTagsByBookId = @"
            SELECT
                bt.Id,
                bt.Tag
            FROM BookTags bt
            WHERE bt.BookId = '{0}'";
    }
}
