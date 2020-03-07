using System;
using System.Threading.Tasks;

namespace Bookshelf.Authorization.Interfaces
{
    public interface IRegisterService
    {
        Task<Guid> RegisterAsync(string email, string password, string firstName, string lastName);
        Task<bool> SetIdInApplicationAsync(Guid aspnetGuid, int idInApplication);
    }
}
