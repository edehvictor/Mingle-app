using Microsoft.AspNetCore.Mvc;

namespace API.Demo;

[ApiController]
[Route("[controller]")] //	Specifies URL pattern for a controller or action.

public class WeatherForecastController : ControllerBase
{
    public static readonly string[] TempDescriptions = new[]
    {
            "Moderate Rain","Thunder Storm","Broken clouds","Light Rain","Stormy Cloud", "Drizzling Rain"
        };

        [HttpGet] //Identifies an action that supports the HTTP GET action verb.

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            //generate numbers;[1,2,3,4,5]
            var WeatherForecasts =Enumerable.Range(1,5).Select(index => new WeatherForecast
            {
                TemperatureC =Random.Shared.Next(-20, 50),
                Date =DateTime.Now.AddDays(index),
                TempDescription =TempDescriptions[Random.Shared.Next(TempDescriptions.Length)]
            }).ToArray();
            return WeatherForecasts;
        }
}
