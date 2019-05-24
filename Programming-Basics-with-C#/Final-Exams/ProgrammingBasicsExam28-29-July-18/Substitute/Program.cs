using System;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int firstNumber = k; firstNumber <= 8; firstNumber++)
            {
                for (int secondNumber = 9; secondNumber >= l; secondNumber--)
                {
                    for (int thirdNumber = m; thirdNumber <= 8; thirdNumber++)
                    {
                        for (int fourthNumber = 9; fourthNumber >= n; fourthNumber--)
                        {
                            if (firstNumber % 2 == 0 && secondNumber % 2 == 1 && thirdNumber % 2 == 0 && fourthNumber % 2 == 1)
                            {
                                if (firstNumber == thirdNumber && secondNumber == fourthNumber)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine("{0}{1} - {2}{3}", firstNumber, secondNumber, thirdNumber, fourthNumber);
                                    counter++;
                                }
                                if (counter == 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
