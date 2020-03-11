using Bookshelf.Authorization.Identity;
using Bookshelf.Utils.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bookshelf.Repository.Context
{
    public class AuthDbContext : IdentityDbContext<BookshelfIdentityUser, IdentityRole<Guid>, Guid>
    {
        private readonly GlobalConfig _config;

        public AuthDbContext(GlobalConfig config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.IdentityConnectionString, o => o.CommandTimeout(180));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
    }
}
