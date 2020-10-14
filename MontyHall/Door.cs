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
            var chosenDoor = rand.Next(0, 3);// TODO: for scaleability, add constant min & max
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

        public object SwitchDoor(int chosenDoor, int montysDoor)
        {
            var switchDoor = 0; 
            for (int i = 0; i < 3; i++) // TODO: for scaleability, use constant max from ChoosePlayerDoor
            {
                if (i != chosenDoor && i != montysDoor)
                {
                    switchDoor = i;
                    break;
                }
            }
            return switchDoor;
        }
    }
}