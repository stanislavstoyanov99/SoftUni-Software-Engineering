using System;

namespace _01RhombusOfStars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Runner runner = new Runner();
            runner.Start();
        }
    }

    public class Runner
    {
        public void Start()
        {
            int figureSize = int.Parse(Console.ReadLine());

            for (int starsCount = 1; starsCount <= figureSize; starsCount++)
            {
                this.PrintRow(figureSize, starsCount);
            }

            for (int starsCount = figureSize - 1; starsCount >= 1; starsCount--)
            {
                this.PrintRow(figureSize, starsCount);
            }
        }

        private void PrintRow(int figureSize, int starsCount)
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
