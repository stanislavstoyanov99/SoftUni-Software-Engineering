using System;

namespace _05MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(MultiplicationSign(firstNumber, secondNumber, thirdNumber));
        }

        private static string MultiplicationSign(int num1, int num2, int num3)
        {
            if (num1 > 0 && num2 > 0 && num3 > 0 || 
                num1 < 0 && num2 < 0 && num3 > 0 || 
                num1 > 0 && num2 < 0 && num3 < 0 ||
                num1 < 0 && num2 > 0 && num3 < 0)
            {
                return "positive";
            }
            else if (num1 > 0 && num2 > 0 && num3 < 0 || 
                num1 < 0 && num2 < 0 && num3 < 0 ||
                num3 > 0 && num2 > 0 && num1 < 0 || 
                num3 > 0 && num1 > 0 && num2 < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }
    }
}
