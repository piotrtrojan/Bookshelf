namespace Bookshelf.Model.Enum
{
    public enum PieceStatus
    {
        Ordered = 0, // Piece ordered in Bookshop, not arrived yet.
        Arrived = 1, // Piece arrived from Bookshop, ready to generate barcode.
        Booked = 10, // Piece ordered, waiting for pickup.
        Loaned = 11, // Piece loaned by user, unable to book or reserve.
        LoanedReservationPossible = 12, // Piece loaned by user, can be reserved for next loan by someone else.
        LoanedOnSiteReading = 13, // Piece loaned by user, but only for on site reading.
        Available = 20, // Piece available in library, ready for booking.
        AvailableOnlyOnSite = 21, // Piece available in library, unable to book, only on site reading.
        Destroyed = 90, // Piece was destroyed or broken, unable to order.
        OutOfDate = 91, // Piece is no longer up-to-date, unable to order.
        Lost = 92, // Piece has been lost by user, unable to order.
        Unknown = 99, // Piece status unknown.


    }
}
