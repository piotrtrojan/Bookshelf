using Bookshelf.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

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
