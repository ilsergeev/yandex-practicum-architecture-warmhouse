using SmartHouse.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/temperature", (string? location) => 
{
    var temperature = Math.Round(Random.Shared.NextDouble() * 30 - 20, 1);
    string? sensorId = null;
    if (!string.IsNullOrEmpty(location))
    {
        sensorId = location switch
        {
            "Living Room" => "1",
            "Bedroom" => "2",
            "Kitchen" => "3",
            _ => "0"
        };
    }

    return Results.Ok(new TemperatureData
    {
        Value = temperature,
        Location = !string.IsNullOrWhiteSpace(location) ? location : "unknown",
        SensorId = !string.IsNullOrWhiteSpace(sensorId) ? sensorId : "unknown",
        Description = $"Temperature form {location} for sensor with ID:'{sensorId}'"
    });
});

app.MapGet("/temperature/{sensorId}", (string sensorId) =>
{
    var temperature = Math.Round(Random.Shared.NextDouble() * 30 - 20, 1);
    string? location = null;
    if (!string.IsNullOrEmpty(sensorId))
    {
        location = sensorId switch
        {
            "1" =>  "Living Room",
            "2" => "Bedroom",
            "3" => "Kitchen",
            _ => "Unknown"
        };
    }

    return Results.Ok(new TemperatureData
    {
        Value = temperature,
        Location = !string.IsNullOrWhiteSpace(location) ? location : "unknown",
        SensorId = !string.IsNullOrWhiteSpace(sensorId) ? sensorId : "unknown",
        Description = $"Temperature form {location} for sensor with ID:'{sensorId}'"
    });
});

app.Run();
