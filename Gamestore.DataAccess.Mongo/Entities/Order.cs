﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamestore.DataAccess.Mongo.Entities;
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("OrderID")]
    public int OrderId { get; set; }

    [BsonElement("CustomerID")]
    public string CustomerId { get; set; }

    [BsonElement("EmployeeID")]
    public int EmployeeId { get; set; }

    [BsonElement("OrderDate")]
    public DateTime OrderDate { get; set; }

    [BsonElement("RequiredDate")]
    public DateTime RequiredDate { get; set; }

    [BsonElement("ShippedDate")]
    public DateTime ShippedDate { get; set; }

    [BsonElement("ShipVia")]
    public int ShipVia { get; set; }

    [BsonElement("Freight")]
    public double Freight { get; set; }

    [BsonElement("ShipName")]
    public string ShipName { get; set; }

    [BsonElement("ShipAddress")]
    public string ShipAddress { get; set; }

    [BsonElement("ShipCity")]
    public string ShipCity { get; set; }

    [BsonElement("ShipRegion")]
    public string ShipRegion { get; set; }

    [BsonElement("ShipPostalCode")]
    [BsonSerializer(typeof(CustomInt32AsStringSerializer))]
    public string ShipPostalCode { get; set; }

    [BsonElement("ShipCountry")]
    public string ShipCountry { get; set; }
}
