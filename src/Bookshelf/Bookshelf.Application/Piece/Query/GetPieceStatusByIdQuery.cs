using Bookshelf.Contract.Base;
using Bookshelf.Model.Enum;

namespace Bookshelf.Application.Piece.Query
{
    public class GetPieceStatusByIdQuery : IQuery<PieceStatus>
    {
        public int PieceId { get; set; }
    }
}
