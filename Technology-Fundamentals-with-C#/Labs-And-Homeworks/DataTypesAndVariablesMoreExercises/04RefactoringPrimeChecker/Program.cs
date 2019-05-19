using System;

namespace _04RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                string IsPrime = "true";
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        IsPrime = "false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, IsPrime);
            }
        }
    }
}
