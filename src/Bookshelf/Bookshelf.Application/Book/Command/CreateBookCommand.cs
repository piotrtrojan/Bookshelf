using Bookshelf.Contract.Base;
using System.Collections.Generic;

namespace Bookshelf.Application.Book.Command
{
    public class CreateBookCommand : ICommand
    {
        public int CreatedBy { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int? MaxLoanDays { get; set; }
        public ICollection<string> BookTags { get; set; }
    }
}
