using Gamestore.DataAccess.Mongo.Entities;
using MongoDB.Driver;

namespace Gamestore.DataAccess.Mongo.Queries.Shippers;
public class GetAllShippersFromMongoQuery : MongoQueryBase<List<Shipper>>
{
    public override async Task<List<Shipper>> ExecuteMongo(MongoDbContext mongoDatabase)
    {
        return await mongoDatabase.Shippers.Find(_ => true).ToListAsync();
    }
}
