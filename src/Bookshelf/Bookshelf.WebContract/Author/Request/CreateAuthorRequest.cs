using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.WebContract.Author.Request
{
    public class CreateAuthorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
    }
}
