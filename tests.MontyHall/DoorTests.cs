using MontyHall;
using Moq;
using Xunit;

namespace tests.MontyHall
{
    public class DoorTests
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
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        public void Should_Test_If_Car_Chosen(int chosenDoor, bool expected)
        {
            // arrange
            var doors = new Doors(new StubInput(), new StubOutput());
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
            var doors = new Doors(new StubInput(), new StubOutput());
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
        public void Should_Test_UnopenedDoor(int chosenDoor, int montysDoor, int expected)
        {
            // arrange
            var doors = new Doors(new StubInput(), new StubOutput());
            // act
            var result = doors.UnopenedDoor(chosenDoor, montysDoor);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new [] {0,1}, "y", true)]
        [InlineData(new [] {0,1}, "n", false)]
        public void Should_Test_DecideWhichDoor(int[] door, string userInput, bool expected)
        {
            // arrange
            var moqInput = new Mock<IInput>();
            moqInput
                .Setup(_ => _.ReadLine())
                .Returns(userInput);
            var doors = new Doors(moqInput.Object, new StubOutput());
            // act
            var result = doors.DecideWhichDoor(door[0], door[1]);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_OpenDoor()
        {
            // arrange
            var doors = new Doors(new StubInput(), new StubOutput());
            doors.InitialiseDoors();
            // act
            var result = doors.OpenDoor();
            // assert
            Assert.True(result);
        }
        [Fact]
        public void Should_Test_ChoosePlayerDoor()
        {
            // arrange
            var doors = new Doors(new StubInput(), new StubOutput());
            // act
            var result = doors.ChoosePlayerDoor();
            // assert
            Assert.InRange(result, 0, 2);
        }
        [Theory]
        [InlineData(true, "Congratulations! You have won the Car!!!")]
        [InlineData(false, "Better luck next time. You have won a Goat.")]
        public void Should_Test_RevealDoor_Output(bool prize, string expected)
        {
            // a range
            var output = new StubOutput();
            var doors = new Doors(new StubInput(), output);
            // act
            doors.RevealPrize(prize);
            // assert
            Assert.Equal(expected, output.GetWriteLine()); 
        }
    }
}