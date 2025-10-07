namespace MockingApp.Services
{
    public interface IWeatherService
    {
        string GetTodayWeather();
    }

    public class WeatherService : IWeatherService
    {
        public string GetTodayWeather()
        {
            return "Sunny";
        }
    }
}