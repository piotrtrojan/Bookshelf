using System.Collections.Generic;
using Bookshelf.Application.Book.Query;
using Bookshelf.Application.BookTag.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;
using Bookshelf.WebContract.Book.Response;
using Bookshelf.WebContract.BookTag.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bookshelf.Application.Book.QueryHandler
{
    public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, GetBookByIdResponse>
    {
        private readonly string _connectionString;
        private readonly IQueryHandler<GetBookTagsByBookIdQuery, ICollection<BookTagResponse>> getBookTagsByBookIdQueryHandler;

        public GetBookByIdQueryHandler(
            GlobalConfig config,
            IQueryHandler<GetBookTagsByBookIdQuery, ICollection<BookTagResponse>> getBookTagsByBookIdQueryHandler)
        {
            _connectionString = config.QueryConnectionString;
            this.getBookTagsByBookIdQueryHandler = getBookTagsByBookIdQueryHandler;
        }
        public GetBookByIdResponse Handle(GetBookByIdQuery query)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var book = sqlConnection.QueryFirstOrDefault<GetBookByIdResponse>(string.Format(BookSqls.GetBookById, query.BookId));
                book.BookTags = getBookTagsByBookIdQueryHandler.Handle(new GetBookTagsByBookIdQuery { BookId = query.BookId });
                return book;
            }
        }
    }
}
