using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Piece.Response;
using System.Collections.Generic;

namespace Bookshelf.Application.Piece.Query
{
    public class DoesPieceExistQuery : IQuery<bool>
    {
        public int PieceId { get; set; }
    }
}
