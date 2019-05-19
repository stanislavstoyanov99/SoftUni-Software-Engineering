using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumFromMethodSum = SumOfFirstAndSecondNumber(firstNumber, secondNumber);
            Console.WriteLine(Substract(thirdNumber, sumFromMethodSum));
        }

        static int SumOfFirstAndSecondNumber(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        static int Substract(int thirdNum, int sumOfTwoNumbers)
        {
            return sumOfTwoNumbers - thirdNum;
        }
    }
}
