using System;

namespace _02BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] workingDays = Console.ReadLine().Split("|");

            int initialEnergy = 100;
            int initialCoins = 100;
            int counter = 0;

            for (int i = 0; i < workingDays.Length; i++)
            {
                string[] tokens = workingDays[i].Split("-"); // takes each event with number from the array
                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                if (command == "rest")
                {
                    if (initialEnergy + number <= 100) // check whether the energy is below or equal to 100
                    {
                        initialEnergy += number;
                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                    }
                    else
                    {
                        number = 100 - initialEnergy;
                        initialEnergy = 100;
                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                    }
                }
                else if (command == "order") // remove 30 energy from the initial energy
                {
                    if (initialEnergy - 30 < 0) // check whether the energy drops below 0
                    {
                        initialEnergy += 50; // gain 50 energy points
                        Console.WriteLine($"You had to rest!");
                    }
                    else // enough energy to complete the order
                    {
                        initialCoins += number;
                        initialEnergy -= 30;
                        Console.WriteLine($"You earned {number} coins.");
                    }
                }
                else
                {
                    initialCoins -= number;
                    if (initialCoins > 0)
                    {
                        Console.WriteLine($"You bought {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {command}.");
                        return;
                    }
                }

                counter++;
            }

            if (counter == workingDays.Length) // check whether all of the events are made
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {initialCoins}");
                Console.WriteLine($"Energy: {initialEnergy}");
            }
        }
    }
}
