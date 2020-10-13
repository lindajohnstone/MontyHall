using Xunit;
using MontyHall;
using System;
using System.Linq;

namespace tests.MontyHall
{
    public class MontyHallTests
    {
        [Fact]
        public void ShouldTestDoorInitialisation()
        {
            // arrange
            var prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};

            // act
            var randomResult1 = prizes.OrderBy(_ => Guid.NewGuid());
            var randomResult2 = prizes.OrderBy(_ => Guid.NewGuid()); 
            // assert
            Assert.NotEqual(randomResult1, randomResult2);
        }

        [Fact]
        public void ShouldTestCar_DoorState()
        {
            // arrange
            var car = new Car();
            // act
            var result = car.DoorState();
            // assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldTestGoat_DoorState()
        {
            // arrange
            var goat = new Goat();
            // act
            var result = goat.DoorState();
            // assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        public void ShouldTestIfCarChosen(int chosenDoor, bool expected)
        {
            // arrange
            var door = new Doors();
            // act
            var result = door.IsCarChosen(chosenDoor);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
