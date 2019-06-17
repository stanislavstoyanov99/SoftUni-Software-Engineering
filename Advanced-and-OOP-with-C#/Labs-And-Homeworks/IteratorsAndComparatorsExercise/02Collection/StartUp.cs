using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

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

                        listyIterator = new ListyIterator<string>(elements);
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
                    else if (input == "PrintAll")
                    {
                        foreach (var name in listyIterator)
                        {
                            Console.Write($"{name} ");
                        }

                        Console.WriteLine();
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
