using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamestore.DataAccess.Mongo.Entities;
public class OrderDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("OrderID")]
    public int OrderId { get; set; }

    [BsonElement("ProductID")]
    public int ProductId { get; set; }

    [BsonElement("UnitPrice")]
    public decimal UnitPrice { get; set; }

    [BsonElement("Quantity")]
    public int Quantity { get; set; }

    [BsonElement("Discount")]
    public double Discount { get; set; }
}
