using Gamestore.DataAccess.Mongo.Entities;
using MongoDB.Driver;

namespace Gamestore.DataAccess.Mongo.Queries.Shippers;
public class GetShipperByIdMongoQuery : MongoQueryBase<Shipper>
{
    public required string ShipperId { get; set; }

    public override async Task<Shipper> ExecuteMongo(MongoDbContext mongoDatabase)
    {
        var filter = Builders<Shipper>.Filter.Eq(s => s.Id, ShipperId);
        return await mongoDatabase.Shippers.Find(filter).SingleOrDefaultAsync();
    }
}
