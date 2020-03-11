using Bookshelf.Validator.Shared;
using Bookshelf.Validator.Shared.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Validator
{
    public static class RegisterDependencies
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            RegisterSharedServices(services);
            services.AddMvc().AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.RegisterValidatorsFromAssemblyContaining<NationalityValidator>(); //TODO: Consider better approach. Maybe move to Validator project?
            });
        }

        private static void RegisterSharedServices(IServiceCollection services)
        {
            services.AddTransient<INationalityValidator, NationalityValidator>();
            services.AddTransient<IAuthorValidator, AuthorValidator>();
        }
    }
}
