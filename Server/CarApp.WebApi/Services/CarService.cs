using CarApp.WebApi.Models;
using CarApp.WebApi.Repositories;
using CarApp.WebApi.Services.Interfaces;
using MongoDB.Driver;

namespace CarApp.WebApi.Services;

public class CarService : ICarService
{
    private readonly CarRepository _carRepository;

    public CarService(CarRepository carRepository)
    {
        _carRepository = carRepository;
    }

 
    public async Task<Car> GetCarAsync(string id)
    {
        var filter = new FilterDefinitionBuilder<Car>().Eq(x => x.Id, id);
        return await _carRepository.GetAsync(filter);
    }

    public async Task<IEnumerable<Car>> GetCarsAsync() => await _carRepository.GetAllAsync(default);


    public async Task RemoveCarAsync(string id)
    {
        var filter = new FilterDefinitionBuilder<Car>().Eq(x => x.Id, id);
        await _carRepository.RemoveAsync(filter,default);
    }

    public async Task UpdateCarAsync(Car car)
    {
        var filter = new FilterDefinitionBuilder<Car>().Eq(x => x.Id, car.Id);
        await _carRepository.UpdateAsync(filter, car, default);
    }
}
