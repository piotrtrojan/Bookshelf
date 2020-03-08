using Bookshelf.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Model.Entity
{
    public class Reservation : BaseEntity
    {
        public Piece Piece { get; set; }
        public User User { get; set; }
        public int PieceId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReservationTimestamp { get; set; }
    }
}
