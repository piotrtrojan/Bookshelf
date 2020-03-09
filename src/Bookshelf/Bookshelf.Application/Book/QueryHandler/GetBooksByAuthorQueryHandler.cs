using Bookshelf.Application.Book.Query;
using Bookshelf.Contract.Base;
using Bookshelf.WebContract.Base;
using Bookshelf.WebContract.Book.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Application.Book.QueryHandler
{
    public class GetBooksByAuthorQueryHandler : IQueryHandler<GetBooksByAuthorQuery, GetBookByIdResponse>
    {
        public BasePagedAndSortedResult<GetBookByIdResponse> Handle(GetBooksByAuthorQuery query)
        {
            throw new NotImplementedException();
        }

        GetBookByIdResponse IQueryHandler<GetBooksByAuthorQuery, GetBookByIdResponse>.Handle(GetBooksByAuthorQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
