using Gamestore.DataAccess.Mongo.Queries;

namespace Gamestore.DataAccess.Mongo;
public class MongoQueryExecutor : IMongoQueryExecutor
{
    private readonly MongoDbContext _database;

    public MongoQueryExecutor(MongoDbContext database)
    {
        _database = database;
    }

    public async Task<TResult> ExecuteQuery<TResult>(MongoQueryBase<TResult> query)
    {
        return await query.ExecuteMongo(_database);
    }
}
