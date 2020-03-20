using Bookshelf.Application.Piece.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Model.Enum;
using Bookshelf.Utils.Config;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Piece.QueryHandler
{
    public class GetPieceStatusByIdQueryHandler : IQueryHandler<GetPieceStatusByIdQuery, PieceStatus>
    {
        private readonly string _connectionString;

        public GetPieceStatusByIdQueryHandler(GlobalConfig globalConfig)
        {
            this._connectionString = globalConfig.QueryConnectionString;
        }

        public PieceStatus Handle(GetPieceStatusByIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.ExecuteScalar<PieceStatus>(string.Format(PieceSqls.GetPieceStatusByPieceId, query.PieceId));
            }
        }
    }
}
