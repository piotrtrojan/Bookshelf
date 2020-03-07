using Bookshelf.Model.Entity.Base;
using System;

namespace Bookshelf.Model.Entity
{
    public class User : BaseEntity
    {
        public Guid AspNetGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardId { get; set; }

    }
}
