using Bookshelf.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Repository.Context
{
    public class BookshelfDbContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        public BookshelfDbContext(string connectionString)
        {
            this.connectionString = connectionString;
            this.Database.EnsureCreated(); // TODO: Just for the first time, later we should use SQL project.
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString, o => o.CommandTimeout(180));
        }
    }
}
