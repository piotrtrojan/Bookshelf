using Bookshelf.WebContract.Piece.Request;
using FluentValidation;

namespace Bookshelf.Validator.Piece
{
    public class CreatePieceRequestValidator : AbstractValidator<CreatePieceRequest>
    {
        public CreatePieceRequestValidator()
        {
            RuleFor(q => q.Barcode)
                .NotEmpty()
                .GreaterThan(0)
                .Must(q => IsBarcodeFree(q))
                .WithErrorCode(PieceErrorMessages.BarcodeInUse);
        }

        private bool IsBarcodeFree(int barcode)
        {
            return true;
        }
    }
}
