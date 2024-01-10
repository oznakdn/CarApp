using MongoDB.Driver;

namespace CarApp.WebApi.Data.Context;

public interface IMongoContext<T> where T : class
{
    IMongoCollection<T> Collection { get; }
}
