using AutoMapper;
using Bookshelf.Authorization.Enum;
using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace Bookshelf.WebHost.Controllers.Base
{
    /// <summary>
    /// Base class for all controllers. Contains method to handle CommandResults and QueryResults.
    /// </summary>
    [ApiController]
    [Authorize]
    public class BaseBookshelfController : ControllerBase
    {

        /// <summary>
        /// Returns GUID of currently logged used, based on its JWT token.
        /// </summary>
        protected Guid CurrentAccountGuid => Guid.Parse(this.User.FindFirstValue(JwtRegisteredClaimNames.Jti));

        /// <summary>
        /// Returns list of roles assigned to currently logged used.
        /// </summary>
        protected IEnumerable<RoleType> CurrentAccountRoles => this.User.Claims
            .Where(q => q.Type == ClaimsIdentity.DefaultRoleClaimType)
            .Select(p => (RoleType)Enum.Parse(typeof(RoleType), p.Value, true));

        /// <summary>
        /// Returns id of currently logged account. Id is retrieved from DB based on account GUID stored in JWT token.
        /// </summary>
        protected int CurrentAccountId => int.Parse(this.User.FindFirstValue(JwtRegisteredClaimNames.Sub));

        /// <summary>
        /// Instance of AppExecutor. Dispatech Queries and Commands to execute.
        /// </summary>
        protected readonly AppExecutor appExecutor;

        /// <summary>
        /// Instance of IMapper. Used to map/cast commands, request, reults etc.
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Instantiates LegeArtisBaseController.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="mapper"></param>
        protected BaseBookshelfController(AppExecutor executor, IMapper mapper)
        {
            appExecutor = executor;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles Command result. If Command is successful returns NoContent, otherwise - returns BadRequest.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult HandleCommandResult(CommandResult result)
        {
            if (!result.IsSuccess)
            {
                return Error(result.Error);
            }
            if (result.Message.Any())
            {
                return Ok(result.Message);
            }
            return NoContent();
        }

        /// <summary>
        /// Handles Query results. 
        /// Determines if result is collection or single element and executes proper method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult HandleQueryResult<T>(T result)
        {
            if (typeof(T) is ICollection)
                return HandleQueryCollectionResult(result);
            return HandleQueryElementResult(result);
        }

        private IActionResult HandleQueryCollectionResult<T>(T result)
        {
            return Ok(result);
        }

        private IActionResult Error(string error)
        {
            return BadRequest(error);
        }

        private IActionResult HandleQueryElementResult<T>(T result)
        {
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
