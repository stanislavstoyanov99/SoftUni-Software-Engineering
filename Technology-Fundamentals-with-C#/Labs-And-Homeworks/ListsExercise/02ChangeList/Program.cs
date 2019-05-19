using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> tokens = input.Split().ToList();
                string command = tokens[0];

                switch (command)
                {
                    case "Delete":
                        int elementToDelete = int.Parse(tokens[1]);

                        Delete(numbers, elementToDelete); break;
                    case "Insert":
                        int elementToInsert = int.Parse(tokens[1]);
                        int positionToInsert = int.Parse(tokens[2]);

                        InsertElement(numbers, elementToInsert, positionToInsert); break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Delete(List<int> numbers, int elementToDelete)
        {
            numbers.RemoveAll(x => x == elementToDelete);
        }

        private static void InsertElement(List<int> numbers, int elementToInsert, int positionToInsert)
        {
            numbers.Insert(positionToInsert, elementToInsert);
        }
    }
}
