using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumbers = int.Parse(Console.ReadLine());

            for (int number = 1; number <= totalNumbers; number++)
            {
                if (SumOfDigits(number) && OddDigits(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        static bool SumOfDigits(int input)
        {
            int sum = 0;
            bool isTopNumber = false;

            while (input > 0)
            {
                int digit = input % 10;
                sum += digit;
                input /= 10;
            }

            if (sum % 8 == 0) // check whether the sum of digits is divisible by 8
            {
                isTopNumber = true;
            }

            return isTopNumber;
        }

        static bool OddDigits(int input)
        {
            bool isTopNumber = false;

            while (input > 0)
            {
                int digit = input % 10;
                if (digit % 2 != 0) // odd digits
                {
                    isTopNumber = true;
                    break;
                }
                input /= 10;
            }

            return isTopNumber;
        }
    }
}
