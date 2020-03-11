using Bookshelf.Application.Book.Query;
using Bookshelf.Contract;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils;
using Bookshelf.Utils.Extensions;
using Bookshelf.WebContract.Book.Response;
using Bookshelf.WebContract.BookTag.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bookshelf.Application.Book.QueryHandler
{
    public class GetBooksByAuthorQueryHandler : IQueryHandler<GetBooksByAuthorQuery, BasePagedAndSortedResult<GetBookByIdResponse>>
    {
        private readonly string _connectionString;

        public GetBooksByAuthorQueryHandler(GlobalConfig config)
        {
            _connectionString = config.QueryConnectionString;
        }
        public BasePagedAndSortedResult<GetBookByIdResponse> Handle(GetBooksByAuthorQuery query)
        {
            using (var ctx = new BookshelfDbContext(_connectionString))
            {
                var booksQueryable = ctx.Books
                    .Where(q => q.AuthorId == query.AuthorId && q.IsActive)
                    .Include(p => p.BookTags)
                    .Select(q => new GetBookByIdResponse
                    {
                        Id = q.Id,
                        Title = q.Title,
                        MaxLoanDays = q.MaxLoanDays,
                        Pages = q.Pages,
                        AuthorId = q.AuthorId,
                        BookTags = q.BookTags.Select(q => new BookTagResponse
                        {
                            Id  = q.Id,
                            Tag = q.Tag
                        }).ToList()
                    });
                
                return BasePagedAndSortedResult.GenerateFromQueryable(booksQueryable, query);
            }
        }
    }
}
