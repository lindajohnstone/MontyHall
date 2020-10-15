using System;
using Moq;

namespace tests.MontyHall
{
    internal class DecideDoors
    {
        private StubInput stubInput;

        public DecideDoors(StubInput stubInput)
        {
            this.stubInput = stubInput;
        }

        internal object DecideWhichDoor(int chosenDoor, int unopenedDoor, string userInput)
        {
            Console.WriteLine("Would you like to keep your original door or switch to the unopened door?");
            Console.WriteLine("Enter 'y' to keep or 'n' to switch.");
            //var userInput = _input.ReadLine();
            if (userInput == "y") return true; 
            return false;
        }
    }
}