using System;

class Program
{
    static void Main(string[] args)
    {
        int totalNumbers = int.Parse(Console.ReadLine());
        double oddSum = 0;
        double evenSum = 0;

        double oddMin = double.MaxValue;
        double oddMax = double.MinValue;
        double evenMin = double.MaxValue;
        double evenMax = double.MinValue;

        for (int count = 1; count <= totalNumbers; count++)
        {
            double currentNumber = double.Parse(Console.ReadLine());
            if (count % 2 == 0)
            {
                evenSum += currentNumber;
                if (currentNumber > evenMax)
                {
                    evenMax = currentNumber;
                }
                if (currentNumber < evenMin)
                {
                    evenMin = currentNumber;
                }
            }
            else
            {
                oddSum += currentNumber;
                if (currentNumber < oddMin)
                {
                    oddMin = currentNumber;
                }
                if (currentNumber > oddMax)
                {
                    oddMax = currentNumber;
                }
            }
        }
        if (totalNumbers == 0)
        {
            Console.WriteLine($"OddSum = {oddSum}, OddMin = No, OddMax = No, EvenSum = {evenSum}, EvenMin = No, EvenMax = No");
        }
        else if (totalNumbers == 1)
        {
            Console.WriteLine($"OddSum = {oddSum}, OddMin = {oddMin}, OddMax = {oddMax}, EvenSum = {evenSum}, EvenMin = No, EvenMax = No");
        }
        else
        {
            Console.WriteLine($"OddSum = {oddSum}, OddMin = {oddMin}, OddMax = {oddMax}, EvenSum = {evenSum}, EvenMin = {evenMin}, EvenMax = {evenMax}");
        }
    }
}
