using System;
using System.Linq;

namespace MontyHall
{
    public class Doors
    {
        IBehindTheDoor[] prizes; 
        public IBehindTheDoor[] InitialiseDoors()
        {
            prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
            return prizes.OrderBy(_ => Guid.NewGuid()).ToArray();
        }

        public int ChoosePlayerDoor()
        {
            Random rand = new Random();
            var chosenDoor = rand.Next(0, 3);// TODO: for scaleability, add field min & max
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

        public int SwitchDoor(int chosenDoor, int montysDoor)
        {
            var switchDoor = 0; 
            for (int i = 0; i < 3; i++) // TODO: for scaleability, use field max from ChoosePlayerDoor
            {
                if (i != chosenDoor && i != montysDoor)
                {
                    switchDoor = i;
                    break;
                }
            }
            return switchDoor;
        }

        public int DecideWhichDoor(int chosenDoor, int switchDoor)
        {
            Console.WriteLine("Would you like to keep your original door or switch to the unopened door?");
            Console.WriteLine("Enter 'y' to keep or 'n' to switch.");
            var input = Console.ReadLine();
            if (input == "y") return chosenDoor;
            return switchDoor;
        }
    }
}