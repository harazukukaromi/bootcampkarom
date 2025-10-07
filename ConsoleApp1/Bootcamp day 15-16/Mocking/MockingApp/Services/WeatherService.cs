namespace MockingApp.Services
{
    public class WeatherService : IWeatherService
    {
        public IEnumerable<string> GetWeatherForecast()
        {
            return new List<string> { "Sunny", "Cloudy", "Rainy" };
        }
    }
}
