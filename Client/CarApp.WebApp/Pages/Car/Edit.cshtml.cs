using CarApp.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarApp.WebApp.Pages.Car;

public class EditModel : PageModel
{
    private readonly CarService _carService;
    private readonly FeatureService _featureService;

    public EditModel(CarService carService, FeatureService featureService)
    {
        _carService = carService;
        _featureService = featureService;
    }

    [BindProperty]
    public WebApi.Models.Car Car { get; set; }

    [BindProperty]
    public IFormFile[] Files { get; set; }

    public List<WebApi.Models.Feature> Features { get; set; }

    public MultiSelectList FeaturesSelectList { get; set; }



    public async Task OnGetAsync(string id)
    {
        TempData["carId"] = id;
        var response = await _featureService.GetFeauturesAsync();
        Features = response.ToList();
        Car = await _carService.GetCarAsync(id);
        FeaturesSelectList = new MultiSelectList(Features, "Id", "FeatureName", Car.Features);
    }

    public async Task<IActionResult> OnPostAsync(List<string> featureIds)
    {

        string? carId = TempData["carId"]!.ToString();
        var existCar = await _carService.GetCarAsync(carId!);

        var features = await _featureService.GetFeauturesAsync();
        Features = features.ToList();

        if (existCar.Pictures is null || existCar.Pictures.Count == 0)
        {
            foreach (var file in Files)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                Car.Pictures!.Add(file.FileName);
            }
        }
        else
        {
            Car.Pictures = existCar.Pictures;
        }

        if(featureIds.Count>0)
        {
            foreach (var id in featureIds)
            {
                if (!existCar.Features.Any(x => x.Id == id))
                {
                    existCar.Features.Add(new WebApi.Models.Feature
                    {
                        Id = id,
                        FeatureName = Features.SingleOrDefault(x => x.Id == id)!.FeatureName
                    });
                }

                Car.Features = existCar.Features;
            }
        }
       

        await _carService.UpdateCarAsync(Car);
        return RedirectToPage("/Car/Index");
    }
}
