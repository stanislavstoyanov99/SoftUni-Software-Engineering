using System;

class Program
{
    static void Main(string[] args)
    {
        int largestNumber = int.MinValue;
        int smallestNumber = int.MaxValue;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            int number = int.Parse(input);
            if (largestNumber < number)
            {
                largestNumber = number;
            }
            if (smallestNumber > number)
            {
                smallestNumber = number;
            }
            number = int.Parse(input);
        }
        Console.WriteLine($"Max number: {largestNumber}");
        Console.WriteLine($"Min number: {smallestNumber}");
    }
}
