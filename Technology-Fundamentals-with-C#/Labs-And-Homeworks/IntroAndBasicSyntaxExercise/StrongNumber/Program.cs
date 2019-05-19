using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int originNumber = int.Parse(Console.ReadLine());
            int number = originNumber;

            int sum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;

                int currentFactoriel = 1; //5! = 5 * 4 * 3 * 2 * 1
                for (int i = 2; i <= lastDigit; i++)
                {
                    currentFactoriel *= i;
                }

                sum += currentFactoriel;
            }

            bool isStrong = originNumber == sum;
            if (isStrong)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
