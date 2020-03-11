namespace Bookshelf.WebContract.Piece.Response
{
    /// <summary>
    /// Response DTO for particular book piece.
    /// </summary>
    public class BookPiecesResponse
    {
        /// <summary>
        /// Piece id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book id.
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Piece barcode.
        /// </summary>
        public int Barcode { get; set; }
        /// <summary>
        /// Piece status. <seealso cref="Model.Enum.PieceStatus"/>
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Max number of days that book can be loaned.
        /// </summary>
        public int MaxLoanDays { get; set; }
    }
}
