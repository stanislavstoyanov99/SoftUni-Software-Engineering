using System;
using System.Collections.Generic;
using System.Linq;

namespace _02MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vegetablesAsString = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<int> calories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stackOfCalories = new Stack<int>(calories);
            Queue<string> queueOfVegetables = new Queue<string>(vegetablesAsString);
            List<int> doneSalads = new List<int>();

            while (stackOfCalories.Count > 0 && queueOfVegetables.Count > 0)
            {
                
                int currentCalories = stackOfCalories.Peek();
                int currentVegetable = GetTypeOfVegetable(queueOfVegetables);

                while (currentCalories != 0)
                {
                    int fakeCase = stackOfCalories.Peek();
                    currentCalories -= currentVegetable;

                    if (currentCalories <= 0)
                    {
                        queueOfVegetables.Dequeue();
                        int doneSalad = stackOfCalories.Pop();
                        doneSalads.Add(doneSalad);

                        break;
                    }
                    else
                    {
                        if (queueOfVegetables.Count > 0)
                        {
                            queueOfVegetables.Dequeue();

                            if (queueOfVegetables.Count > 0)
                            {
                                currentVegetable = GetTypeOfVegetable(queueOfVegetables);
                            }
                            else
                            {
                                doneSalads.Add(fakeCase);
                                stackOfCalories.Pop();
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }               
            }

            Console.WriteLine(string.Join(" ", doneSalads));

            if (stackOfCalories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", stackOfCalories));
            }
            else
            {
                Console.WriteLine(string.Join(" ", queueOfVegetables));
            }
        }

        private static int GetTypeOfVegetable(Queue<string> vegetables)
        {
            int currentValue = 0;

            if (vegetables.Peek() == "tomato")
            {
                currentValue = 80;
            }
            else if (vegetables.Peek() == "carrot")
            {
                currentValue = 136;
            }
            else if (vegetables.Peek() == "lettuce")
            {
                currentValue = 109;
            }
            else if (vegetables.Peek() == "potato")
            {
                currentValue = 215;
            }

            return currentValue;
        }
    }
}
