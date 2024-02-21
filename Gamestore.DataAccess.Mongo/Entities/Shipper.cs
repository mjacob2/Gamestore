using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamestore.DataAccess.Mongo.Entities;
public class Shipper
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("ShipperID")]
    public int ShipperId { get; set; }

    [BsonElement("CompanyName")]
    public string CompanyName { get; set; }

    [BsonElement("Phone")]
    public string Phone { get; set; }
}
