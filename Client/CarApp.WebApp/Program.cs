using CarApp.WebApp;
using CarApp.WebApp.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("CarApp", conf => conf.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!));
builder.Services.Configure<EndPoints>(builder.Configuration.GetSection(nameof(EndPoints)));
builder.Services.AddScoped(sp => sp.GetRequiredService<IOptions<EndPoints>>().Value);
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<FeatureService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
