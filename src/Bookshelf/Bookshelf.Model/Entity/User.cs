using Bookshelf.Model.Entity.Base;
using System;
using System.Collections.Generic;

namespace Bookshelf.Model.Entity
{
    public class User : BaseEntity
    {
        public Guid AspNetGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CardId { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}
