using System;
using System.Collections.Generic;

namespace _02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var collectionOfResources = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (collectionOfResources.ContainsKey(resource))
                {
                    collectionOfResources[resource] += quantity;
                }
                else
                {
                    collectionOfResources.Add(resource, quantity);
                }
            }

            foreach (var count in collectionOfResources)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
