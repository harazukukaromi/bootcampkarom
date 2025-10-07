using Xunit;
using CalculatorApp;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnSum_WhenGivenTwoNumbers()
        {
            var calc = new Calculator();
            int result = calc.Add(3, 5);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ShouldReturnDifference_WhenGivenTwoNumbers()
        {
            var calc = new Calculator();
            int result = calc.Subtract(10, 4);
            Assert.Equal(6, result);
        }
    }
}

