using Bookshelf.Contract.Base;

namespace Bookshelf.Application.Author.Query
{
    public class DoesAuthorExistQuery : IQuery<bool>
    {
        public int AuthorId { get; set; }
    }
}
