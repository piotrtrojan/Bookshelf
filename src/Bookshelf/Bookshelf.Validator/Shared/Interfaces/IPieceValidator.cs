namespace Bookshelf.Validator.Shared.Interfaces
{
    public interface IPieceValidator
    {
        bool PieceMustBeAvailable(int pieceId);
        bool PieceMustBeAvailableOnlyOnSite(int pieceId);
        bool PieceExists(int q);
    }
}
