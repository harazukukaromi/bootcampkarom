using Xunit;
using Moq;
using MockingApp.Controllers;
using MockingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MockingApp.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void GetTodayWeather_ReturnsMockedValue()
        {
            // Arrange
            var mockService = new Mock<IWeatherService>();
            mockService.Setup(s => s.GetTodayWeather()).Returns("Cloudy");

            var controller = new WeatherController(mockService.Object);

            // Act
            var result = controller.GetTodayWeather() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Cloudy", result.Value);
        }
    }
}