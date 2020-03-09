using Bookshelf.Contract.Base;

namespace Bookshelf.Application.Author.Command
{
    public class CreateAuthorCommand : ICommand
    {
        public int CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
    }
}
