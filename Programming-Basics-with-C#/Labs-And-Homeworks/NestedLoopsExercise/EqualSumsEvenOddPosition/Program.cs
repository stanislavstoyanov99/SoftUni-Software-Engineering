using System;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        for (int i = firstNumber; i <= secondNumber; i++)
        {
            int currentNumber = i;
            int oddSum = 0;
            int evenSum = 0;
            while (currentNumber > 0 )
            {
                evenSum += currentNumber % 10;
                currentNumber /= 10;
                oddSum += currentNumber % 10;
                currentNumber /= 10;
            }
            if (evenSum == oddSum)
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }
}
          