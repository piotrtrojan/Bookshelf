using Bookshelf.Application.Piece.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Model.Enum;
using Bookshelf.Validator.Shared.Interfaces;

namespace Bookshelf.Validator.Shared
{
    internal class PieceValidator : IPieceValidator
    {
        private readonly IQueryHandler<GetPieceStatusByIdQuery, PieceStatus> getPieceStatusByIdQueryHandler;
        private readonly IQueryHandler<DoesPieceExistQuery, bool> doesPieceExistQueryHandler;

        public PieceValidator(
            IQueryHandler<GetPieceStatusByIdQuery, PieceStatus> getPieceStatusByIdQueryHandler,
            IQueryHandler<DoesPieceExistQuery, bool> doesPieceExistQueryHandler)
        {
            this.getPieceStatusByIdQueryHandler = getPieceStatusByIdQueryHandler;
            this.doesPieceExistQueryHandler = doesPieceExistQueryHandler;
        }

        public bool PieceExists(int pieceId)
        {
            return doesPieceExistQueryHandler.Handle(new DoesPieceExistQuery { PieceId = pieceId });
        }

        public bool PieceMustBeAvailable(int pieceId)
        {
            var pieceStatus = getPieceStatusByIdQueryHandler.Handle(new GetPieceStatusByIdQuery { PieceId = pieceId });
            return pieceStatus == PieceStatus.Available;
        }

        public bool PieceMustBeAvailableOnlyOnSite(int pieceId)
        {
            var pieceStatus = getPieceStatusByIdQueryHandler.Handle(new GetPieceStatusByIdQuery { PieceId = pieceId });
            return pieceStatus == PieceStatus.AvailableOnlyOnSite;
        }
    }
}
