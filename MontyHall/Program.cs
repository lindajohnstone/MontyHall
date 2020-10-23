using System;
using System.Collections;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var calculator = new PercentageCalculator();
            Doors doors = new Doors(input, output, calculator);
            doors.RunSimulation();
        }
    }
}
