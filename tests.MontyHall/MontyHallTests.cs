using Xunit;
using MontyHall;

namespace tests.MontyHall
{
    public class MontyHallTests
    {
        [Fact]
        public void Should_Test_Car_IsPrize()
        {
            // arrange
            var car = new Car();
            // act
            var result = car.IsPrize();
            // assert
            Assert.True(result);
        }
        [Fact]
        public void Should_Test_Goat_IsPrize()
        {
            // arrange
            var goat = new Goat();
            // act
            var result = goat.IsPrize();
            // assert
            Assert.False(result);
        }
    }
}
