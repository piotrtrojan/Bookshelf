using Bookshelf.Validator.Shared;
using Bookshelf.Validator.Shared.Interfaces;
using Bookshelf.WebContract.Reservation.Request;
using FluentValidation;

namespace Bookshelf.Validator.Reservation
{
    public class BaseReservationRequestValidator<T> : AbstractValidator<T> where T : BaseReservationRequest
    {
        public BaseReservationRequestValidator(IPieceValidator pieceValidator)
        {
            RuleFor(q => q.PieceId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(q => pieceValidator.PieceExists(q))
                .WithMessage(SharedValidationMessages.PieceDoesNotExist)
                .Must(q => pieceValidator.PieceMustBeAvailable(q))
                .WithMessage(SharedValidationMessages.PieceNotAvailable);
        }
    }
}
