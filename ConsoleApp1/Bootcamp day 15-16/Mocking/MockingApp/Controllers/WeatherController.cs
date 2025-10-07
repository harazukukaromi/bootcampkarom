using Microsoft.AspNetCore.Mvc;
using MockingApp.Services;

namespace MockingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult GetWeather()
        {
            var forecast = _weatherService.GetWeatherForecast();
            return Ok(forecast);
        }
    }
}


