namespace Gamestore.DataAccess.Mongo.Queries;
public abstract class MongoQueryBase<TResult>
{
    public abstract Task<TResult> ExecuteMongo(MongoDbContext mongoDatabase);
}
