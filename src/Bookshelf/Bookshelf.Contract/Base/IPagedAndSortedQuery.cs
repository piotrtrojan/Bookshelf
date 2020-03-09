namespace Bookshelf.Contract.Base
{
    public interface IPagedAndSortedQuery<TResult> 
        : IQuery<IPagedResult<TResult>> 
    {
        public string OrderBy { get; set; }
        public string Order { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
