using System;
using MontyHall;

namespace tests.MontyHall
{
    public class StubInput : IInput
    {
        private string _readLine;

        public string ReadLine()
        {
            return _readLine;
        }

        public StubInput WithReadLine(string value) 
        {
            _readLine = value;
            return this;
        }

    }
}