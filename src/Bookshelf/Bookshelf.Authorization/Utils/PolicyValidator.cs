using Bookshelf.Authorization.Attribute;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Linq;

namespace Bookshelf.Authorization.Utils
{
    public static class PolicyValidator
    {
        private static readonly string[] IgnoredRoutes = new string[]
        {
            "api/Token",
            "api/IsTokenValid",
            "api/Register", // TODO: Update it. When endpoint has AllowAnonymous attribute, it can be skipped.
        };

        public static void ValidateEndpointsPolicies(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            var routes = actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                ad => ad.AttributeRouteInfo != null && !IgnoredRoutes.Contains(ad.AttributeRouteInfo.Template)).ToList();
            foreach (ControllerActionDescriptor route in routes)
            {
                var method = route.ControllerTypeInfo.DeclaredMethods.First(q => q.Name == route.ActionName);
                var attributes = method
                    .CustomAttributes
                    .Where(q => q.AttributeType == typeof(RoleAuthorizeAttribute)).ToList();
                if (!attributes.Any())
                {
                    throw new InvalidOperationException($"Endpoint {route.AttributeRouteInfo.Template} has no policies definied.");
                }
            }
        }
    }
}
