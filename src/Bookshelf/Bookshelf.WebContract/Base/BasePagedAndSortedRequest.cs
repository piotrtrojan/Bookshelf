namespace Bookshelf.WebContract.Base
{
    public abstract class BasePagedAndSortedRequest
    {
        public string OrderBy { get; set; }
        public string Order { get; set; } // todo: Consider OrderEnum.
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}