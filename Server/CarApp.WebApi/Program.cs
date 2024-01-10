using CarApp.WebApi.Extensions;
using CarApp.WebApi.Models;
using CarApp.WebApi.Repositories;
using CarApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceConfiguration(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Car controllers

app.MapGet("/cars", async ([FromServices] ICarService carService) =>
{
   var result =  await carService.GetCarsAsync();
    return Results.Ok(result);
});

app.MapGet("/cars/{id}", async ([FromServices] ICarService carService, string id) =>
{
    var result = await carService.GetCarAsync(id);
    if (result is null) return Results.NotFound();
    return Results.Ok(result);
});

app.MapPost("/cars/create", async ([FromServices] CarRepository carRepository, [FromBody] Car car) =>
{
    await carRepository.InsertAsync(car);
    return Results.Ok();
});



#endregion

#region Feature controllers

app.MapGet("/features", async ([FromServices] FeatureRepository featureRepository) =>
{
    var result = await featureRepository.GetAllAsync();
    return Results.Ok(result);

});

app.MapPost("/features/create", async ([FromServices] FeatureRepository featureRepository, [FromBody] Feature feature) =>
{
    await featureRepository.InsertAsync(feature);
    return Results.Created("", feature);
});


#endregion





app.Run();

