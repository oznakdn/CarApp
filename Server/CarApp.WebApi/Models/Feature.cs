using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CarApp.WebApi.Models;

public class Feature
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FeatureName { get; set; }

}
