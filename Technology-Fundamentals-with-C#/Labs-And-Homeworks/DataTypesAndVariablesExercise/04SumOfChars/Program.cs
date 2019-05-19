using System;

namespace _04SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCharacters = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int i = 1; i <= numberOfCharacters; i++)
            {
                char character = char.Parse(Console.ReadLine());
                totalSum += character;
            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
