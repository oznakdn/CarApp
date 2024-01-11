using CarApp.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace CarApp.WebApp.Pages.Car;

public class RemoveModel : PageModel
{

    private readonly CarService _carService;
    public RemoveModel(CarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var car = await _carService.GetCarAsync(id);
        if(car.Pictures.Count > 0)
        {
            foreach (var picture in car.Pictures)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", picture);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
        }
        

        await _carService.DeleteCarAsync(id);
        return RedirectToPage("/Car/Index");
    }
}
