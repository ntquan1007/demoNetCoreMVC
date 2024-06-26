using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if (!_forecasts.Any())
            {
                _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet(Name = "getAll")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecasts;
        }

        [HttpGet("{id}", Name = "get")]
        public ActionResult<WeatherForecast> GetById(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }
            return forecast;
        }

        [HttpPut("{id}", Name = "update")]
        public IActionResult Update(int id, [FromBody] WeatherForecast updatedForecast)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }

            forecast.Date = updatedForecast.Date;
            forecast.TemperatureC = updatedForecast.TemperatureC;
            forecast.Summary = updatedForecast.Summary;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "delete")]
        public IActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }

            _forecasts.Remove(forecast);
            return NoContent();
        }
    }
}
