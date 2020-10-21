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
            Doors doors = new Doors(input, output);
            doors.Play();
        }
    }
}
