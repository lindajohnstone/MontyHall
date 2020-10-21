using System;

namespace MontyHall
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}