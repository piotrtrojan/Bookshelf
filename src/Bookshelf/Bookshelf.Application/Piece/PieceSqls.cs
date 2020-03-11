namespace Bookshelf.Application.Piece
{
    internal class PieceSqls
    {
        public const string GetPiecesByBookId = @"
            SELECT 
                p.Id,
                p.BookId,
                p.Barcode,
                p.Status
            FROM Pieces p
            WHERE p.IsActive = 1 
                AND p.BookId = '{0}'";

        public const string GetMaxLoanDaysByPieceId = @"
            SELECT p.MaxLoanDays
            FROM Pieces p
            WHERE p.IsActive = 1
                AND p.Id = {0} 
        ";
    }
}
