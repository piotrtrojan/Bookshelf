using Bookshelf.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.WebContract.Base
{
    public abstract class BasePagedAndSortedResult<TResult> : IPagedResult<TResult>
    {
        public int ResultCount { get; set; }
        public int PagesAvailable { get; set; }
        public ICollection<TResult> Result { get; set; }
    }
}
