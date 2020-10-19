using System;

namespace MontyHall
{
    public class DoorInput 
    {
        private IInput _doorInput;
        private Doors _door;
        public DoorInput(IInput doorInput)
        {
            _doorInput = doorInput;
        }
        public bool ValidateInput(string input)
        {
            if (input == "y" || input == "n") return true;
            return false;
        }
    }
}