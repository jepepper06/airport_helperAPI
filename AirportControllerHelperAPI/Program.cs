using AirpotControllerHelperAPI.Model;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/control-tower", () =>
{
    var controlTower = new ControlTower();
    var runway = new AirportRunway()
    {
        Id = 1
    };
    var airplane = new Airplane() { 
        
    };
    controlTower.AirportRunways.Add(runway);
    controlTower.AddAirplaneToAirportRunway(runway, airplane, DateTime.Now);
    return Results.Ok(controlTower);
}).WithOpenApi();
app.MapPost("/control-tower", ([FromBody] ControlTower controlTower) =>
{
    var newControlTower = controlTower;
    return Results.Created("/control-tower", newControlTower);
}).WithOpenApi();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
