namespace MockingApp.Services
{
    public interface IWeatherService
    {
        IEnumerable<string> GetWeatherForecast();
    }
}
