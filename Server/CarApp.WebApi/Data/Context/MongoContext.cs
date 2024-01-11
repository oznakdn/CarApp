using CarApp.WebApi.Data.Options;
using MongoDB.Driver;

namespace CarApp.WebApi.Data.Context;

public abstract class MongoContext<T> : IMongoContext<T>
    where T : class
{
    public IMongoCollection<T> Collection { get; }
    private readonly IMongoClient _client;
    public MongoContext(IMongoOptions options)
    {
        _client = new MongoClient(options.ConnectionString);
        IMongoDatabase database = _client.GetDatabase(options.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }

    public virtual async Task InsertAsync(T collection, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(collection, cancellationToken);
    }

    public virtual async Task UpdateAsync(FilterDefinition<T> filter, T collection, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(filter, collection, cancellationToken: cancellationToken);
    }

    public virtual async Task EditAsync(FilterDefinition<T> filter,UpdateDefinition<T> collection, CancellationToken cancellationToken = default)
    {
        await Collection.UpdateOneAsync(filter, collection, cancellationToken: cancellationToken);
    }

    public virtual async Task RemoveAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
        await Collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Collection.Find(x => true).ToListAsync();
    }

    public virtual async Task<T> GetAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
        return await Collection.Find<T>(filter).SingleOrDefaultAsync();
    }
}
