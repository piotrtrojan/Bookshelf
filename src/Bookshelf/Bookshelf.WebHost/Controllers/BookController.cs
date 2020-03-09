using AutoMapper;
using Bookshelf.Application.Book.Command;
using Bookshelf.Application.Book.Query;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Request;
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

        [HttpPost("")]
        [RoleAuthorize(RoleType.Root)]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            var command = mapper.Map<CreateBookCommand>(request);
            command.CreatedBy = CurrentAccountId;
            return HandleCommandResult(appExecutor.Dispatch(command));
        }

        [HttpGet("{bookId}")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetBookById(int bookId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetBookByIdQuery { BookId = bookId }));
        }
    }
}
