using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacityOfEachWagon = int.Parse(Console.ReadLine());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> commands = input.Split().ToList(); // make a list (or array) for each command

                if (commands[0] == "Add")
                {
                    int passengers = int.Parse(commands[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    int passengersToAdd = int.Parse(commands[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int passengersToFitWagon = wagons[i] + passengersToAdd; // the current numbers of passengers + the passengers to add

                        if (passengersToFitWagon <= maxCapacityOfEachWagon) // check the capacity of the wagon
                        {
                            wagons[i] += passengersToAdd; // if true add the passengers to the wagon
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}