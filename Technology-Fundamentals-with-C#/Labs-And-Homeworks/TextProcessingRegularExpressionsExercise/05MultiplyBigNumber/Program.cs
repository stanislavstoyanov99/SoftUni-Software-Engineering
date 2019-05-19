using System;
using System.Collections.Generic;

namespace _05MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int decimalReminder = 0;
            int currentMultiplication = 0;
            var result = new List<int>();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int currentDigit = firstNumber[i] - '0';
                currentMultiplication = currentDigit * secondNumber;
                currentMultiplication += decimalReminder;

                result.Add(currentMultiplication % 10);
                decimalReminder = currentMultiplication / 10;
            }

            if (decimalReminder > 0)
            {
                result.Add(decimalReminder);
            }

            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
