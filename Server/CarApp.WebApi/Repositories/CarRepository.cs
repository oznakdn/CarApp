using CarApp.WebApi.Data.Context;
using CarApp.WebApi.Data.Options;
using CarApp.WebApi.Models;

namespace CarApp.WebApi.Repositories;

public class CarRepository : MongoContext<Car>
{
    public CarRepository(IMongoOptions options) : base(options)
    {
    }
}
