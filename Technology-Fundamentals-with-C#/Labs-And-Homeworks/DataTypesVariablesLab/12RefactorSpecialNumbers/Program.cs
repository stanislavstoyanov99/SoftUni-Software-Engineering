using System;

namespace _12RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isSpecialNum = false;
            for (int number = 1; number <= n; number++)
            {
                int sumOfDigits = 0;
                int digits = number;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }

                isSpecialNum = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);

                Console.WriteLine("{0} -> {1}", number, isSpecialNum);
            }
        }
    }
}
