using System;

namespace _04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] valuesAsArray = values.Split();

            for (int i = valuesAsArray.Length - 1; i >= 0; i--)
            {
                Console.Write(valuesAsArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
