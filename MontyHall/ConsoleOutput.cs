using System;

namespace MontyHall
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string v)
        {
            Console.Write(v);
        }

        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }
    }
}