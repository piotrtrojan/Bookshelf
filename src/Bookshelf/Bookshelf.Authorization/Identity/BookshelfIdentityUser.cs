using Microsoft.AspNetCore.Identity;
using System;

namespace Bookshelf.Authorization.Identity
{
    public class BookshelfIdentityUser : IdentityUser<Guid>
    {
        public int IdInApplication { get; set; }
    }
}
