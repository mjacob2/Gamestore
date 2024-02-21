using Gamestore.DataAccess.Exceptions;
using Gamestore.DataAccess.Queries;

namespace Gamestore.DataAccess;

public class QueryExecutor : IQueryExecutor
{
    private readonly GamestoreDbContext _context;

    public QueryExecutor(GamestoreDbContext context)
    {
        _context = context;
    }

    public async Task<TResult> ExecuteQuery<TResult>(QueryBase<TResult> query)
    {
        var result = await query.Execute(_context);

        return result == null ? throw new NotFoundException() : result;
    }
}
