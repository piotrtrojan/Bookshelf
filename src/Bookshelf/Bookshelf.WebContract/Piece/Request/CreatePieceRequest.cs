using System.Collections.Generic;

namespace Bookshelf.WebContract.Piece.Request
{
    /// <summary>
    /// DTO for creating new piece.
    /// </summary>
    public class CreatePieceRequest
    {
        /// <summary>
        /// New piece's book id.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// New piece's barcode.
        /// </summary>
        public int Barcode { get; set; }

        /// <summary>
        /// Piece status. <seealso cref="Model.Enum.PieceStatus"/>
        /// </summary>
        public int Status { get; set; }

        public int? MaxLoanDays { get; set; }
    }
}
