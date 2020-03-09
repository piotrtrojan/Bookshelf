using Bookshelf.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Repository.Context
{
    public class BookshelfDbContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public BookshelfDbContext(string connectionString)
        {
            this.connectionString = connectionString;
            this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString, o => o.CommandTimeout(180));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookTag>(eb =>
            {
                eb.HasIndex(q => q.Tag);
            });
        }
    }
}
