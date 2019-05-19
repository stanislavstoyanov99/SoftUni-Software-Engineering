using System;
using System.Collections.Generic;
using System.Linq;

namespace _05DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            List<int> initialQualityOfEachDrum = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newListOfDrums = initialQualityOfEachDrum.ToList();   // create a new list with the initial elements

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")   // loop until the command "Hit it again, Gabsy!"
            {
                int hitPower = int.Parse(input);   // set the hit power from the received input

                for (int i = 0; i < newListOfDrums.Count; i++)   // loop all the elements from the new list
                {
                    newListOfDrums[i] -= hitPower;   // remove the hit power from the current element

                    if (newListOfDrums[i] <= 0)   // check whether the current quality of the element is <= 0
                    {
                        newListOfDrums[i] = initialQualityOfEachDrum[i];   // set the current quality to be the initial quality
                        int newPrice = initialQualityOfEachDrum[i] * 3;   // sum the new price

                        if (newPrice > budget)
                        {
                            initialQualityOfEachDrum.Remove(initialQualityOfEachDrum[i]);   // remove the current quality from the list 
                            newListOfDrums.Remove(newListOfDrums[i]);   // remove the current quality also from the new list
                            i--;   // reduce the count so that the next iteration starts from 0 index
                        }
                        else
                        {
                            budget -= newPrice;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", newListOfDrums));
            Console.WriteLine($"Gabsy has {budget:F2}lv.");
        }
    }
}
