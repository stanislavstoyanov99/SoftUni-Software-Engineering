using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        for (int currentNumber = 0; currentNumber <= number; currentNumber += 2)
        {
            double powerOf2 = Math.Pow(2, currentNumber);
            Console.WriteLine(powerOf2);
        }
    }
}
