using Bookshelf.Application.Book.Query;
using Bookshelf.Application.BookTag;
using Bookshelf.Application.BookTag.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.BookTag.QueryHandler
{
    public class GetBookTagIdByNameQueryHandler : IQueryHandler<GetBookTagIdByNameQuery, int?>
    {
        private readonly string _connectionString;

        public GetBookTagIdByNameQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }
        public int? Handle(GetBookTagIdByNameQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.ExecuteScalar<int?>(string.Format(BookTagSqls.GetBookTagIdByName, query.Name));
            }
        }
    }
}
