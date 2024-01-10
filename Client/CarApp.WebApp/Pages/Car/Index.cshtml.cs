using CarApp.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarApp.WebApp.Pages.Car;

public class IndexModel : PageModel
{
    private readonly CarService _carService;

    public IndexModel(CarService carService)
    {
        _carService = carService;
    }

    public List<WebApi.Models.Car> Cars = new();
    public async Task OnGetAsync()
    {
        var result  = await _carService.GetCarsAsync();
        Cars = result.ToList();
    }
}
