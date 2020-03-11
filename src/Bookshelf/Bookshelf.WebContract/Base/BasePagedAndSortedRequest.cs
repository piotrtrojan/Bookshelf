namespace Bookshelf.WebContract.Base
{
    /// <summary>
    /// DTO for all requests with sorting and paging.
    /// </summary>
    public abstract class BasePagedAndSortedRequest
    {
        /// <summary>
        /// Response field to order by.
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// Order type - Ascending or Descending
        /// </summary>
        public string Order { get; set; } // todo: Consider OrderEnum.
        /// <summary>
        /// Maximum elements to return.
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// Page to return. E.g. When querying 3rd page with limit 10, response contains records 21-30.
        /// </summary>
        public int Page { get; set; }
    }
}