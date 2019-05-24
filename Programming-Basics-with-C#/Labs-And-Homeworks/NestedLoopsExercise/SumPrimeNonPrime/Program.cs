using System;

class Program
{
    static void Main(string[] args)
    {
        int primeSum = 0;
        int nonPrimeSum = 0;

        bool isPrime = true;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
                Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
                break;
            }
            int number = int.Parse(input);

            if (number < 0)
            {
                Console.WriteLine("Number is negative.");
                continue;
            }

            isPrime = true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime && number != 1)
            {
                primeSum += number;
            }
            else
            {
                nonPrimeSum += number;
            }
        }
    }
}
