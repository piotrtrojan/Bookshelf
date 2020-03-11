using Bookshelf.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using Bookshelf.Utils.Extensions;

namespace Bookshelf.Utils
{
    public class BasePagedAndSortedResult<TResult>
    {
        public int ResultCount { get; set; }
        public int PagesAvailable { get; set; }
        public ICollection<TResult> Result { get; set; }

    }

    public static class BasePagedAndSortedResult
    {
        public static BasePagedAndSortedResult<TResult> GenerateFromQueryable<TResult>(IQueryable<TResult> queryable, BasePagedAndSortedQuery query)
        {
            var availables = queryable.GetTotalResults();
            var results = queryable.ApplySortingAndPaging(query).ToList();
            return new BasePagedAndSortedResult<TResult>
            {
                Result = results,
                ResultCount = results.Count,
                PagesAvailable = (int)Math.Ceiling((decimal)availables / query.Limit)
            };
        }
    }
}
