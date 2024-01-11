using CarApp.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarApp.WebApp.Pages.Car;

public class InsertModel : PageModel
{
    private readonly CarService _carService;
    private readonly FeatureService _featureService;

    public InsertModel(CarService carService, FeatureService featureService)
    {
        _carService = carService;
        _featureService = featureService;
    }

    [BindProperty]
    public WebApi.Models.Car Car { get; set; }

    [BindProperty]
    public IFormFile[] Files { get; set; }

    public SelectList SelectFeaturesList { get; set; }

    public List<WebApi.Models.Feature> Features { get; set; } = new();

    
    
    public async Task OnGetAsync()
    {
        var features = await _featureService.GetFeauturesAsync();
        Features = features.ToList();
        SelectFeaturesList = new SelectList(features, "Id", "FeatureName");
    }

    public async Task<IActionResult> OnPostAsync(List<string> featureIds)
    {
        var features = await _featureService.GetFeauturesAsync();
        Features = features.ToList();

        foreach (var file in Files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            Car.Pictures.Add(file.FileName);
            await file.CopyToAsync(stream);
        }

        foreach (var id in featureIds)
        {
            
            Car.Features.Add(new WebApi.Models.Feature
            {
                Id = id,
                FeatureName = Features.SingleOrDefault(x => x.Id == id)!.FeatureName
            });
        }

        await _carService.InsertCarAsync(Car);
        return RedirectToPage("/Car/Index");
    }
}
