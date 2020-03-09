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
    /// <summary>
    /// Controller containing methods connected with Authors.
    /// </summary>
    [Route("api/Author")]
    public class AuthorController : BaseBookshelfController
    {
        /// <summary>
        /// Instantiates AuthorController.
        /// </summary>
        /// <param name="appExecutor"></param>
        /// <param name="mapper"></param>
        public AuthorController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        {

        }

        /// <summary>
        /// Returns single author by its identifier.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId}")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetAuthorById(int authorId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetAuthorByIdQuery { AuthorId = authorId }));
        }

        /// <summary>
        /// Returns list of books assigned to given author.
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{authorId}/Books")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetBooksByAuthor(int authorId, [FromQuery] GetBooksByAuthorRequest request)
        {
            // throw new NotImplementedException();
            var query = mapper.Map<GetBooksByAuthorQuery>(request);
            query.AuthorId = authorId;
            return HandleQueryResult(appExecutor.Dispatch(query));
        }


        /// <summary>
        /// Creates new author.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
