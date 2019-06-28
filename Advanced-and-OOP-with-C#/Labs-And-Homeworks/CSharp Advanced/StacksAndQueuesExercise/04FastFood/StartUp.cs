namespace _04FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfOrders = new Queue<int>(quantityOfOrders);
            Console.WriteLine(queueOfOrders.Max());

            while (queueOfOrders.Count > 0)
            {
                int currentOrder = queueOfOrders.Peek();

                if (quantityOfFood - currentOrder < 0)
                {
                    break;
                }

                quantityOfFood -= queueOfOrders.Dequeue();
            }

            if (queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrders)}");
            }
        }
    }
}
