using Gamestore.DataAccess.Mongo.Entities;
using MongoDB.Driver;

namespace Gamestore.DataAccess.Mongo.Queries.Orders;
public class GetAllOrdersQuery : MongoQueryBase<List<Order>>
{
    public required string CustomerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public override async Task<List<Order>> ExecuteMongo(MongoDbContext mongoDatabase)
    {
        var filter = Builders<Order>.Filter.Empty;

        if (StartDate.HasValue)
        {
            filter &= Builders<Order>.Filter.Gte(x => x.OrderDate, StartDate.Value);
        }

        if (EndDate.HasValue)
        {
            filter &= Builders<Order>.Filter.Lte(x => x.OrderDate, EndDate.Value);
        }

        var orders = await mongoDatabase.Orders.Find(filter).ToListAsync();
        return orders.OrderByDescending(x => x.Id).ToList();
    }
}
