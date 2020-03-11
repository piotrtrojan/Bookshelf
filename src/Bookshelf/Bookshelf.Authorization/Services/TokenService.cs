using Bookshelf.Authorization.Exceptions;
using Bookshelf.Authorization.Identity;
using Bookshelf.Authorization.Interfaces;
using Bookshelf.Utils.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Bookshelf.Authorization.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<BookshelfIdentityUser> userManager;
        private readonly SignInManager<BookshelfIdentityUser> signInManager;
        private readonly GlobalConfig globalConfig;

        public TokenService(
            UserManager<BookshelfIdentityUser> userManager,
            SignInManager<BookshelfIdentityUser> signInManager,
            GlobalConfig globalConfig)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.globalConfig = globalConfig;
        }

        public object GetToken(string email, string password)
        {
            var aspnetUser = signInManager.UserManager.FindByEmailAsync(email).Result;
            if (aspnetUser == null)
                throw new AccountNotFoundException(email);

            var result = signInManager.CheckPasswordSignInAsync(aspnetUser, password, false).Result;
            if (!result.Succeeded)
                throw new LoginFailedException(email);

            return GenerateJwtToken(aspnetUser);
        }

        public bool IsTokenValid(ClaimsPrincipal principal)
        {
            var principalGuid = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var identityUser = signInManager.UserManager.FindByIdAsync(principalGuid).Result;
            return signInManager.CanSignInAsync(identityUser).Result;
        }

        protected object GenerateJwtToken(BookshelfIdentityUser identityUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, identityUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.IdInApplication.ToString())
            };

            var roles = userManager.GetRolesAsync(identityUser).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(globalConfig.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(globalConfig.JwtExpireDays));

            var token = new JwtSecurityToken(
                globalConfig.JwtIssuer,
                globalConfig.JwtAudience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
