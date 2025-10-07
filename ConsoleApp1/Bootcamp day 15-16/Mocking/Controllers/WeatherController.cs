using Microsoft.AspNetCore.Mvc;
using Mocking.Services;

namespace Mocking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("today")]
        public IActionResult GetTodayWeather()
        {
            var result = _weatherService.GetTodayWeather();
            return Ok(result);
        }
    }
}
