using System;
using System.Collections.Generic;
using System.Linq;

namespace _01SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> chemicalLiquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> physicalItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Queue<int> queueOfLiquids = new Queue<int>(chemicalLiquids);
            Stack<int> stackOfItems = new Stack<int>(physicalItems);

            int aluminiumCounter = 0;
            int carbonFiberCounter = 0;
            int glassCounter = 0;
            int lithiumCounter = 0;

            const int glassValue = 25;
            const int aluminiumValue = 50;
            const int lithiumValue = 75;
            const int carbonFiberValue = 100;

            while (queueOfLiquids.Count > 0 && stackOfItems.Count > 0)
            {
                int currentLiquid = queueOfLiquids.Peek();
                int currentItem = stackOfItems.Peek();
                int sum = currentItem + currentLiquid;

                if (sum == glassValue)
                {
                    glassCounter++;
                    queueOfLiquids.Dequeue();
                    stackOfItems.Pop();
                }
                else if (sum == aluminiumValue)
                {
                    aluminiumCounter++;
                    queueOfLiquids.Dequeue();
                    stackOfItems.Pop();
                }
                else if (sum == lithiumValue)
                {
                    lithiumCounter++;
                    queueOfLiquids.Dequeue();
                    stackOfItems.Pop();
                }
                else if (sum == carbonFiberValue)
                {
                    carbonFiberCounter++;
                    queueOfLiquids.Dequeue();
                    stackOfItems.Pop();
                }
                else
                {
                    queueOfLiquids.Dequeue();
                    int currentValue = stackOfItems.Pop();
                    currentValue += 3;
                    stackOfItems.Push(currentValue);
                }
            }

            if (aluminiumCounter > 0 && carbonFiberCounter > 0
                && glassCounter > 0 && lithiumCounter > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueOfLiquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueOfLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackOfItems.Count != 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackOfItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {aluminiumCounter}");
            Console.WriteLine($"Carbon fiber: {carbonFiberCounter}");
            Console.WriteLine($"Glass: {glassCounter}");
            Console.WriteLine($"Lithium: {lithiumCounter}");
        }
    }
}
