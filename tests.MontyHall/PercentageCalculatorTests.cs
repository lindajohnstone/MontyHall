using MontyHall;
using Xunit;

namespace tests.MontyHall
{
    public class PercentageCalculatorTests
    {
        [Theory]
        [InlineData(300, 30)]
        [InlineData(331, 33)]
        [InlineData(682, 68)]
        public void Should_Test_PercentageCalculator(double count, double expected)
        {
            // arrange
            var calculator = new PercentageCalculator();
            // act
            var result = calculator.CalculatePercentage(count, 1000);
            // assert
            Assert.Equal(expected, result);
        }
    }
}