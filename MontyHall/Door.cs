using System;
using System.Linq;

namespace MontyHall
{
    public class Doors
    {
        public IBehindTheDoor[] InitialiseDoors()
        {
            var prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
            var doors = prizes.OrderBy(_ => Guid.NewGuid());
            var door = doors.ToArray();
            return door;
        }

        public int ChooseDoor()
        {
            Random rand = new Random();
            var chosenDoor = rand.Next(0, 3);
            return chosenDoor;
        }

        public bool IsCarChosen(int chosenDoor)
        {
            if (chosenDoor == 0)
            {
                return true;
            }
            return false;
            // this is hard coded
            // use ChooseDoor to get choice
            // allocate index value to InitialiseDoors 
            // if the value at that index is the car
            // return true
            // else return false
    }
}