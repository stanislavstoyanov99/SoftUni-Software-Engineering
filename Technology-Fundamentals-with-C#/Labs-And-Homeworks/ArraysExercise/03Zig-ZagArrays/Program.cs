using System;
using System.Linq;

namespace _03Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] firstCombination = new int[lines]; //first empty array
            int[] secondCombination = new int[lines]; //second empty array

            for (int i = 0; i < lines; i++)
            {
                int[] sequence = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray(); // numbers that are read from the console
                if (i % 2 == 0) // even row
                {
                    firstCombination[i] = sequence[0];
                    secondCombination[i] = sequence[1];
                }
                else // odd row
                {
                    firstCombination[i] = sequence[1];
                    secondCombination[i] = sequence[0];
                }
            }

            //foreach (var element in firstCombination)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();
            //foreach (var element in secondCombination)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine(string.Join(" ", firstCombination));
            Console.WriteLine(string.Join(" ", secondCombination));
        }
    }
}
