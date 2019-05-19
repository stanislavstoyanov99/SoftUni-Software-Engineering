using System;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());

            long firstNumberFactorial = Fact(firstNumber);
            long secondNumberFactorial = Fact(secondNumber);

            double finalResult = (double)firstNumberFactorial / secondNumberFactorial;

            Console.WriteLine($"{finalResult:F2}");
        }

        static long Fact(long num)
        {
            //Recursion
            //if (num == 1)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return num * Fact(num - 1);
            //}

            //Iterative way
            long factorial = 1;
            for (int i = 2; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
