using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamestore.DataAccess.Mongo.Entities;
public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public int CategoryID { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    [BsonRepresentation(BsonType.Binary)]
    public byte[] Picture { get; set; }
}
