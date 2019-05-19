using System;
using System.Collections.Generic;
using System.Linq;

namespace _02CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            double timeOfLeftRacer = default(double);
            double timeOfRightRacer = default(double);
            string winnerType = string.Empty;

            int finishLine = numbers.Count / 2;

            for (int i = 0; i < finishLine; i++)
            {
                if (numbers[i] == 0)
                {
                    timeOfLeftRacer *= 0.8;
                    continue;
                }

                timeOfLeftRacer += numbers[i];
            }

            numbers.Reverse();

            for (int i = 0; i < finishLine; i++)
            {
                if (numbers[i] == 0)
                {
                    timeOfRightRacer *= 0.8;
                    continue;
                }

                timeOfRightRacer += numbers[i];
            }

            if (timeOfLeftRacer < timeOfRightRacer)
            {
                winnerType = "left";
                Console.WriteLine($"The winner is {winnerType} with total time: {timeOfLeftRacer}");
            }
            else
            {
                winnerType = "right";
                Console.WriteLine($"The winner is {winnerType} with total time: {timeOfRightRacer}");
            }
        }
    }
}
