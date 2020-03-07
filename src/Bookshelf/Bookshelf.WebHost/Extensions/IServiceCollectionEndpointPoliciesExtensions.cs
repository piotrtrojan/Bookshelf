using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.WebHost.Extensions
{
    /// <summary>
    /// Contains extensions of <see cref="IServiceCollection">IServiceCollection</see> to add Authorization and to register
    /// Authorization Polices based on roles.
    /// </summary>
    public static class IServiceCollectionEndpointPoliciesExtensions
    {
        /// <summary>
        /// Registers Authorization.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterAuthorizationPolicies(this IServiceCollection services)
        {

            services.AddAuthorization();
        }
    }
}
