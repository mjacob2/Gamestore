namespace Gamestore.DataAccess.Queries;

public abstract class QueryBase<TResult>
{
    public abstract Task<TResult> Execute(GamestoreDbContext context);
}
