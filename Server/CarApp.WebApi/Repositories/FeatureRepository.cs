using CarApp.WebApi.Data.Context;
using CarApp.WebApi.Data.Options;
using CarApp.WebApi.Models;

namespace CarApp.WebApi.Repositories;

public class FeatureRepository : MongoContext<Feature>
{
    public FeatureRepository(IMongoOptions options) : base(options)
    {
    }
}
