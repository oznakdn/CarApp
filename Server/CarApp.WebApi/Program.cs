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


// Car api
var carGroup = app.MapGroup("/cars");
carGroup.MapGet("/", async ([FromServices] ICarService carService) =>
{
    var result = await carService.GetCarsAsync();
    return Results.Ok(result);
});
carGroup.MapGet("/{id}", async ([FromServices] ICarService carService, string id) =>
{
    var result = await carService.GetCarAsync(id);
    if (result is null) return Results.NotFound();
    return Results.Ok(result);
});

carGroup.MapPost("/create", async ([FromServices] CarRepository carRepository, [FromBody] Car car) =>
{
    await carRepository.InsertAsync(car);
    return Results.Ok();
});

carGroup.MapPut("/update", async ([FromServices] ICarService carService, [FromBody] Car car) =>
{
    await carService.UpdateCarAsync(car);
    return Results.NoContent();
});

carGroup.MapDelete("/{id}", async ([FromServices] ICarService carService, string id) =>
{
    await carService.RemoveCarAsync(id);
    return Results.NoContent();
});

// Feature api
var featureGroup = app.MapGroup("/features");
featureGroup.MapGet("/", async ([FromServices] FeatureRepository featureRepository) =>
{
    var result = await featureRepository.GetAllAsync();
    return Results.Ok(result);
});

featureGroup.MapPost("/create", async ([FromServices] FeatureRepository featureRepository, [FromBody] Feature feature) =>
{
    await featureRepository.InsertAsync(feature);
    return Results.Created("", feature);
});


app.Run();

