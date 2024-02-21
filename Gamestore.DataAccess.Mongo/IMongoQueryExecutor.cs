using Gamestore.DataAccess.Mongo.Queries;

namespace Gamestore.DataAccess.Mongo;
public interface IMongoQueryExecutor
{
    Task<TResult> ExecuteQuery<TResult>(MongoQueryBase<TResult> query);
}
