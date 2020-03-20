using Bookshelf.Validator.Shared.Interfaces;
using Bookshelf.WebContract.Reservation.Request;

namespace Bookshelf.Validator.Reservation
{
    public class MakeOrderRequestValidator : BaseReservationRequestValidator<MakeOrderRequest>
    {
        public MakeOrderRequestValidator(IPieceValidator pieceValidator) : base(pieceValidator)
        {
        }
    }
}
