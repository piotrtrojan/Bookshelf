using Bookshelf.Application.Author.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Author.QueryHandler
{
    public class DoesAuthorExistQueryHandler : IQueryHandler<DoesAuthorExistQuery, bool>
    {
        private readonly string _connectionString;

        public DoesAuthorExistQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }

        public bool Handle(DoesAuthorExistQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.ExecuteScalar<bool>(string.Format(AuthorSqls.DoesAuthorExist, query.AuthorId));
            }
        }
    }
}
