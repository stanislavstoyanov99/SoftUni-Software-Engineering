using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        for (int currentNumber = 1; currentNumber <= number; currentNumber += 3)
        {
            Console.WriteLine(currentNumber);
        }
    }
}
