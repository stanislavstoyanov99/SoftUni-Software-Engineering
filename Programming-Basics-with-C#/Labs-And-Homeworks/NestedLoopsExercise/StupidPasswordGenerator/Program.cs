using System;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        for (int firstSymbol = 1; firstSymbol < firstNumber; firstSymbol++)
        {
            for (int secondSymbol = 1; secondSymbol < firstNumber; secondSymbol++)
            {
                for (char thirdSymbol = 'a'; thirdSymbol < 'a' + secondNumber; thirdSymbol++)
                {
                    for (char fourthSymbol = 'a'; fourthSymbol < 'a' + secondNumber; fourthSymbol++)
                    {
                        for (int fifthSymbol = 1; fifthSymbol <= firstNumber; fifthSymbol++)
                        {
                            if (fifthSymbol > firstSymbol && fifthSymbol > secondSymbol)
                            {
                                Console.Write($"{firstSymbol}{secondSymbol}{thirdSymbol}{fourthSymbol}{fifthSymbol} ");
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine();
    }
}
