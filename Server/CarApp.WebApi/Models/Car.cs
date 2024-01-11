using CarApp.WebApi.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarApp.WebApi.Models;

public class Car
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public Brand Brand { get; set; }
    public Color Color { get; set; }
    public int Year { get; set; }

    public List<string> Pictures { get; set; } = new();
    public List<Feature> Features { get; set; } = new();

}
