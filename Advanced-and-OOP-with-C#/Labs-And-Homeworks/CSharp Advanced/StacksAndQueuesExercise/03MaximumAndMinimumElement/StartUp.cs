namespace _03MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Stack<int> stackOfNumbers = new Stack<int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string query = Console.ReadLine();
                string[] tokens = query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int numberOfQuery = int.Parse(tokens[0]);

                switch (numberOfQuery)
                {
                    case 1:
                        int numberToPush = int.Parse(tokens[1]);
                        stackOfNumbers.Push(numberToPush);
                        break;
                    case 2:
                        if (stackOfNumbers.Count > 0)
                        {
                            stackOfNumbers.Pop();
                        }
                        break;
                    case 3:
                        if (stackOfNumbers.Count > 0)
                        {
                            Console.WriteLine(stackOfNumbers.Max());
                        }
                        break;
                    case 4:
                        if (stackOfNumbers. Count > 0)
                        {
                            Console.WriteLine(stackOfNumbers.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stackOfNumbers));
        }
    }
}
