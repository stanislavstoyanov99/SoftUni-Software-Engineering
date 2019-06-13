using System;
using System.Collections.Generic;
using System.Linq;

namespace _02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();

                switch (command)
                {
                    case "add":
                        int firstNumberToAdd = int.Parse(tokens[1]);
                        int secondNumberToAdd = int.Parse(tokens[2]);

                        stack.Push(firstNumberToAdd);
                        stack.Push(secondNumberToAdd);
                        break;
                    case "remove":
                        int numbersToRemove = int.Parse(tokens[1]);

                        if (numbersToRemove > stack.Count)
                        {
                            break;
                        }

                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
