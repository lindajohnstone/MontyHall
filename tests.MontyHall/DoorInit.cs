using System;
using MontyHall;

namespace tests.MontyHall
{
    public class DoorInit
    {
        IBehindTheDoor[] prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()};
        public DoorInit()
        {
        }

        internal IBehindTheDoor[] Init()
        {
            return prizes;
        }
    }
}