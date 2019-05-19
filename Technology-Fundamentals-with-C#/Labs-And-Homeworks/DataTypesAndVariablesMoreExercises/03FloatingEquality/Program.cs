using System;

namespace _03FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double firstNumberFraction = firstNumber - (int)firstNumber;
            double secondNumberFraction = secondNumber - (int)secondNumber;
            double totalFraction = Math.Abs(firstNumberFraction - secondNumberFraction);
            double precision = 0.000001;

            bool biggerNumber = false;
            if (totalFraction >= precision)
            {
                biggerNumber = false;
            }
            else
            {
                biggerNumber = true;
            }

            Console.WriteLine(biggerNumber);
        }
    }
}
