using System;

namespace _01RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int figureSize = int.Parse(Console.ReadLine());

            for (int starsCount = 1; starsCount <= figureSize; starsCount++)
            {
                PrintRow(figureSize, starsCount);
            }

            for (int starsCount = figureSize - 1; starsCount >= 1; starsCount--)
            {
                PrintRow(figureSize, starsCount);
            }
        }

        private static void PrintRow(int figureSize, int starsCount)
        {
            for (int i = 0; i < figureSize - starsCount; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < starsCount; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
