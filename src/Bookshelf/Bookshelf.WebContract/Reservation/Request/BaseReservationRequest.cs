namespace Bookshelf.WebContract.Reservation.Request
{
    /// <summary>
    /// General DTO for reservation. Contains common fields for all reservation requests.
    /// </summary>
    public abstract class BaseReservationRequest
    {
        public int PieceId { get; set; }
    }
}
