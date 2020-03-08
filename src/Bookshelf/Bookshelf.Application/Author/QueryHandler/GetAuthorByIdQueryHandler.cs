using Bookshelf.Application.Author.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Bookshelf.WebContract.Author.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Author.QueryHandler
{
    public class GetAuthorByIdQueryHandler : IQueryHandler<GetAuthorByIdQuery, GetAuthorByIdResponse>
    {
        private readonly string _connectionString;

        public GetAuthorByIdQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }

        public GetAuthorByIdResponse Handle(GetAuthorByIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.QueryFirstOrDefault<GetAuthorByIdResponse>(string.Format(AuthorSqls.GetAuthorById, query.AuthorId));
            }
        }
    }
}
