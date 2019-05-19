using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bestBatch = new List<int> { int.MinValue }; //the best Batch initially is int.MinValue
            int bestQuality = int.MinValue; // the best quality initially is int.MinValue
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bake It!")
            {
                List<int> currentBatch = input.Split("#").Select(int.Parse).ToList();
                int currentQuality = currentBatch.Sum(); // calculate the current quality of the current batch

                bool foundBetterBatch = false;
                if (bestQuality < currentQuality)
                {
                    foundBetterBatch = true;
                }
                else if (bestQuality == currentQuality) // check whether the best quality is equal with the current quality
                {
                    if (bestBatch.Average() < currentBatch.Average()) // check the average quality of two batches
                    {
                        foundBetterBatch = true;
                    }
                    else if (bestBatch.Average() == currentBatch.Average() // check the average quality and length of two batches
                        && bestBatch.Count > currentBatch.Count)
                    {
                        foundBetterBatch = true;
                    }
                }

                if (foundBetterBatch) // if the better batch is found
                {
                    bestBatch = currentBatch.ToList(); // the best batch is the current batch
                    bestQuality = bestBatch.Sum(); // the best quality is the best batch sum
                }
            }

            Console.WriteLine($"Best Batch quality: {bestQuality}");
            Console.WriteLine(string.Join(" ", bestBatch));
        }
    }
}
