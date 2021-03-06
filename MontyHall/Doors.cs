using System;
using System.Linq;

namespace MontyHall
{
    public class Doors
    {
        IBehindTheDoor[] prizes = new IBehindTheDoor[] {new Car(), new Goat(), new Goat()}; 
        IInput _input;
        IOutput _output;
        PercentageCalculator _calculator;
        Random rand = new Random();
        public Doors(IInput input, IOutput output, PercentageCalculator calculator)
        {
            _input = input;
            _output = output;
            _calculator = calculator;
        }
        private int min = 0;
        private int max = 3;
        private int chosenDoor;
        private int montysDoor;
        private int unopenedDoor;
        private bool doorChoice;
        private int count;
        private int winCount;
        private int loseCount;
        public void KeepDoor()
        {
            winCount = 0;
            loseCount = 0;
            count = 0;
            while(count < 1000)
            {
                InitialiseDoors();
                ChoosePlayerDoor();
                if(IsPrize(chosenDoor)) winCount++;
                if(!IsPrize(chosenDoor)) loseCount++;
                count++;
            }
            PrintToConsole("Keep Door Strategy:");
            ShowStatistics();
        }
        public void SwitchDoor()
        {
            winCount = 0;
            loseCount = 0;
            count = 0;
            while(count < 1000)
            {  
                InitialiseDoors();
                ChoosePlayerDoor();
                ChooseMontysDoor(chosenDoor);
                UnopenedDoor(chosenDoor, montysDoor);
                if(IsPrize(chosenDoor)) loseCount++;
                if(!IsPrize(chosenDoor)) winCount++;
                count++;
            }
            PrintToConsole("Switch Door Strategy:");
            ShowStatistics();
        }
        public void ShowStatistics()
        {
            PrintToConsole(Environment.NewLine);
            var percentage = CalculatePercentage(winCount, 1000);
            var message = string.Format("Total number of games = {0}. Total wins = {1}. Total losses = {2}. Winning percentage = {3}%.", count, winCount, loseCount, percentage);
            PrintToConsole(message);
            PrintToConsole(Environment.NewLine);
        }    
        private double CalculatePercentage(double winCount, double v)
        {
            return _calculator.CalculatePercentage(winCount, 1000);
        }

        public void RunSimulation()
        {
            PrintToConsole("Monty Hall Simulation Statistics");
            PrintToConsole(Environment.NewLine);
            KeepDoor();
            SwitchDoor();
        }
        public void Play()
        {
            InitialiseDoors();
            ChoosePlayerDoor();
            ChooseMontysDoor(chosenDoor);
            UnopenedDoor(chosenDoor, montysDoor);
            OpenDoor();
            RevealPrize(doorChoice);
        }
        public IBehindTheDoor[] InitialiseDoors()
        {
            return prizes.OrderBy(_ => Guid.NewGuid()).ToArray();
        }

        public int ChoosePlayerDoor()
        {
            chosenDoor = rand.Next(min, max);
            return chosenDoor;
        }

        public bool IsPrize(int chosenDoor)
        {
            return prizes[chosenDoor].IsPrize(); // TODO: validation pending if asking for input         
        }

        public int ChooseMontysDoor(int chosenDoor)
        { 
            for (int i = 0; i < prizes.Length; i++)
            {
                if (i != chosenDoor || !prizes[i].IsPrize())
                {
                    montysDoor = i;
                    break;
                }
            }
            return montysDoor;
        }

        public int UnopenedDoor(int chosenDoor, int montysDoor)
        {
            for (int i = 0; i < max; i++)
            {
                if (i != chosenDoor && i != montysDoor)
                {
                    unopenedDoor = i;
                    break;
                }
            }
            return unopenedDoor;
        }
        private void PrintToConsole(string message)
        {
            _output.Write(message);
        }

        public bool DecideWhichDoor(int chosenDoor, int unopenedDoor)
        {
            PrintToConsole("Would you like to keep your original door or switch to the unopened door? Enter 'y' to keep or 'n' to switch.");
            PrintToConsole(Environment.NewLine);
            var userInput = _input.ReadLine();
            if (userInput == "n") doorChoice = false;
            if (userInput == "y") doorChoice = true; 
            return doorChoice; 
        }

        public void RevealPrize(bool prize)
        {
            var message = "";
            if (prize) message = "Congratulations! You have won the Car!!!";
            if (!prize) message = "Better luck next time. You have won a Goat.";
            PrintToConsole(message);
        }

        public bool OpenDoor()
        {
            if (DecideWhichDoor(chosenDoor, unopenedDoor))
            {
                return IsPrize(chosenDoor); 
            }
            return IsPrize(unopenedDoor);
        }
    }
}