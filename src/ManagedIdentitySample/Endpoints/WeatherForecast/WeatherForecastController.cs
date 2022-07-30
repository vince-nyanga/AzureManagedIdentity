using Microsoft.AspNetCore.Mvc;
using Ardalis.ApiEndpoints;

namespace ManagedIdentitySample.Endpoints.WeatherForecast;

[ApiController]
[Route("api/v{version:ApiVersion}/weather")]
[ApiVersion("1")]
public class WeatherForecastEndpoint : EndpointBaseSync.WithoutRequest.WithActionResult<IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public override ActionResult<IEnumerable<WeatherForecast>> Handle()
    {

        var weatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        return Ok(weatherForecast);
    }
}
