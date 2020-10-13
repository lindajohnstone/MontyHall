namespace MontyHall
{
    public class Car : IBehindTheDoor
    {
        public bool DoorState()
        {
            // car door is the winning door
            return true;
        }
    }
}