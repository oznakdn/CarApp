using CarApp.WebApi.Models;

namespace CarApp.WebApi.Services.Interfaces;

public interface ICarService
{
    Task UpdateCarAsync(Car car);
    Task RemoveCarAsync(string id);
    Task<IEnumerable<Car>> GetCarsAsync();
    Task<Car>GetCarAsync(string id);

}
