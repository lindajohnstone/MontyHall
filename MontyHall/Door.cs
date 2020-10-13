using System;
using System.Linq;

namespace MontyHall
{
    public class Doors
    {
        public void InitialiseDoors()
        {
            var prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
            var door = prizes.OrderBy(_ => Guid.NewGuid());
        }

        public void ChooseDoor()
        {
            Random rand = new Random();
            var chosenDoor = rand.Next(0, 3);
        }

        public bool IsCarChosen(int chosenDoor)
        {
            if (chosenDoor == 0)
            {
                return true;
            }
            return false;
        }
    }
}