using System;
using System.Collections.Generic;
using MontyHall;

namespace tests.MontyHall
{
    public class SpyBehindTheDoor : IBehindTheDoor
    {
        private int getIsPrizeCount;

        public SpyBehindTheDoor()
        {
            
        }

        public bool IsPrize()
        {
            getIsPrizeCount++;
            return true;
        }

        public int GetIsPrizeCount()
        {
            return getIsPrizeCount;
        }
    }
}