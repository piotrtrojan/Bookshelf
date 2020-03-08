using Bookshelf.Application.Book.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Book.QueryHandler
{
    public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, GetBookByIdResponse>
    {
        private readonly string _connectionString;

        public GetBookByIdQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }
        public GetBookByIdResponse Handle(GetBookByIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.QueryFirstOrDefault<GetBookByIdResponse>(string.Format(BookSqls.GetBookById, query.BookId));
            }
        }
    }
}
