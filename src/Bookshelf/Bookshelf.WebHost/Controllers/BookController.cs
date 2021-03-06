﻿using AutoMapper;
using Bookshelf.Application.Book.Command;
using Bookshelf.Application.Book.Query;
using Bookshelf.Application.Piece.Query;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Request;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.WebHost.Controllers
{
    /// <summary>
    /// Controller containing methods connected with Books.
    /// </summary>
    [Route("api/Book")]
    public class BookController : BaseBookshelfController
    {
        /// <summary>
        /// Instantiates BookController.
        /// </summary>
        /// <param name="appExecutor"></param>
        /// <param name="mapper"></param>
        public BookController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        { }

        /// <summary>
        /// Creates new book
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [RoleAuthorize(RoleType.Root)]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            var command = mapper.Map<CreateBookCommand>(request);
            command.CreatedBy = CurrentAccountId;
            return HandleCommandResult(appExecutor.Dispatch(command));
        }

        /// <summary>
        /// Returns single book by its identifier.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetBookById(int bookId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetBookByIdQuery { BookId = bookId }));
        }

        /// <summary>
        /// Returns list of pieces for a book.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}/Pieces")]
        [RoleAuthorize(RoleType.Account)]
        public IActionResult GetPiecesByBookId(int bookId)
        {
            return HandleQueryResult(appExecutor.Dispatch(new GetPiecesByBookIdQuery { BookId = bookId })); // TODO: Consider using pagination query here.
        }
    }
}
