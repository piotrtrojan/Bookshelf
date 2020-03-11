using Bookshelf.Application.Nationality.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Nationality.QueryHandler
{
    public class GetNationalityIdByNameQueryHandler : IQueryHandler<GetNationalityIdByNameQuery, int?>
    {
        private readonly string _connectionString;

        public GetNationalityIdByNameQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }
        public int? Handle(GetNationalityIdByNameQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                return sqlConnection.ExecuteScalar<int?>(string.Format(NationalitySqls.GetNationalityIdByName, query.Name));
            }
        }
    }
}
