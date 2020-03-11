using System.Collections.Generic;
using Bookshelf.Application.BookTag.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Bookshelf.WebContract.BookTag.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.BookTag.QueryHandler
{
    public class GetBookTagsByBookIdQueryHandler : IQueryHandler<GetBookTagsByBookIdQuery, ICollection<BookTagResponse>>
    {
        private readonly string _connectionString;

        public GetBookTagsByBookIdQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }
        public ICollection<BookTagResponse> Handle(GetBookTagsByBookIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.Query<BookTagResponse>(string.Format(BookTagSqls.GetBookTagsByBookId, query.BookId)).AsList();
            }
        }
    }
}
