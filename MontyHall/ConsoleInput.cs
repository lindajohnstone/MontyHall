using System;

namespace MontyHall
{
    public class ConsoleInput : IInput
    {
        public ConsoleInput(IInput input)
        {
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}