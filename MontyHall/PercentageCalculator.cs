using System;

namespace MontyHall
{
    public class PercentageCalculator
    {
        public PercentageCalculator()
        {
        }

        public double CalculatePercentage(double count, double total)
        {
            return Math.Round((count / total) * 100);
        }
    }
}