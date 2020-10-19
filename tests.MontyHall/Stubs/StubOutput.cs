using System;
using System.Collections;
using System.Collections.Generic;
using MontyHall;

namespace tests.MontyHall
{
    public class StubOutput : IOutput
    {
        private string _writeLine;
        private string _write;
        Queue<string> _queue;
        public StubOutput()
        {
            _queue = new Queue<string>();
        }
        public void WriteLine(string v)
        {
            _queue.Enqueue(v);
        }

        public void Write(string v)
        {
            Console.Write(v);
        }

        public string GetWriteLine() 
        {
            return _queue.Dequeue();
        }
        public string GetWrite() 
        {
            return _write;
        }
    }
}