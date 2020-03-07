using Bookshelf.Repository.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Repository
{
    public static class RegisterDependencies
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<AuthDbContext>()
               // TODO: Verify why this registration throws error?? It was not a problem in Lege Artis????
               // .AddDbContext<BookshelfDbContext>()
               ;
        }
    }
}
