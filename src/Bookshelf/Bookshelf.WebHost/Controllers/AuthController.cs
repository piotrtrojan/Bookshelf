using AutoMapper;
using Bookshelf.Application.User.Command;
using Bookshelf.Authorization.Exceptions;
using Bookshelf.Authorization.Interfaces;
using Bookshelf.Utils;
using Bookshelf.WebContract.Auth.Request;
using Bookshelf.WebHost.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookshelf.WebHost.Controllers
{
    /// <summary>
    /// Controller containig endpoints related to token issuing and validating.
    /// </summary>
    [Authorize]
    [ApiController]
    public class AuthController : BaseBookshelfController
    {
        private readonly ITokenService tokenService;
        private readonly IRegisterService registerService;

        /// <summary>
        /// Instantiates AuthController
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="registerService"></param>
        /// <param name="appExecutor"></param>
        /// <param name="mapper"></param>
        public AuthController(
            ITokenService tokenService,
            IRegisterService registerService,
            AppExecutor appExecutor,
            IMapper mapper) 
            : base(appExecutor, mapper)
        {
            this.tokenService = tokenService;
            this.registerService = registerService;
        }

        /// <summary>
        /// Generates Bearer token based on email and password. 
        /// Token contains account roles (if any assigned).
        /// </summary>
        /// <param name="request"><see cref="LoginRequest"/></param>
        /// <returns></returns>
        [HttpPost("api/Token")]
        [AllowAnonymous]
        public IActionResult GetToken(LoginRequest request)
        {
            try
            {
                var token = tokenService.GetToken(request.Email, request.Password);
                return Ok(token);
            }
            catch (AccountNotFoundException ex)
            {
                return Unauthorized($"Account {ex.Email} has not been found.");
            }
            catch (LoginFailedException)
            {
                return Unauthorized($"Password incorrect.");
            }
            catch (Exception)
            {
                return BadRequest("Something was wrong with the request.");
            }
        }

        /// <summary>
        /// Validates if token is valid.
        /// If everything is ok it returns 200, when token is invalid or account cannot sign in (e.g. is blocked) - returns 403.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/IsTokenValid")]
        [Authorize]
        public IActionResult IsTokenValid()
        {
            if (tokenService.IsTokenValid(User))
                return Ok();
            else
                return Unauthorized();

        }

        /// <summary>
        /// Registers new user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("api/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var newUserGuid = await registerService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);
            var command = mapper.Map<CreateAccountCommand>(request);
            command.AspNetGuid = newUserGuid;
            var newUserId = appExecutor.Dispatch(command).Message;
            var result = await registerService.SetIdInApplicationAsync(newUserGuid, int.Parse(newUserId));
            return result ? Ok() : (IActionResult)BadRequest();
        }
    }
}
