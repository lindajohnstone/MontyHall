using Xunit;
using MontyHall;
using System;
using System.Linq;

namespace tests.MontyHall
{
    public class MontyHallTests
    {
        [Fact]
        public void Should_Test_Initialise_Door()
        {
            // arrange
            var doorInit = new DoorInit();

            // act
            var randomResult1 = doorInit.Init();
            var randomResult2 = doorInit.Init();

            // assert
            Assert.Equal(randomResult1, randomResult2);
        }

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

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        public void Should_Test_If_Car_Chosen(int chosenDoor, bool expected)
        {
            // arrange
            var doors = new Doors();
            var prizes = doors.InitialiseDoors();
            // act
            var result = doors.IsPrize(chosenDoor);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_MontysDoor()
        {
            // arrange
            var doors = new Doors();
            var prizes = doors.InitialiseDoors();
            var chosenDoor = 1;
            // act
            var result = doors.MontysDoor(chosenDoor);

            // assert
            Assert.NotEqual(chosenDoor, result);
        }
    }
}
