namespace Bookshelf.Validator.Shared.Interfaces
{
    public interface IAuthorValidator
    {
        bool AuthorExists(int authorId);
    }
}
