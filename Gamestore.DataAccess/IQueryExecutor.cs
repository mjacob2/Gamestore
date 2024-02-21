using Gamestore.DataAccess.Queries;

namespace Gamestore.DataAccess;

public interface IQueryExecutor
{
    Task<TResult> ExecuteQuery<TResult>(QueryBase<TResult> query);
}
