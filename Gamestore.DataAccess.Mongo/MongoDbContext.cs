using Gamestore.DataAccess.Mongo.Entities;
using MongoDB.Driver;

namespace Gamestore.DataAccess.Mongo;
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        _database = client.GetDatabase("Northwind");
    }

    public IMongoCollection<Shipper> Shippers => _database.GetCollection<Shipper>("shippers");

    public IMongoCollection<Order> Orders => _database.GetCollection<Order>("orders");

    public IMongoCollection<OrderDetail> OrderDetails => _database.GetCollection<OrderDetail>("order-details");

    public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");

    public IMongoCollection<Category> Categories => _database.GetCollection<Category>("categories");

    public IMongoCollection<Supplier> Suppliers => _database.GetCollection<Supplier>("suppliers");
}
