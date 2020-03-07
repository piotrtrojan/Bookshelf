using Bookshelf.Model.Entity.Base;

namespace Bookshelf.Model.Entity
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
