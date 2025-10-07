using Xunit;
using Moq;
using Mocking.Services;
using Mocking.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Mocking.Tests
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
