using CarApp.WebApp.Services.Abstracts;

namespace CarApp.WebApp.Services;

public class CarService : ClientServiceBase
{
    public CarService(EndPoints EndPoints, IHttpClientFactory httpClientFactory) : base(EndPoints, httpClientFactory)
    {
    }

    public async Task<IEnumerable<WebApi.Models.Car>> GetCarsAsync()
    {
        string? url = EndPoints.Car.GetCar;
        HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<WebApi.Models.Car>>();
        return response;
    }

    public async Task<WebApi.Models.Car> GetCarAsync(string id)
    {
        string? url = $"{EndPoints.Car.GetCar}/{id}";
        HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
        var response = await responseMessage.Content.ReadFromJsonAsync<WebApi.Models.Car>();
        return response;
    }

    public async Task InsertCarAsync(WebApi.Models.Car car)
    {
        string? url = EndPoints.Car.CreateCar;
        await HttpClient.PostAsJsonAsync<WebApi.Models.Car>(url, car);
    }
}
