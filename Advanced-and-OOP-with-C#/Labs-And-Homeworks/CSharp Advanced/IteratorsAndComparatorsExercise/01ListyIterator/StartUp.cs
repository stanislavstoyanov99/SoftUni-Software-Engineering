using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    if (input.Contains("Create"))
                    {
                        List<string> elements = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToList();

                        listyIterator.Add(elements);
                    }
                    else if (input == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (input == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (input == "Print")
                    {
                        listyIterator.Print();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
