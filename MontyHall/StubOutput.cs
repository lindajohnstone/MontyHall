using System;

namespace MontyHall
{
    public class StubOutput : IOutput
    {
        private string _writeLine;
        private string _write;
        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }

        public void Write(string v)
        {
            Console.Write(v);
        }

        public string GetWriteLine() 
        {
            return _writeLine;
        }
        public string GetWrite() 
        {
            return _write;
        }
    }
}