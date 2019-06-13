using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsAndBottles
{
    class Startup
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfCups = new Queue<int>(cupsCapacity);
            Stack<int> stackOfBottles = new Stack<int>(filledBottles);

            int wastedWater = 0;

            while (queueOfCups.Count > 0 && stackOfBottles.Count > 0)
            {
                int currentCup = queueOfCups.Peek();
                int currentBottle = stackOfBottles.Peek();

                if (currentBottle >= currentCup)
                {
                    queueOfCups.Dequeue();
                    wastedWater += Math.Abs(currentBottle - currentCup);
                    stackOfBottles.Pop();
                }
                else
                {
                    while (true)
                    {
                        if (currentCup - currentBottle <= 0)
                        {
                            queueOfCups.Dequeue();
                            wastedWater += Math.Abs(currentBottle - currentCup);
                            stackOfBottles.Pop();
                            break;
                        }
                        else
                        {
                            currentCup -= currentBottle;
                            stackOfBottles.Pop();
                            currentBottle = stackOfBottles.Peek();
                        }
                    }
                }
            }

            if (stackOfBottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackOfBottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueOfCups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}