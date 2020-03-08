using Bookshelf.Model.Entity.Base;
using System.Collections.Generic;

namespace Bookshelf.Model.Entity
{
    public class Book : BaseEntity
    {
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int? MaxLoanDays { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}
