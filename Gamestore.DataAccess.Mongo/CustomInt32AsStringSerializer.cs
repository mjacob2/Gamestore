using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Gamestore.DataAccess.Mongo;
public class CustomInt32AsStringSerializer : SerializerBase<string>
{
    public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var type = context.Reader.GetCurrentBsonType();

        switch (type)
        {
            case BsonType.String:
                return context.Reader.ReadString();

            case BsonType.Int32:
                return context.Reader.ReadInt32().ToString();

            default:
                var msg = $"Can't deserialize BsonString or BsonInt32 from BsonType {type}";
                throw new BsonSerializationException(msg);
        }
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
    {
        context.Writer.WriteString(value);
    }
}
