using Bookshelf.Contract.Enum;

namespace Bookshelf.Contract
{
    public abstract class BasePagedAndSortedQuery 
    {
        public string OrderBy { get; set; }
        public OrderEnum Order { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}