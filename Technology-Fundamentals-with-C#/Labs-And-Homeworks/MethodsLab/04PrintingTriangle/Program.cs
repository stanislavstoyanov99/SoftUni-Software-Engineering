using System;

namespace _04PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
            PrintReversedTriangle(number - 1);
        }

        private static void PrintTriangle(int maxNumber)
        {
            for (int row = 1; row <= maxNumber; row++)
            {
                PrintRowWithNumbers(row);
            }
        }

        private static void PrintRowWithNumbers(int row)
        {
            for (int number = 1; number <= row; number++)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static void PrintReversedTriangle(int maxNumber)
        {
            for (int row = maxNumber; row >= 1; row--)
            {
                PrintRowWithNumbers(row);
            }
        }
    }
}
