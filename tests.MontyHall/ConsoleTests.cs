using MontyHall;
using Xunit;

namespace tests.MontyHall
{
    public class ConsoleTests
    {
        [Theory]
        [InlineData("y", true)]
        [InlineData("n", true)]
        [InlineData("1", false)]
        [InlineData("a", false)]
        public void Should_Validate_DecideDoors_Input(string input, bool expected)
        {
            // arrange
            IInput doorInput = new StubInput().WithReadLine(input);
            var userInput = new DoorInput(doorInput);
            // act
            var result = userInput.ValidateInput(input);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_OutputToConsole()
        {
            // arrange
            var doorOutput = new StubOutput();
            var doors = new Doors(new StubInput(), doorOutput);
            doorOutput._writeLine = "Would you like to keep your original door or switch to the unopened door? Enter 'y' to keep or 'n' to switch.";
            // act
            doors.PrintToConsole(doorOutput._writeLine);
            // assert
            Assert.Equal(doorOutput._writeLine, doorOutput.GetWriteLine());
        }
    }
}