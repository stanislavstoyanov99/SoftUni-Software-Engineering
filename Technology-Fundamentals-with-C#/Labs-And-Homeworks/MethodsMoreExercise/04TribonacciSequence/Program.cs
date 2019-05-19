using System;

namespace _04TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Tribonacci(number);
        }

        private static void Tribonacci(int num)
        {
            int firstNumber = 1;
            int secondNumber = 0;
            int thirdNumber = 0;

            for (int i = 1; i <= num; i++)
            {
                int currentNumber = firstNumber + secondNumber + thirdNumber; 
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = currentNumber;

                Console.Write(currentNumber + " ");
            }
            Console.WriteLine();
        }
    }
}
