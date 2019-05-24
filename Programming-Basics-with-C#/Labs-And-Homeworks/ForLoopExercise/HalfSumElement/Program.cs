using System;

class Program
{
    static void Main(string[] args)
    {
        int totalNumbers = int.Parse(Console.ReadLine());
        int totalSum = 0;
        string result = string.Empty;
        int max = int.MinValue;

        for (int count = 0; count < totalNumbers; count++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            if (currentNumber > max)
            {
                max = currentNumber;
            }
            totalSum += currentNumber;
        }
        if ((totalSum - max) == max)
        {
            result = $"Yes, Sum = {max}";
        }
        else
        {
            int diff = Math.Abs((totalSum - max) - max);
            result = $"No, Diff = {diff}";
        }

        Console.WriteLine(result);
    }
}
