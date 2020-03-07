using Bookshelf.Model.Entity.Base;

namespace Bookshelf.Model.Entity
{
    public class Book : BaseEntity
    {
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
    }
}
