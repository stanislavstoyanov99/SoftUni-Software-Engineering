namespace _02BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfNumbers = new Queue<int>(numbers);

            int numbersToDequeue = inputNumbers[1];
            for (int i = 0; i < numbersToDequeue; i++)
            {
                queueOfNumbers.Dequeue();
            }

            int numberToFind = inputNumbers[2];
            if (queueOfNumbers.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else if (queueOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queueOfNumbers.Min());
            }
        }
    }
}
