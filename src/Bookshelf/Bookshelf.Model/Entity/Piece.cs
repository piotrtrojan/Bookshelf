using Bookshelf.Model.Entity.Base;
using Bookshelf.Model.Enum;
using System.Collections.Generic;

namespace Bookshelf.Model.Entity
{
    public class Piece : BaseEntity
    {
        public int? Barcode { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public PieceStatus Status { get; set; }
        public int? MaxLoanDays { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
