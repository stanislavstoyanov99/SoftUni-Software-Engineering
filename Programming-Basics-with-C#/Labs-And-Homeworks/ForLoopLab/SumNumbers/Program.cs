using System;

class Program
{
    static void Main(string[] args)
    {
        int numbersCount = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int count = 0; count < numbersCount; count++)
        {
            int number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine(sum);
    }
}
