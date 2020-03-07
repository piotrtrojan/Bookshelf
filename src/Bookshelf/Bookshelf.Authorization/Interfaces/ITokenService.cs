using System.Security.Claims;

namespace Bookshelf.Authorization.Interfaces
{
    public interface ITokenService
    {
        object GetToken(string email, string password);
        bool IsTokenValid(ClaimsPrincipal principal);
    }
}
