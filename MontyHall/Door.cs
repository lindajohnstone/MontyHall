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

        public int ChooseDoor()
        {
            Random rand = new Random();
            var chosenDoor = rand.Next(0, 3);
            return chosenDoor;
        }

        public bool IsPrize(int chosenDoor)
        {
            return prizes[chosenDoor].IsPrize(); // TODO: validation pending if asking for input         
        }

        public int MontysDoor(int chosenDoor)
        {
            // MontysDoor != chosenDoor;
            // MontysDoor.IsPrize is always false
            // 1/ check
            var MontysDoor = 0; 
            for (int i = 0; i < prizes.Length; i++)
            {
                if (i != chosenDoor)
                {
                    if (!prizes[i].IsPrize())
                    {
                        MontysDoor = i;
                    }
                }
            }
            return MontysDoor;
        }
    }
}