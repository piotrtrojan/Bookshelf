using System;
using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Application.Author.Query;
using Bookshelf.Application.Book.Query;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebContract.Author.Request;
using Bookshelf.WebContract.Book.Request;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.WebHost.Controllers
{
    [Route("api/Author")]
    public class AuthorController : BaseBookshelfController
    {
        public AuthorController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        {

        }

        [HttpGet("{authorId}")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetAuthorById(int authorId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetAuthorByIdQuery { AuthorId = authorId }));
        }

        [HttpGet("{authorId}/Books")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetBooksByAuthor(int authorId, [FromQuery] GetBooksByAuthorRequest request)
        {
            throw new NotImplementedException();
            var query = mapper.Map<GetBooksByAuthorQuery>(request);
            query.AuthorId = authorId;
            return HandleQueryResult(appExecutor.Dispatch(query));
        }

        [HttpPost("")]
        [RoleAuthorize(RoleType.Root)]
        public IActionResult CreateAuthor(CreateAuthorRequest request)
        {
            var command = mapper.Map<CreateAuthorCommand>(request);
            command.CreatedBy = CurrentAccountId;
            return HandleCommandResult(appExecutor.Dispatch(command));
        }
    }
}
