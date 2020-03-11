using Bookshelf.Contract.Base;

namespace Bookshelf.Application.Piece.Query
{
    public class GetMaxLoanDaysForPieceQuery : IQuery<int>
    {
        public int PieceId { get; set; }
    }
}
