using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number for the combination: ");
        int numberOfCombination = int.Parse(Console.ReadLine());
        Stopwatch sw = Stopwatch.StartNew();

        int counter = 0;

        if (numberOfCombination >= 1 && numberOfCombination <= 13_983_816)
        {
            for (int firstNumber = 1; firstNumber <= 44; firstNumber++)
            {
                for (int secondNumber = firstNumber + 1; secondNumber <= 45; secondNumber++)
                {
                    for (int thirdNumber = secondNumber + 1; thirdNumber <= 46; thirdNumber++)
                    {
                        for (int fourthNumber = thirdNumber + 1; fourthNumber <= 47; fourthNumber++)
                        {
                            for (int fifthNumber = fourthNumber + 1; fifthNumber <= 48; fifthNumber++)
                            {
                                for (int sixthNumber = fifthNumber + 1; sixthNumber <= 49; sixthNumber++)
                                {
                                    string combination = Combination(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber, sixthNumber);
                                    counter++;

                                    if (numberOfCombination == counter)
                                    {
                                        Console.WriteLine($"Lottery combination: {combination}");
                                        Console.WriteLine("Your chance to win is 1/13 983 816, so good luck! :)");
                                        Console.WriteLine($"Execution time: {sw.Elapsed}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Input a valid number between 1 - 13_983_816 for the combination!");
        }
    }

    private static string Combination(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber, int sixthNumber)
    {
        StringBuilder combination = new StringBuilder();
        combination = combination.Append(firstNumber)
            .Append(secondNumber)
            .Append(thirdNumber)
            .Append(fourthNumber)
            .Append(fifthNumber)
            .Append(sixthNumber);
        return combination.ToString();
    }
}
