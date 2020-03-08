using AutoMapper;
using Bookshelf.Application.Book.Query;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.WebHost.Controllers
{
    [Route("api/Book")]
    public class BookController : BaseBookshelfController
    {
        public BookController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        {

        }

        [HttpGet("{bookId}")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetBookById(int bookId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetBookByIdQuery { BookId = bookId }));
        }
    }
}
