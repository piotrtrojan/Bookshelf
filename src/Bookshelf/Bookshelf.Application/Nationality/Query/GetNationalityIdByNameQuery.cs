using Bookshelf.Contract.Base;

namespace Bookshelf.Application.Nationality.Query
{
    public class GetNationalityIdByNameQuery : IQuery<int?>
    {
        public string Name { get; set; }
    }
}
