using Bookshelf.Authorization.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Authorization
{
    public static class RegisterDependencies
    {
        public static void RegisterAuthorizationServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
