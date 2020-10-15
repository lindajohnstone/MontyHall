using Xunit;
using MontyHall;
using System;
using System.Linq;
using Moq;

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
            var doors = new Doors(new StubInput());
            var prizes = doors.InitialiseDoors();
            // act
            var result = doors.IsPrize(chosenDoor);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_ChooseMontysDoor()
        {
            // arrange
            var doors = new Doors(new StubInput());
            var prizes = doors.InitialiseDoors();
            var chosenDoor = 1;
            // act
            var result = doors.ChooseMontysDoor(chosenDoor);
            // assert
            Assert.NotEqual(chosenDoor, result);
        }
        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(0, 2, 1)]
        [InlineData(2, 0, 1)]
        public void Should_Test_SwitchDoor(int chosenDoor, int montysDoor, int expected)
        {
            // arrange
            var doors = new Doors(new StubInput());
            // act
            var result = doors.UnopenedDoor(chosenDoor, montysDoor);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new [] {0,1}, "y", true)]
        [InlineData(new [] {0,1}, "n", false)]
        public void Should_Test_UserInput_ChosenDoor_DecideWhichDoor(int[] door, string userInput, bool expected)
        {
            // arrange
            // arrange
            var moqInput = new Mock<IInput>();
            moqInput
                .Setup(_ => _.ReadLine())
                .Returns(userInput);
            var doors = new Doors(moqInput.Object);
            // act
            var result = doors.DecideWhichDoor(door[0], door[1]);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
