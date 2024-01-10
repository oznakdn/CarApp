using CarApp.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarApp.WebApp.Pages.Car;

public class DetailsModel : PageModel
{
    private readonly CarService _carService;

    public DetailsModel(CarService carService)
    {
        _carService = carService;
    }

    public WebApi.Models.Car Car { get; set; }

    public async Task OnGetAsync(string id)
    {
        Car = await _carService.GetCarAsync(id);
    }
}
