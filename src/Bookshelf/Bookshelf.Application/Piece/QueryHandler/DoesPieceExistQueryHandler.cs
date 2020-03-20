using Bookshelf.Application.Piece.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Piece.QueryHandler
{
    public class DoesPieceExistQueryHandler : IQueryHandler<DoesPieceExistQuery, bool>
    {
        private readonly string _connectionString;

        public DoesPieceExistQueryHandler(GlobalConfig globalConfig)
        {
            this._connectionString = globalConfig.QueryConnectionString;
        }

        public bool Handle(DoesPieceExistQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.ExecuteScalar<bool>(string.Format(PieceSqls.DoesPieceExistByPieceId, query.PieceId));
            }
        }
    }
}
