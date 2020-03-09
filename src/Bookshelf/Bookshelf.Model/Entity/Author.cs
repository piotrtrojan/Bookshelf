using Bookshelf.Model.Entity.Base;
using System.Collections.Generic;

namespace Bookshelf.Model.Entity
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nationality Nationality { get; set; }
        public int NationalityId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
