using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Validator
{
    public static class RegisterDependencies
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                // fv.RegisterValidatorsFromAssemblyContaining<>(); //TODO: Consider better approach. Maybe move to Validator project?
            });
        }
    }
}
