using Bookshelf.Utils.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Utils
{
    public static class RegisterDependencies
    {
        
        /// <summary>
        /// Registers Singleton <see cref="GlobalConfig"/>GlobalConfig.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void RegisterGlobalConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(new GlobalConfig(config));
        }
    }
}
