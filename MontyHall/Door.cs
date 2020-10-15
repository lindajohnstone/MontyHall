using System;
using System.Linq;

namespace MontyHall
{
    public class Doors
    {
        IBehindTheDoor[] prizes; 
        IInput _input;
        private readonly IOutput _output;

        public Doors(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        private int min = 0;
        private int max = 3;
        public IBehindTheDoor[] InitialiseDoors()
        {
            prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
            return prizes.OrderBy(_ => Guid.NewGuid()).ToArray();
        }

        public int ChoosePlayerDoor()
        {
            Random rand = new Random();
            var chosenDoor = rand.Next(min, max);
            return chosenDoor;
        }

        public bool IsPrize(int chosenDoor)
        {
            return prizes[chosenDoor].IsPrize(); // TODO: validation pending if asking for input         
        }

        public int ChooseMontysDoor(int chosenDoor)
        {
            var montysDoor = 0; 
            for (int i = 0; i < prizes.Length; i++)
            {
                if (i != chosenDoor || !prizes[i].IsPrize())
                {
                    montysDoor = i;
                    break;
                }
            }
            return montysDoor;
        }

        public int UnopenedDoor(int chosenDoor, int montysDoor)
        {
            var unopenedDoor = 0; 
            for (int i = 0; i < max; i++)
            {
                if (i != chosenDoor && i != montysDoor)
                {
                    unopenedDoor = i;
                    break;
                }
            }
            return unopenedDoor;
        }

        public bool DecideWhichDoor(int chosenDoor, int switchDoor)
        {
            Console.WriteLine("Would you like to keep your original door or switch to the unopened door?");
            Console.WriteLine("Enter 'y' to keep or 'n' to switch.");
            var userInput = _input.ReadLine();
            if (userInput == "y") return true; 
            return false;
        }
    }
}