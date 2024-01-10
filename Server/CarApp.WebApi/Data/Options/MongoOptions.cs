namespace CarApp.WebApi.Data.Options;

public class MongoOptions : IMongoOptions
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
