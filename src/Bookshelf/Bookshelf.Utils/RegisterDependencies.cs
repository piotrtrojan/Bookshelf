using Bookshelf.Utils.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Utils
{
    public static class RegisterDependencies
    {

        /// <summary>
        /// Registers Singletons: 
        // <see cref="GlobalConfig">GlobalConfig</see>, 
        // <see cref="ValidatorConfig">ValidatorConfig<see>, 
        // <see cref="LibraryConfig">LibraryConfig</see>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void RegisterGlobalConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(new GlobalConfig(config));
            services.AddSingleton(new ValidatorConfig(config));
            services.AddSingleton(new LibraryConfig(config));
        }
    }
}
