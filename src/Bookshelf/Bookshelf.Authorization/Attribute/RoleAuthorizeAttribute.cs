using Bookshelf.Authorization.Enum;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Bookshelf.Authorization.Attribute
{
    public sealed class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(RoleType role) : this(new[] { role })
        {

        }


        public RoleAuthorizeAttribute(RoleType[] roles)
        {
            Roles = string.Join(",", roles.Select(q => System.Enum.GetName(typeof(RoleType), q)));
        }
    }
}
