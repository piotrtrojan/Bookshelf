using Bookshelf.Application.Piece.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Piece.QueryHandler
{
    public class GetMaxLoanDaysForPieceQueryHandler : IQueryHandler<GetMaxLoanDaysForPieceQuery, int>
    {
        private readonly string _connectionString;
        private readonly int _globalLimit;

        public GetMaxLoanDaysForPieceQueryHandler(GlobalConfig globalConfig, LibraryConfig libraryConfig)
        {
            this._connectionString = globalConfig.QueryConnectionString;
            this._globalLimit = libraryConfig.MaxLoanDays;

        }

        public int Handle(GetMaxLoanDaysForPieceQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var pieceMaxLoanDays = sqlConnection.ExecuteScalar<int?>(string.Format(PieceSqls.GetMaxLoanDaysByPieceId, query.PieceId));
                // if (pieceMaxLoanDays.HasValue)
            }

            return 100; // TEMP
        }
    }
}
