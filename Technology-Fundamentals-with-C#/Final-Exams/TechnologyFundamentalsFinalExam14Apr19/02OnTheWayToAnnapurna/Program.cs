using System;
using System.Collections.Generic;
using System.Linq;

namespace _02OnTheWayToAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            var diary = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split("->");
                string command = tokens[0];
                string store = tokens[1];

                if (command == "Add")
                {
                    string items = tokens[2];

                    string[] itemsAsArray = items.Split(",");

                    foreach (var item in itemsAsArray)
                    {
                        if (!diary.ContainsKey(store))
                        {
                            diary.Add(store, new List<string>() { item });
                        }
                        else
                        {
                            diary[store].Add(item);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    if (diary.ContainsKey(store))
                    {
                        diary.Remove(store);
                    }
                }
            }

            Console.WriteLine("Stores list:");

            foreach (var kvp in diary.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in diary[kvp.Key])
                {
                    Console.WriteLine("<<" + item + ">>");
                }
            }
        }
    }
}
