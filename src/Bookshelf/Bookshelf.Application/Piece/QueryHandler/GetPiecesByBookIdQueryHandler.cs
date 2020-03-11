using Bookshelf.Application.Piece.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Bookshelf.WebContract.Piece.Response;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Bookshelf.Application.Piece.QueryHandler
{
    public class GetPiecesByBookIdQueryHandler : IQueryHandler<GetPiecesByBookIdQuery, ICollection<BookPiecesResponse>>
    {
        private readonly string _connectionString;

        public GetPiecesByBookIdQueryHandler(GlobalConfig globalConfig)
        {
            this._connectionString = globalConfig.QueryConnectionString;
        }

        public ICollection<BookPiecesResponse> Handle(GetPiecesByBookIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.Query<BookPiecesResponse>(string.Format(PieceSqls.GetPiecesByBookId, query.BookId)).AsList();
            }
        }
    }
}
