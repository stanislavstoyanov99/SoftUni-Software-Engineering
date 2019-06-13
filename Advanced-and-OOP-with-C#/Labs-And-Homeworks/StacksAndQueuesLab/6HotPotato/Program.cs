using System;
using System.Collections.Generic;

namespace _6HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(input);

            int n = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    string player = queue.Dequeue();
                    queue.Enqueue(player);
                }

                string removedPerson = queue.Dequeue();
                Console.WriteLine($"Removed {removedPerson}");
            }

            string lastPerson = queue.Dequeue();
            Console.WriteLine($"Last is {lastPerson}");
        }
    }
}
