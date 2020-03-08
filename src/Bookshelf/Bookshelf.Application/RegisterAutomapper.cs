using AutoMapper;
using Bookshelf.Application.User.Command;
using Bookshelf.WebContract.Auth.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Application
{
    public static class RegisterAutoMapper
    {
        public static void RegisterApplicationAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(new[] { typeof(ApplicationAutomapperProfile) });
        }
    }

    public class ApplicationAutomapperProfile : Profile
    {
        public ApplicationAutomapperProfile()
        {
            RegisterAuth();
        }

        private void RegisterAuth()
        {
            CreateMap<RegisterRequest, CreateAccountCommand>();
        }
    }
}
