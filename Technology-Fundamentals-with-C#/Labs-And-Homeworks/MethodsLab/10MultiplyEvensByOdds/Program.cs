using System;

namespace _10MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int legalNumber = Math.Abs(number);

            GetSumOfEvenDigits(legalNumber);
            GetSumOfOddDigits(legalNumber);

            Console.WriteLine(GetMultipleOfEvenAndOdds(legalNumber));
        }


        private static int GetSumOfOddDigits(int legalNumber)
        {
            int firstSum = 0;

            while (legalNumber > 0)
            {
                int digits = legalNumber % 10;
                if (digits % 2 != 0)
                {
                    firstSum += digits;
                }
                legalNumber /= 10;
            }

            return firstSum;
        }

        private static int GetSumOfEvenDigits(int legalNumber)
        {
            int secondSum = 0;

            while (legalNumber > 0)
            {
                int digits = legalNumber % 10;
                if (digits % 2 == 0)
                {
                    secondSum += digits;
                }
                legalNumber /= 10;
            }

            return secondSum;
        }

        private static int GetMultipleOfEvenAndOdds(int legalNumber)
        {
            int sum = GetSumOfEvenDigits(legalNumber) * GetSumOfOddDigits(legalNumber);
            return sum;
        }
    }
}
