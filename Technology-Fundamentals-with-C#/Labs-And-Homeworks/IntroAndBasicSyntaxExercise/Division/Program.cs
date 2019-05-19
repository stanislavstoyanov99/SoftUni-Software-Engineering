using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = string.Empty;

            int divisor;

            if (number % 10 == 0)
            {
                divisor = 10;
                result = $"The number is divisible by {divisor}";
            }
            else if (number % 7 == 0)
            {
                divisor = 7;
                result = $"The number is divisible by {divisor}";
            }
            else if (number % 6 == 0)
            {
                divisor = 6;
                result = $"The number is divisible by {divisor}";
            }
            else if (number % 3 == 0)
            {
                divisor = 3;
                result = $"The number is divisible by {divisor}";
            }
            else if (number % 2 == 0)
            {
                divisor = 2;
                result = $"The number is divisible by {divisor}";
            }
            else
            {
                result = "Not divisible";
            }

            Console.WriteLine(result);
        }
    }
}
