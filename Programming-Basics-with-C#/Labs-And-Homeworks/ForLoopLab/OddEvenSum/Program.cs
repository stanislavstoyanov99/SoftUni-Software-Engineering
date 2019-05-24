using System;

class Program
{
    static void Main(string[] args)
    {
        int totalNumbers = int.Parse(Console.ReadLine());
        int evenSum = 0;
        int oddSum = 0;

        for (int currentNumberIndex = 0; currentNumberIndex < totalNumbers; currentNumberIndex++)
        {
            int number = int.Parse(Console.ReadLine());
            if (currentNumberIndex % 2 == 0)
            {
                evenSum += number;
            }
            else
            {
                oddSum += number;
            }
        }
        if (evenSum == oddSum)
        {
            Console.WriteLine($"Yes, Sum = {evenSum}");
        }
        else
        {
            int diff = Math.Abs(evenSum - oddSum);
            Console.WriteLine($"No, Diff = {diff}");
        }
    }
}
