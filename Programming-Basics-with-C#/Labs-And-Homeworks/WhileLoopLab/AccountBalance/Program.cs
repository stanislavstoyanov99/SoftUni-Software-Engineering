using System;

class Program
{
    static void Main(string[] args)
    {
        double totalSum = 0;
        int feesToMade = int.Parse(Console.ReadLine());
        int feesCount = 0;

        while (true)
        {
            double input = double.Parse(Console.ReadLine());
            if (input < 0)
            {
                Console.WriteLine("Invalid operation!");
                break;  
            }
            Console.WriteLine($"Increase: {input:F2}");

            totalSum += input;
            feesCount++;
            if (feesCount >= feesToMade)
            {
                break;
            }
        }
        Console.WriteLine($"Total: {totalSum:F2}");
    }
}
