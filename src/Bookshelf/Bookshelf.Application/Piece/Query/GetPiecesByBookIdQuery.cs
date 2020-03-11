using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Piece.Response;
using System.Collections.Generic;

namespace Bookshelf.Application.Piece.Query
{
    public class GetPiecesByBookIdQuery : IQuery<ICollection<BookPiecesResponse>>
    {
        public int BookId { get; set; }
    }
}
