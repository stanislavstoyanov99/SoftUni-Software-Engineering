using System;
using System.Collections.Generic;

namespace _06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> queueOfNames = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (queueOfNames.Count > 0)
                    {
                        Console.WriteLine(queueOfNames.Dequeue());
                    }
                }
                else
                {
                    queueOfNames.Enqueue(input);
                }
            }

            Console.WriteLine($"{queueOfNames.Count} people remaining.");
        }
    }
}
