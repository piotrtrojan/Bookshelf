namespace Bookshelf.Contract.Base
{
    public interface IQueryHandler<TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
