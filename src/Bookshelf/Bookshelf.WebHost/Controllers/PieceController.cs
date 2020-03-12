using AutoMapper;
using Bookshelf.Application.Book.Command;
using Bookshelf.Application.Book.Query;
using Bookshelf.Application.Piece.Command;
using Bookshelf.Application.Piece.Query;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebContract.Book.Request;
using Bookshelf.WebContract.Piece.Request;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.WebHost.Controllers
{
    /// <summary>
    /// Controller containing methods connected with Book Piece.
    /// </summary>
    [Route("api/Piece")]
    public class PieceController : BaseBookshelfController
    {
        /// <summary>
        /// Instantiates PieceController.
        /// </summary>
        /// <param name="appExecutor"></param>
        /// <param name="mapper"></param>
        public PieceController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        {}

        /// <summary>
        /// Creates new piece
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [RoleAuthorize(RoleType.Root)]
        public IActionResult CreatePiece(CreatePieceRequest request)
        {
            var command = mapper.Map<CreatePieceCommand>(request);
            // command.CreatedBy = CurrentAccountId;
            return HandleCommandResult(appExecutor.Dispatch(command));
        }
    }
}
