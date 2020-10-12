using System;

namespace MontyHall
{
    public class RandomPrizeGenerator
    {
        private readonly Random _random = new Random();
        private int min = 0;
        private int max = 3;
        public int GeneratePrizes(int min, int max)
        {
            return _random.Next(min, max);  
        }
    }
}