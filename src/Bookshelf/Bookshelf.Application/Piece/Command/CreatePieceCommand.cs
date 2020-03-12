using Bookshelf.Contract.Base;
using Bookshelf.Model.Enum;

namespace Bookshelf.Application.Piece.Command
{
    public class CreatePieceCommand : ICommand
    {
        public int BookId { get; set; }
        public int Barcode { get; set; }
        public int? MaxLoanDays { get; set; }
        public PieceStatus Status { get; set; }
    }
}
