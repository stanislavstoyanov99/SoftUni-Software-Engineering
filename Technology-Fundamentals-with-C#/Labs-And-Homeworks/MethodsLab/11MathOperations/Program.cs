using System;

namespace _11MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operatorToUse = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            switch (operatorToUse)
            {
                case "/":
                    Console.WriteLine(Division(firstNumber, secondNumber));
                    break;
                case "*":
                    Console.WriteLine(Multiply(firstNumber, secondNumber));
                    break;
                case "+":
                    Console.WriteLine(Add(firstNumber, secondNumber));
                    break;
                case "-":
                    Console.WriteLine(Subtract(firstNumber, secondNumber));
                    break;
            }
        }

        private static double Division(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        private static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}
