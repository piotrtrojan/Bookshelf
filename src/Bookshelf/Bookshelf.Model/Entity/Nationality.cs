using Bookshelf.Model.Entity.Base;
using System.Collections.Generic;

namespace Bookshelf.Model.Entity
{
    public class Nationality : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
