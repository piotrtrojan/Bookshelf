using Bookshelf.Contract.Base;
using System;

namespace Bookshelf.Application.User.Command
{
    public class CreateAccountCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid AspNetGuid { get; set; }
    }
}
