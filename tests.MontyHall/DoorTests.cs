using Xunit;
using MontyHall;
using System;
using System.Linq;

namespace tests.MontyHall
{
    public class DoorTests
    {
        [Fact]
        public void UnitTest1()
        {
            // arrange
            var prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
            

            // act
            var randomResult1 = prizes.OrderBy(_ => Guid.NewGuid());
            var randomResult2 = prizes.OrderBy(_ => Guid.NewGuid()); 
            // assert
            Assert.NotEqual(randomResult1, randomResult2);
        }
    }
}
