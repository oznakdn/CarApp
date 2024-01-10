namespace CarApp.WebApi.Data.Options;

public interface IMongoOptions
{
    string? ConnectionString { get; set; }
    string? DatabaseName { get; set; }
}
