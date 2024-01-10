using CarApp.WebApi.Data.Options;
using CarApp.WebApi.Repositories;
using CarApp.WebApi.Services;
using CarApp.WebApi.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CarApp.WebApi.Extensions;

public static class ServiceConfigurationExtension
{
    public static  void AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoOptions>(configuration.GetSection(nameof(MongoOptions)));
        services.AddScoped<IMongoOptions>(sp => sp.GetRequiredService<IOptions<MongoOptions>>().Value);
        services.AddScoped<CarRepository>();
        services.AddScoped<FeatureRepository>();
        services.AddScoped<ICarService, CarService>();
    }
}
