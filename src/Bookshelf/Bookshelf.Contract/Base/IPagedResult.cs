using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Contract.Base
{
    public interface IPagedResult<TResult>
    {
        public int ResultCount { get; set; }
        public int PagesAvailable { get; set; }
        public ICollection<TResult> Result { get; set; }
    }
}
