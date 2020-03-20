using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Application.Reservation.Command;
using Bookshelf.Authorization.Attribute;
using Bookshelf.Authorization.Enum;
using Bookshelf.Utils;
using Bookshelf.WebContract.Author.Request;
using Bookshelf.WebContract.Reservation.Request;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.WebHost.Controllers
{
    /// <summary>
    /// Controller containing methods connected with Reservations.
    /// </summary>
    [Route("api/Reservation")]
    public class ReservationController : BaseBookshelfController
    {
        /// <summary>
        /// Instantiates ReservationController.
        /// </summary>
        /// <param name="appExecutor"></param>
        /// <param name="mapper"></param>
        public ReservationController(AppExecutor appExecutor, IMapper mapper) : base(appExecutor, mapper)
        {

        }

        /// <summary>
        /// Endpoint for reserving available piece.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Order")]
        [RoleAuthorize(RoleType.Root)]
        public IActionResult CreateAuthor(MakeOrderRequest request)
        {
            var command = mapper.Map<MakeOrderCommand>(request);
            command.UserId = CurrentAccountId;
            return HandleCommandResult(appExecutor.Dispatch(command));
        }
    }
}
