using Bookshelf.Contract.Base;

namespace Bookshelf.Application.BookTag.Query
{
    public class GetBookTagIdByNameQuery : IQuery<int?>
    {
        public string Name { get; set; }
    }
}
